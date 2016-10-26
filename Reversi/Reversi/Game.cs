using Reversi.Components;
using Reversi.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Reversi
{
    /// <summary>
    /// The game. A game object controls the current game logic (players, tiles, who wins, etc.).
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The tiles. They know who occupies them.
        /// </summary>
        public Tile[,] tiles;

        /// <summary>
        /// The players. There can only be two.
        /// </summary>
        public Player[] players = new Player[2];

        /// <summary>
        /// The player who's move it is. Reference to a player from the players array.
        /// </summary>
        public Player currentPlayer { get; set; }

        /// <summary>
        /// Set's whether the user wants hints to be displayed. If true; hints will be shown after each turn.
        /// </summary>
        public bool ShowHints { get; set; }

        public event EventHandler ShowMessage;

        /// <summary>
        /// The game mode. Can be player versus player or computer, or computer vs computer.
        /// </summary>
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
                HideInvalidClickMessage();
                turns++;
                EndTurn();
            }
            else
            {
                // It was not a valid move.
                ShowInvalidClickMessage();
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

                // If new current player is AI player, let him do a a move.
                if (currentPlayer.GetType() == typeof(AI)) ((AI)currentPlayer).DoMove(this);

                // Since the board has changed, we need to recalculate the help for the player who's turn it is now.
                else DisplayHints();
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
                    MessageBox.Show("It's a draw!");
                }
                else if (players[0].Points > players[1].Points)
                {
                    MessageBox.Show(players[0].PlayerName + " wins!");
                }
                else
                {
                    MessageBox.Show(players[1].PlayerName + " wins!");
                }
            }
            return gameEnd;
        }

        /// <summary>
        /// Show which moves can be made. Will be executed after each turn, or when user checks
        /// or unchecks the hints checkbox (which looks like a button).
        /// </summary>
        public void DisplayHints(bool checkBoxChanged = false)
        {
            if (checkBoxChanged || this.ShowHints)
            {
                var moveHandler = new MoveHandler(this.tiles, this.currentPlayer);
                bool validMoves = false;
                foreach (var tile in this.tiles)
                {
                    if (!tile.IsOccupied && ShowHints && moveHandler.HandleMove(tile, false))
                    {
                        validMoves = true;
                        tile.ToggleHelp(true);
                    }
                    else
                    {
                        tile.ToggleHelp(false);
                    }
                }

                if (validMoves == false && ShowHints)
                {
                    ShowNoMovesClickMessage(true);
                }
            }
        }

        private void HideInvalidClickMessage()
        {
            ShowMessage(this, new MessageEventArgs() { DisplayMessage = false });
        }

        private void ShowInvalidClickMessage()
        {
            ShowMessage(this, new MessageEventArgs() { Message = "This is not a valid move.", DisplayMessage = true, IsError = true });
        }

        private void ShowNoMovesClickMessage(bool displayMessage)
        {
            ShowMessage(this, new MessageEventArgs() { Message = "No valid moves for " + currentPlayer.PlayerName, DisplayMessage = displayMessage, IsError = false });
        }
    }
}
