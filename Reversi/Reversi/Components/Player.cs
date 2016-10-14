using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Player
    {
        public Player()
        {
            setPlayerLabel();
        }

        private string playerName;
        private int points;

        public Label PlayerLabel = new Label() { Size = new Size(200, 30) };
        public Color Color;

        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
                setPlayerLabel();
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
                setPlayerLabel();
            }
        }

        private void setPlayerLabel()
        {
            PlayerLabel.Text = playerName + ": " + points + " points";
        }
    }
}
