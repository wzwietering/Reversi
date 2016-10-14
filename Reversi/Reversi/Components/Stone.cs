using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi.Components
{
    class Stone : UserControl
    {
        public Stone()
        {
            this.Size = new System.Drawing.Size(Settings.TileSize, Settings.TileSize);
            this.BackgroundImageLayout = ImageLayout.Center;
            this.BackColor = Color.Transparent;
        }
    }
}
