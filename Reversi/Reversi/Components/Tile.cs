using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Tile : UserControl
    {
        public bool isOccupied { get; private set; }

        public Player occupier { get; private set; }

        Image stone = Properties.Resources.reversiStoneLQ;

        public void Occupy(Player player)
        {
            if (this.isOccupied)
            {
                this.occupier.Points--;
            }
            this.BackgroundImageLayout = ImageLayout.Center;
            this.BackgroundImage = stone;

            this.isOccupied = true;
            occupier = player;

            this.BackColor = player.color;
            player.Points++;
        }

        public bool IsOccupiedBy(Player player)
        {
            return occupier == player;
        }
    }
}
