using Reversi.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    // A tile (not to be confused with stone, which occupies a tile). Tiles form the board.
    public class Tile : UserControl
    {
        // We count subscribers to the paint event to be able to remove all of them again when help is turned off.
        // this fixes a problem of green borders that keep reappearing even when the tile is not green, due to multiple 
        // event subscriberss.
        private int PaintEventSubscribers;

        // true if this stone is occupied by a player
        public bool IsOccupied { get; private set; }

        // The occupying player
        public Player Occupier { get; private set; }

        // The stone control that is on this tile.
        private Stone reversiStone;

        // Original (black or white) background of the tile. Saves the texture when the tile is 
        // colored green in help mode. This way the tile can easily switch back to its original color without
        // having to create a new bitmap texture.
        public Bitmap originalBackground { get; set; }

        public Tile()
        {
            this.Size = new Size(Settings.TileSize, Settings.TileSize);
        }

        /// <summary>
        /// Occupies the tile and draws a reversi stone on it
        /// </summary>
        /// <param name="player"></param>
        public void Occupy(Player player)
        {
            // It hasn't been occupied yet, so we need to instantiate a new stone
            if (!IsOccupied)
            { 
                reversiStone = new Stone();
                this.Controls.Add(reversiStone);
            }
            
            // Now color the stone to the occupiers' color.
            UpdateStone(player);

            this.IsOccupied = true;
            Occupier = player;
        }

        public bool IsOccupiedBy(Player player)
        {
            return Occupier == player;
        }

        /// <summary>
        /// Updates the stone of the tile to the color of the player
        /// </summary>
        /// <param name="player"></param>
        public void UpdateStone(Player player)
        {
            reversiStone.BackgroundImage = ImageColorizer.ColorImage(Properties.Resources.reversiStoneLQ, player.Color);
            this.Refresh();
        }

        // Turn the tile green if showHelp = true. Otherwise, revert back to original color.
        public void ToggleHelp(bool showHelp)
        {
            // Show a nice green tile!
            if (showHelp)
            {
                // do a nice green border
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Paint += DrawBorder;
                PaintEventSubscribers++;

                // And make the tile green marble.
                Rectangle srcRect = new Rectangle(0, 0, Settings.TileSize, Settings.TileSize);
                Bitmap cropped = ((Bitmap)Properties.Resources.GreenMarble).Clone(srcRect, Properties.Resources.GreenMarble.PixelFormat);
                this.BackgroundImage = cropped;
            }
            // revert back to original tile color.
            else
            {
                // Remove all event subscribers!
                for (int i = 0; i < PaintEventSubscribers; i++)
                {
                    this.Paint -= DrawBorder;
                }

                this.BorderStyle = BorderStyle.None;
                this.BackgroundImage = this.originalBackground;
                Invalidate();
            }
        }

        private void DrawBorder(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.MediumSeaGreen, 2, ButtonBorderStyle.Solid,
                Color.MediumSeaGreen, 2, ButtonBorderStyle.Solid,
                Color.MediumSeaGreen, 2, ButtonBorderStyle.Solid,
                Color.MediumSeaGreen, 2, ButtonBorderStyle.Solid);
        }

        // Fire the clik event. Used for the AI to 'click' on tiles programaticall
        public void ProgrammaticClick()
        {
            base.OnClick(new System.EventArgs());
        }
    }
}
