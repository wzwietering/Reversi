using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    public class Player
    {
        public Player()
        {
            setPlayerLabel();
            PlayerLabel.Font = new Font("Calibri", 12);
        }

        private string playerName;
        private int points;

        public Label PlayerLabel = new Label()
        {
            Size = new Size(140, 25),
            BackColor = Color.Gainsboro,
            BorderStyle = BorderStyle.FixedSingle
        };

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

        public void setPlayerLabel()
        {
            PlayerLabel.Text = playerName + ": " + points + " points";
        }

   
    }
}
