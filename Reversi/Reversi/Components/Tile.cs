using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Tile : UserControl
    {
        public bool isOccupied;

        public Player occupier;

        public void Occupy(Player player)
        {
            if (this.isOccupied)
            {
                this.occupier.points--;
            }
            this.isOccupied = true;
            occupier = player;
            player.points++;
        }

        public bool IsOccupiedBy(Player player)
        {
            return occupier == player;
        }
    }
}
