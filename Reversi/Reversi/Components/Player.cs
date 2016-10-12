using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Player
    {
        public string playerName;

        public Color color;

        private int points;

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
                playerLabel.Text = playerName + ": " + points + " points";
            }
        }

        public Label playerLabel = new Label() { Size = new Size(200, 30)};
    }
}
