using Reversi.Components;
using System.Collections.Generic;

namespace Reversi.ComponentsB
{
    public class MoveHandler
    {
        private readonly Tile[,] tiles;
        private readonly Player currentPlayer;

        /// <summary>
        /// Instantiate a new MoveHandler. 
        /// </summary>
        /// <param name="tiles">
        /// A reference to the tiles object of the game. Put this in a readonly field. We are not allowed to change
        /// the tiles, only to flip them!
        /// </param>
        /// <param name="currentPlayer">
        /// Same deal for the current player! We know who he is, thats all.
        /// </param>
        public MoveHandler(Tile[,] tiles, Player currentPlayer)
        {
            this.tiles = tiles;
            this.currentPlayer = currentPlayer;
        }

        /// <summary>
        /// Handle a tile click by a player.
        /// </summary>
        /// <param name="clickedTile"> The tile that was clicked. </param>
        /// <param name="currentPlayer"> The current player who made the move. </param>
        /// <param name="flipTilesIfValid"> If set to true, flip all flippable tiles if the move is valid. </param>
        /// <returns> true if the move is valid, otherwise false. </returns>
        public bool HandleMove(Tile clickedTile, bool flipTilesIfValid = true)
        {
            // Can't click on an occupied tile!
            if (clickedTile.isOccupied)
            {
                return false;
            }
            else
            {
                var TilesToFlip = GetTilesToFlip(clickedTile);
                if (TilesToFlip == null || TilesToFlip.Count == 0)
                {
                    // No tiles to flip, so the move is not valid.
                    return false;
                }
                else
                {
                    // Move is valid!

                    // Flip all the flippable tiles (only if this parameter was set).
                    if (flipTilesIfValid)
                    {
                        foreach (Tile tile in TilesToFlip)
                        {
                            tile.Occupy(currentPlayer);
                            (clickedTile).Occupy(currentPlayer);
                        }
                    }

                    return true;
                }
            }
        }

        /// <summary>
        /// Get all the tiles that can be flipped by clicking this tile.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
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
                var neighbour = this.tiles[x, y];

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
