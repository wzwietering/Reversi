using Reversi.Components;
using System.Drawing;

namespace Reversi.Helpers
{
    /// <summary>
    /// This class sets up the tiles. It gives them all a nice texture and a size and position
    /// so they will be nicely rendered onto the board.
    /// </summary>
    public static class TileSetupHelper
    {
        public static void SetupTiles(Game game)
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
                    tile.Click += game.HandleTileClick;
                    game.tiles[x, y] = tile;

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

            game.tiles[middleX, middleY].Occupy(game.players[0]);
            game.tiles[middleX - 1, middleY - 1].Occupy(game.players[0]);
            game.tiles[middleX - 1, middleY].Occupy(game.players[1]);
            game.tiles[middleX, middleY - 1].Occupy(game.players[1]);
        }


        /// <summary>
        /// Get a piece of the texture for the tile background. We don't want each tile to have the sae repeating
        /// background, so there is an offset from where we 'cut' a rectangle from the texture to use as background.
        /// </summary>
        /// <param name="texture">The texture to use (this is simply an image). </param>
        /// <param name="tile"> The tile to set the background for. </param>
        /// <param name="imageOffset"> The offset from where we want to 'cut out' a bit of the texture to use as image.</param>
        private static void SetTileBackground(Image texture, Tile tile, ref Point imageOffset)
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
    }
}
