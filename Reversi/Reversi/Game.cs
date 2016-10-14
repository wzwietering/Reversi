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
            // Generate a tile for the width and height settings
            for (int x = 0; x < Settings.BoardWidth; x++)
            {
                for (int y = 0; y < Settings.BoardHeight; y++)
                {
                    var tile = new Tile();
                    tile.Click += HandleTileClick;
                    tiles[x, y] = tile;
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
                EndTurn();
            }
            else
            {
                // It was not a valid move.
                ShowInvalidClickMessage();
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

            // Since the board has changed, we need to recalculate the help for the player who's turn it is now.
            DoShowHelp();
        }

        public void DoShowHelp()
        {
            var moveHandler = new MoveHandler(this.tiles, this.currentPlayer);
            foreach (var tile in this.tiles)
            {
                if (!tile.IsOccupied && ShowHelp && moveHandler.HandleMove(tile, false))
                {
                //    tile.BackColor = Color.Gray;
                }
                else
                {
                //    tile.BackColor = Color.AntiqueWhite;
                }
            }
        }

        private void ShowInvalidClickMessage()
        {
          //  MessageBox.Show("This move is not valid!");
        }
    }
}
