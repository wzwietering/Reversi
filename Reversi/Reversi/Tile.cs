using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Tile
    {
        private int x;
        private int y;

        private bool isOccupied;

        private string occupier;

        public void Occupy(string player)
        {
            this.isOccupied = true;
            occupier = player;
        }

        internal void SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
