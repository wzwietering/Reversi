using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi
{
    class Tile : UserControl
    {
        public int x;
        public int y;

        public bool isOccupied;

        private Player occupier;

        /// <summary>
        /// Needs to be static so the Reversi class can subscribe to this event without having a tile object.
        /// </summary>
        public static event EventHandler AddTile;

        public void Occupy(Player player)
        {
            this.isOccupied = true;
            occupier = player;
            player.points++;
        }

        public bool IsOccupiedBy(Player player)
        {
            return occupier == player;
        }

        internal void SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Creates a tile and throws the addTile event so the form can add the tile to it's controls.
        /// </summary>
        public void Draw(object sender, PaintEventArgs e)
        {
            int offSetX = (((Form)sender).Width - Settings.TileSize * Settings.BoardWidth) / 2;
            int offSetY = (((Form)sender).Height - Settings.TileSize * Settings.BoardHeight) / 2;

            this.Size = new Size(Settings.TileSize, Settings.TileSize);
            this.Location = new Point(x * Settings.TileSize + offSetX, y * Settings.TileSize + offSetY);
            this.BorderStyle = BorderStyle.FixedSingle;

            AddTile(this, new EventArgs());
        }
    }
}
