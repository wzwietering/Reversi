using Reversi.Components;
using System.Drawing;
using System.Linq;

namespace Reversi.Helpers
{
    public static class PlayerSetupHelper
    {
        public static void SetupPlayers(Game game)
        {
            for (int i = 1; i <= Settings.NumberOfPlayers; i++)
            {
                var player = new Player();
                player.Points = 2;
                player.PlayerName = "Player " + i;
                player.Color = i == 1 ? Color.Blue : Color.Red;
                player.PlayerLabel.ForeColor = player.Color;
                player.PlayerLabel.Location = new Point(20, 30 * i);
                game.players.Add(player);
            }

            game.currentPlayer = game.players.First();
            game.currentPlayer.PlayerLabel.Text = '\u2022' + " " + game.currentPlayer.PlayerLabel.Text;
        }
    }
}
