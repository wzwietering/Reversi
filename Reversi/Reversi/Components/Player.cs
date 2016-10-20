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

        public virtual void DoMove(Tile[,] tiles, CircularList<Player> players, Player currentPlayer, Game game)
        {
            //Only used in the AI, humans use a mouse to move, so this is empty
        }
    }
}
