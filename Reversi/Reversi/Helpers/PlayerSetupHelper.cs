using Reversi.Components;
using System.Drawing;
using System.Linq;
using System;

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
            switch (game.mode)
            {
                case GameMode.PlayervPlayer:
                    AddHumanPlayer(game, 0);
                    AddHumanPlayer(game, 1);
                    break;
                case GameMode.PlayervAI:
                    AddHumanPlayer(game, 0);
                    AddAIPlayer(game, 1);
                    break;
                case GameMode.AIvAI:
                    AddAIPlayer(game, 0);
                    AddAIPlayer(game, 1);
                    break;
            }

            game.currentPlayer = game.players.First();
            game.currentPlayer.PlayerLabel.BackColor = Color.White;
        }

        private static void AddAIPlayer(Game game, int i)
        {
            var player = new AI("Computer " + (i + 1));
            Initialize(player, game, i);
        }

        private static void AddHumanPlayer(Game game, int i)
        {
            var player = new Player("Player " + (i + 1));
            Initialize(player, game, i);
        }

        /// <summary>
        /// Initialzes the settings
        /// </summary>
        /// <param name="player">The player to initialize</param>
        /// <param name="game">The game of the player</param>
        /// <param name="i">A variable to give different players different settings</param>
        public static void Initialize(Player player, Game game, int i)
        {
            // A player starts with two stones; thus two points.
            player.AddPoints(2);

            player.SetColor(i == 0 ? Color.Blue : Color.Red);

            player.PlayerLabel.Location = new Point(50 + 160 * i, 20);
            game.players[i] = (player);
        }
    }
}
