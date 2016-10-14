using Reversi.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Tile : UserControl
    {
        public bool IsOccupied { get; private set; }

        public Player Occupier { get; private set; }

        private Stone reversiStone { get; set; }

        public Bitmap originalBackground { get; set; }

        public Tile()
        {
            this.Size = new Size(Settings.TileSize, Settings.TileSize);
        }

        /// <summary>
        /// Occupies the stone and draws the texture
        /// </summary>
        /// <param name="player"></param>
        public void Occupy(Player player)
        {
            if (!IsOccupied)
            { 
                reversiStone = new Stone();
                this.Controls.Add(reversiStone);
            }
            
            UpdateStone(player);

            this.IsOccupied = true;
            Occupier = player;
        }

        public bool IsOccupiedBy(Player player)
        {
            return Occupier == player;
        }

        /// <summary>
        /// Updates the stone of the tile
        /// </summary>
        /// <param name="player"></param>
        public void UpdateStone(Player player)
        {
            ImageColorizer ic = new ImageColorizer();
            reversiStone.BackgroundImage = ic.ColorImage(Properties.Resources.reversiStoneLQ, player.Color);
        }

        public void ToggleHelp(bool showHelp)
        {
            if (showHelp)
            {
                this.Paint += DrawBorder;
                Rectangle srcRect = new Rectangle(300, 300, Settings.TileSize, Settings.TileSize);
                Bitmap cropped = ((Bitmap)Properties.Resources.GreenMarble).Clone(srcRect, Properties.Resources.GreenMarble.PixelFormat);
                this.BackgroundImage = cropped;
            }
            else
            {
                this.Paint -= DrawBorder;
                this.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.BackgroundImage = this.originalBackground;
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
    }
}
