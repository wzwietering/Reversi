﻿using Reversi.Components;
using System.Collections.Generic;
using System.Drawing;

namespace Reversi.Helpers
{
    public class MoveHandler
    {
        public readonly Tile[,] tiles;
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
            if (clickedTile.IsOccupied)
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

                    // Flip all the flippable tiles (only if flipTilesIfValid was set to true).
                    if (flipTilesIfValid)
                    {
                        foreach (Tile tile in TilesToFlip)
                        {
                            FlipTile(tile, currentPlayer);
                        }

                        // Don't forget to also put a stone on the newly clicked tile
                        FlipTile(clickedTile, currentPlayer);
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
        public List<Tile> GetTilesToFlip(Tile tile)
        {
            List<Tile> flippableTiles = new List<Tile>();

            Point coordinates = GetTwoDimensionalIndex(tile);

            // we want to check all around the tile so we need to add a difference to
            // the coordinates ranging from -1 to 1.
            for (int dX = -1; dX <= 1; dX++)
            {
                for (int dY = -1; dY <= 1; dY++)
                {
                    // Difference of (0,0) is the same coordinates so we skip that.
                    if (!(dX == 0 && dY == 0))
                    {
                        flippableTiles.AddRange(GetTileRowToFlip(coordinates.X, coordinates.Y, dX, dY));
                    }
                }
            }

            return flippableTiles;
        }

        /// <summary>
        /// Get the row of tiles that can be flipped starting at coordinated x and y and moving along de coordinates
        /// with x + dX en y + dY (for example going to the right with dX = 1 and dY = 0).
        /// </summary>
        /// <returns>
        /// A list of tiles that can be flipped according to the rules of the game. If no tiles can be flipped; an empty list is returned.
        /// </returns>
        private IEnumerable<Tile> GetTileRowToFlip(int x, int y, int dX, int dY)
        {
            var tileList = new List<Tile>();

            // while(true) is very risky. Haven't rewritten this for lack of time. Should be a for loop using the dimensions of the board
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
                if (neighbour.IsOccupied && !neighbour.IsOccupiedBy(currentPlayer))
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

        /// <summary>
        /// Occupy the given tile by the given player. Substract and add points to players accordingly.
        /// </summary>
        /// <param name="tile">The tile to occupy </param>
        /// <param name="currentPlayer">The player that will occupy this tile. </param>
        private void FlipTile(Tile tile, Player currentPlayer)
        {
            if (tile.IsOccupied)
            {
                tile.Occupier.AddPoints(-1);
            }

            tile.Occupy(currentPlayer);

            currentPlayer.AddPoints(1);
        }

        /// <summary>
        /// Check if the given coordinates exist on the board
        /// </summary>
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

        /// <summary>
        /// Check the coordinates of a tile in the twodimensional array
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>The coordinates of the tile.</returns>
        private Point GetTwoDimensionalIndex(Tile tile)
        {
            for (int x = 0; x < tiles.GetLength(0); ++x)
            {
                for (int y = 0; y < tiles.GetLength(1); ++y)
                {
                    if (tiles[x, y].Equals(tile))
                    {
                        return new Point(x, y);
                    }
                }
            }
            // Tile wasn't found in the array
            return new Point(-1, -1);
        }
    }
}
