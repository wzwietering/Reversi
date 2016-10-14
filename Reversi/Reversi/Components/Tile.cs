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

            ImageColorizer ic = new ImageColorizer();
            reversiStone.BackgroundImage = ic.ColorImage(Properties.Resources.reversiStoneLQ, player.color);
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
            this.BackgroundImageLayout = ImageLayout.Center;
            ImageColorizer ic = new ImageColorizer();
            this.BackgroundImage = ic.ColorImage(stone, player.color);
        }
    }
}
