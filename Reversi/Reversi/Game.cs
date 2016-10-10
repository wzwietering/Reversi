using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Reversi
{
    class Game
    {
        private Tile[,] tiles;

        private List<Player> players { get; set; }

        private Player currentPlayer { get; set; }
        public Graphics Graphics { get; internal set; }

        public Game()
        {
            tiles = new Tile[Settings.BoardWidth, Settings.BoardHeight];
            players = new List<Player>();
        }

        /// <summary>
        /// Setup a new game (create the tiles, players, and startup scenario).
        /// </summary>
        internal void Start()
        {
            for (int i = 1; i <= Settings.NumberOfPlayers; i++)
            {
                players.Add(new Player() { playerName = "player " + i });
            }

            currentPlayer = players.First();

            for (int x = 0; x < Settings.BoardWidth; x++)
            {
                for (int y = 0; y < Settings.BoardHeight; y++)
                {
                    var tile = new Tile();
                    tile.SetCoordinates(x, y);
                    tile.Click += HandleTileClick;
                    tiles[x, y] = tile;
                }
            }

            var middleX = Settings.BoardWidth / 2;
            var middleY = Settings.BoardHeight / 2;

            tiles[middleX, middleY].Occupy(players[0]);
            tiles[middleX + 1, middleY + 1].Occupy(players[0]);
            tiles[middleX + 1, middleY].Occupy(players[1]);
            tiles[middleX, middleY + 1].Occupy(players[1]);
        }

        /// <summary>
        /// Draw the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Draw(object sender, PaintEventArgs e)
        {
            foreach (var tile in tiles)
            {
                tile.Draw(sender, e);
            }
        }

        public void HandleTileClick(object sender, EventArgs e)
        {
            if (((Tile)sender).isOccupied)
            {
                ShowInvalidClickMessage();
            }
            else
            {
                var TilesToFlip = GetTilesToFlip((Tile)sender);
                if (TilesToFlip == null || TilesToFlip.Count == 0)
                {
                    ShowInvalidClickMessage();
                }
                else
                {
                    foreach (Tile tile in TilesToFlip)
                    {
                        tile.Occupy(currentPlayer);
                    }

                    EndTurn();
                }
            }
        }

        private void EndTurn()
        {
            int currentplayerIndex = players.IndexOf(currentPlayer);
            currentPlayer = players[currentplayerIndex++];
        }

        private void ShowInvalidClickMessage()
        {
            throw new NotImplementedException();
        }

        private List<Tile> GetTilesToFlip(Tile tile)
        {
            // Check to see if we can use IndexOf() to eliminate public coordinates in the tile
            // (and have them set to private only for use in the draw() method)

            List<Tile> flippableTiles = new List<Tile>();

            for (int dX = -1; dX <= 1; dX++)
            {
                for (int dY = -1; dY <= 1; dY++)
                {
                    if (!(dX == 0 && dY == 0))
                    {
                        flippableTiles.AddRange(GetTileRowToFlip(tile.x, tile.y, dX, dY));
                    }
                }
            }

            return flippableTiles;
        }

        private IEnumerable<Tile> GetTileRowToFlip(int x, int y, int dX, int dY)
        {
            var tileList = new List<Tile>();

            while (true)
            {
                x = x + dX;
                y = y + dY;

                if (!WithinRange(x, y))
                {
                    // We are no longer in range of the board, so nothing to flip. return null.
                    return new List<Tile>();
                }

                // This is our next neighbouring tile.
                var neighbour = tiles[x, y];

                // Is it occupied by someone else than the current player? Add it to the tile list
                if (neighbour.isOccupied && !neighbour.IsOccupiedBy(currentPlayer))
                {
                    tileList.Add(neighbour);
                }
                // Is it occupied by th current player? return the list (which will be emtpy if this was the first tile we encountered.
                else if (neighbour.IsOccupiedBy(currentPlayer))
                {
                    return tileList;
                }
                // Tile must be unoccupied, so nothing to flip. return null.
                else
                {
                    return new List<Tile>();
                }
            }
        }

        private bool WithinRange(int x, int y)
        {
            if (x < 0 || x == Settings.BoardWidth || y < 0 || y == Settings.BoardHeight)
            {
                // We've met the edge of the board. 
                return false;
            }
            //We are still in range.
            return true;
        }
    }
}
