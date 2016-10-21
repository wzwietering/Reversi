using System.Drawing;
using System.Windows.Forms;

namespace Reversi.Components
{
    /// <summary>
    /// Create a new player
    /// </summary>
    public class Player
    {
        // The color of the player's stones
        public Color Color { get; private set; }

        // Name of the player
        public string PlayerName { get; private set; }

        // The points the player has accumulated.
        public int Points { get; private set; }

        public Label PlayerLabel = new Label()
        {
            Size = new Size(140, 25),
            BackColor = Color.Gainsboro,
            BorderStyle = BorderStyle.FixedSingle
        };

        // Instantiate a new player.
        public Player()
        {
            setPlayerLabelText();
            PlayerLabel.Font = new Font("Calibri", 12);
        }

        // The following methods change the players' variables, and also update the player label accordingly.
        public void SetPlayerName(string name)
        {
            PlayerName = name;
            setPlayerLabelText();
        }

        public void AddPoints(int amount)
        {
            Points += amount;
            setPlayerLabelText();
        }

        public void SetColor(Color color)
        {
            this.Color = color;
            PlayerLabel.ForeColor = color;
        }

        public void setPlayerLabelText()
        {
            PlayerLabel.Text = PlayerName + ": " + Points + " points";
        }   
    }
}
