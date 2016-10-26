using Reversi.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Tile : UserControl
    {
        private int PaintEventSubscribers;

        public bool IsOccupied { get; private set; }

        public Player Occupier { get; private set; }

        private Stone reversiStone;

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

        public void ToggleHelp(bool showHelp)
        {
            if (showHelp)
            {
                this.Paint += DrawBorder;
                PaintEventSubscribers++;
                this.BorderStyle = BorderStyle.FixedSingle;
                Rectangle srcRect = new Rectangle(0, 0, Settings.TileSize, Settings.TileSize);
                Bitmap cropped = ((Bitmap)Properties.Resources.GreenMarble).Clone(srcRect, Properties.Resources.GreenMarble.PixelFormat);
                this.BackgroundImage = cropped;
            }
            else
            {
                for (int i = 0; i < PaintEventSubscribers; i++)
                {
                    this.Paint -= DrawBorder;
                }

                this.BorderStyle = System.Windows.Forms.BorderStyle.None;
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

        public void ProgrammaticClick()
        {
            base.OnClick(new System.EventArgs());
        }
    }
}
