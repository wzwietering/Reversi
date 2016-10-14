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

        public void Occupy(Player player)
        {
            if (!IsOccupied)
            { 
                reversiStone = new Stone();
                this.Controls.Add(reversiStone);
            }

            ImageColorizer ic = new ImageColorizer();
            reversiStone.BackgroundImage = ic.ColorImage(Properties.Resources.reversiStoneLQ, player.color);

            this.IsOccupied = true;
            Occupier = player;
        }

        public bool IsOccupiedBy(Player player)
        {
            return Occupier == player;
        }
    }
}
