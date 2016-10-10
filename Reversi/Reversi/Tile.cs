using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    class Tile : UserControl
    {
        private int x;
        private int y;

        public bool isOccupied;

        private Player occupier;

        public void Occupy(Player player)
        {
            this.isOccupied = true;
            occupier = player;
        }

        internal void SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
