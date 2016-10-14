using Reversi.Components;
using Reversi.Helpers;
using System;
using System.Drawing;
using System.Linq;

namespace Reversi
{
    class Game
    {
        public Tile[,] tiles;

        public CircularList<Player> players { get; set; }

        private Player currentPlayer { get; set; }

        public bool ShowHelp { get; set; }

        public event EventHandler ShowMessage;

        public Game()
        {
            tiles = new Tile[Settings.BoardWidth, Settings.BoardHeight];
            players = new CircularList<Player>();
        }

        /// <summary>
        /// Setup a new game (create the tiles, players, and startup scenario).
        /// </summary>
        internal void Setup()
        {
            SetupPlayers();
            SetupTiles();
        }

        private void SetupPlayers()
        {
            for (int i = 1; i <= Settings.NumberOfPlayers; i++)
            {
                var player = new Player();
                player.Points = 2;
                player.PlayerName = "player " + i;
                player.Color = i == 1 ? Color.Blue : Color.Red;
                player.PlayerLabel.ForeColor = player.Color;
                player.PlayerLabel.Location = new Point(20, 30 * i);
                players.Add(player);
            }

            currentPlayer = players.First();
            currentPlayer.PlayerLabel.Font = new Font(currentPlayer.PlayerLabel.Font, FontStyle.Bold);
        }

        private void SetupTiles()
        {
            // Some nice textures to use as background for the tiles.
            Image blackMarble = Properties.Resources.BlackMarble;
            Image whiteMarble = Properties.Resources.TexturesCom_MarbleWhite0023_M;

            // We don't want each tile to have the same background so we define an variable offset 
            // from where the image is used as background.
            Point blackMarbleImageOffset = new Point(0, 0);
            Point whiteMarbleImageOffset = new Point(0, 0);

            // Generate a tile for the width and height settings
            for (int x = 0; x < Settings.BoardWidth; x++)
            {
                for (int y = 0; y < Settings.BoardHeight; y++)
                {
                    var tile = new Tile();
                    tile.Click += HandleTileClick;
                    tiles[x, y] = tile;

                    if ((x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1))
                    {
                        SetTileBackground(blackMarble, tile, ref blackMarbleImageOffset);
                    }
                    else
                    {
                        SetTileBackground(whiteMarble, tile, ref whiteMarbleImageOffset);
                    }
                }

                blackMarbleImageOffset.X += Settings.TileSize;
                if (blackMarbleImageOffset.X + Settings.TileSize > blackMarble.Width)
                {
                    blackMarbleImageOffset.X = 0;
                }

                whiteMarbleImageOffset.X += Settings.TileSize;
                if (whiteMarbleImageOffset.X + Settings.TileSize > whiteMarble.Width)
                {
                    whiteMarbleImageOffset.X = 0;
                }
            }

            // Set the starting positions; players occupy the middle 4 tiles:
            var middleX = Settings.BoardWidth / 2;
            var middleY = Settings.BoardHeight / 2;

            tiles[middleX, middleY].Occupy(players[0]);
            tiles[middleX - 1, middleY - 1].Occupy(players[0]);
            tiles[middleX - 1, middleY].Occupy(players[1]);
            tiles[middleX, middleY - 1].Occupy(players[1]);
        }


        /// <summary>
        /// Get a piece of the texture for the tile background. We don't want each tile to have the sae repeating
        /// background, so there is an offset from where we 'cut' a rectangle from the texture to use as background.
        /// </summary>
        /// <param name="texture">The texture to use (this is simply an image). </param>
        /// <param name="tile"> The tile to set the background for. </param>
        /// <param name="imageOffset"> The offset from where we want to 'cut out' a bit of the texture to use as image.</param>
        private void SetTileBackground(Image texture, Tile tile, ref Point imageOffset)
        {
            // Cut out a piece of the texture...
            Rectangle srcRect = new Rectangle(imageOffset.X, imageOffset.Y, Settings.TileSize, Settings.TileSize);
            Bitmap cropped = ((Bitmap)texture).Clone(srcRect, texture.PixelFormat);
            // ... and set as background
            tile.BackgroundImage = tile.originalBackground = cropped;

            // Now change the offset so the next tile gets a different piece of the image, so not all tiles are the same.
            imageOffset.Y += Settings.TileSize;
            if (imageOffset.Y + Settings.TileSize > texture.Height)
            {
                // Obviously we can't have an offset that is langer than the image so if this is the case we start at 0 again.
                imageOffset.Y = 0;
            }
        }

        /// <summary>
        /// A user clicked a tile. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleTileClick(object sender, EventArgs e)
        {
            var moveHandler = new MoveHandler(this.tiles, this.currentPlayer);

            if (moveHandler.HandleMove((Tile)sender))
            {
                // It was a valid move. Next player's turn.
                ShowInvalidClickMessage(false);
                EndTurn();
            }
            else
            {
                // It was not a valid move.
                ShowInvalidClickMessage(true);
            }
        }

        /// <summary>
        /// Next player's turn. 
        /// </summary>
        private void EndTurn()
        {
            currentPlayer.PlayerLabel.Font = new Font(currentPlayer.PlayerLabel.Font, FontStyle.Regular);

            currentPlayer = players.Next(players.IndexOf(currentPlayer));
            currentPlayer.PlayerLabel.Font = new Font(currentPlayer.PlayerLabel.Font, FontStyle.Bold);

            bool gameEnd = true;
            foreach(Tile tile in tiles)
            {
                if(tile.IsOccupied == false)
                {
                    gameEnd = false;
                }
            }

            if (gameEnd)
            {
                if(players.First().Points > currentPlayer.Points)
                {
                    System.Windows.Forms.MessageBox.Show(players.First().PlayerName + " wins!!!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(currentPlayer.PlayerName + " wins!!!");
                }
            }

            // Since the board has changed, we need to recalculate the help for the player who's turn it is now.
            DisplayHelp();
        }

        public void DisplayHelp()
        {
            var moveHandler = new MoveHandler(this.tiles, this.currentPlayer);
            bool validMoves = false;
            foreach (var tile in this.tiles)
            {                
                if (!tile.IsOccupied && ShowHelp && moveHandler.HandleMove(tile, false))
                {
                    validMoves = true;
                    tile.ToggleHelp(true);
                }
                else
                {
                    tile.ToggleHelp(false);
                }
            }

            if (validMoves == false && ShowHelp)
            {
                ShowNoMovesClickMessage(true);
                EndTurn();
            }
        }

        private void ShowInvalidClickMessage(bool displayMessage)
        {
            ShowMessage(this, new MessageEventArgs() { Message = "This is not a valid move.", DisplayMessage = displayMessage, IsError = true });
        }

        private void ShowNoMovesClickMessage(bool displayMessage)
        {
            ShowMessage(this, new MessageEventArgs() { Message = "No valid moves for " + currentPlayer.PlayerName, DisplayMessage = displayMessage, IsError = false });
        }
    }
}
