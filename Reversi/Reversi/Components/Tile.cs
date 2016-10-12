using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Tile : UserControl
    {
        public bool IsOccupied { get; private set; }

        public Player Occupier { get; private set; }

        Image stone = Properties.Resources.reversiStoneLQ;

        public Tile()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.AntiqueWhite;
            this.Size = new Size(Settings.TileSize, Settings.TileSize);
        }

        public void Occupy(Player player)
        {
            this.BackgroundImageLayout = ImageLayout.Center;
            this.BackgroundImage = stone;

            this.IsOccupied = true;
            Occupier = player;

            this.BackColor = player.color;
        }

        public bool IsOccupiedBy(Player player)
        {
            return Occupier == player;
        }
    }
}
