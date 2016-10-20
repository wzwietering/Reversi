using Reversi.Components;
using System.Drawing;
using System.Linq;

namespace Reversi.Helpers
{
    public static class PlayerSetupHelper
    {
        /// <summary>
        /// Sets the players up by adding them to the game and setting their variables
        /// </summary>
        /// <param name="game">The game to add the player to</param>
        public static void SetupPlayers(Game game)
        {
            int humansAdded = 0;
            for (int i = 1; i <= Settings.NumberOfPlayers; i++)
            {
                if(game.humanPlayers > humansAdded && game.humanPlayers != 0)
                {
                    var player = new Player();
                    player.PlayerName = "Player " + i;
                    Initialize(player, game, i);
                    humansAdded++;
                }
                else
                {
                    var player = new AI();
                    player.PlayerName = "AI Player " + i;
                    Initialize(player, game, i);
                }
            }

            game.currentPlayer = game.players.First();
            game.currentPlayer.PlayerLabel.BackColor = Color.White;
        }

        /// <summary>
        /// Initialzes the settings
        /// </summary>
        /// <param name="player">The player to initialize</param>
        /// <param name="game">The game of the player</param>
        /// <param name="i">A variable to give different players different settings</param>
        public static void Initialize(Player player, Game game, int i)
        {
            player.Points = 2;
            player.Color = i == 1 ? Color.Blue : Color.Red;
            player.PlayerLabel.ForeColor = player.Color;
            player.PlayerLabel.Location = new Point(50 + 160 * (i - 1), 20);
            game.players.Add(player);
        }
    }
}
