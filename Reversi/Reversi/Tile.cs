using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    class Tile : UserControl
    {
        public int x;
        public int y;

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

        /// <summary>
        /// Creates a tile and an eventhandler to make the tile clickable
        /// </summary>
        public void Draw(Graphics graphics)
        {
            this.Size = new Size(Settings.TileSize, Settings.TileSize);
            this.Location = new Point(x * Settings.TileSize, y * Settings.TileSize);
           
            this.BackColor = Color.Black;
            this.Show();
            //   graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(x, y, Settings.TileSize, Settings.TileSize));
        }

        public bool IsOccupiedBy(Player player)
        {
            return occupier == player;
        }
    }
}
