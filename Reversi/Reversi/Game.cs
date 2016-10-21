using Reversi.Components;
using Reversi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi
{
    public class Game
    {
        public Tile[,] tiles;

        public Player[] players = new Player[2];

        public Player currentPlayer { get; set; }

        public bool ShowHelp { get; set; }

        public event EventHandler ShowMessage;

        public int humanPlayers = 1;

        public GameMode mode = GameMode.PlayervAI;

        public int turns = 0;

        public Game()
        {
            tiles = new Tile[Settings.BoardWidth, Settings.BoardHeight];
        }

        /// <summary>
        /// Setup a new game (create the tiles, players, and startup scenario).
        /// </summary>
        internal void Setup()
        {
            turns = 0;
            PlayerSetupHelper.SetupPlayers(this);
            TileSetupHelper.SetupTiles(this);
        }

        /// <summary>
        /// A user clicked a tile. 
        /// </summary>
        public void HandleTileClick(object sender, EventArgs e)
        {
            var moveHandler = new MoveHandler(this.tiles, this.currentPlayer);

            if (moveHandler.HandleMove((Tile)sender))
            {
                // It was a valid move. Next player's turn.
                ShowInvalidClickMessage(false);
                EndTurn();
            }
            else
            {
                // It was not a valid move.
                ShowInvalidClickMessage(true);
            }
        }

        /// <summary>
        /// Next player's turn. 
        /// </summary>
        public void EndTurn()
        {
            if (!GameHasEnded())
            {
                currentPlayer.PlayerLabel.BackColor = System.Drawing.Color.Gainsboro;

                // Set new current player according to the index(if 0; then 1; if 1; then 0)
                currentPlayer = players[Array.IndexOf(players, currentPlayer) == 0 ? 1 : 0];
                currentPlayer.PlayerLabel.BackColor = System.Drawing.Color.White;

                if (currentPlayer.GetType() == typeof(AI)) ((AI)currentPlayer).DoMove(tiles, players, currentPlayer, this);
                turns++;

                // Since the board has changed, we need to recalculate the help for the player who's turn it is now.
                DisplayHelp();
            }
        }

        /// <summary>
        /// Check if the game has ended.
        /// </summary>
        /// <returns>True if the game has ended.</returns>
        private bool GameHasEnded()
        {
            bool gameEnd = true;

            // If every tile is occupied, the game has finished.
            foreach (Tile tile in tiles)
            {
                if (tile.IsOccupied == false)
                {
                    gameEnd = false;
                }
            }

            // If a player has 0 points that means he has 0 tiles, and cannot do a move anymore.
            if (players.Any(x => x.Points == 0))
            {
                gameEnd = true;
            }

            if (gameEnd)
            {
                if (players[0].Points == players[1].Points)
                {
                    System.Windows.Forms.MessageBox.Show("It's a draw!");
                }
                else if (players[0].Points > players[1].Points)
                {
                    System.Windows.Forms.MessageBox.Show(players[0].PlayerName + " wins!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(players[1].PlayerName + " wins!");
                }
            }
            return gameEnd;
        }

        /// <summary>
        /// Show which moves can be made.
        /// </summary>
        public void DisplayHelp(bool checkBoxChanged = false)
        {
            if (checkBoxChanged || ShowHelp)
            {
                var moveHandler = new MoveHandler(this.tiles, this.currentPlayer);
                bool validMoves = false;
                foreach (var tile in this.tiles)
                {
                    if (!tile.IsOccupied && ShowHelp && moveHandler.HandleMove(tile, false))
                    {
                        validMoves = true;
                        tile.ToggleHelp(true);
                    }
                    else
                    {
                        tile.ToggleHelp(false);
                    }
                }

                if (validMoves == false && ShowHelp)
                {
                    ShowNoMovesClickMessage(true);
                }
            }
        }

        private void ShowInvalidClickMessage(bool displayMessage)
        {
            ShowMessage(this, new MessageEventArgs() { Message = "This is not a valid move.", DisplayMessage = displayMessage, IsError = true });
        }

        private void ShowNoMovesClickMessage(bool displayMessage)
        {
            ShowMessage(this, new MessageEventArgs() { Message = "No valid moves for " + currentPlayer.PlayerName, DisplayMessage = displayMessage, IsError = false });
        }
    }
}
