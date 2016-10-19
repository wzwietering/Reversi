using Reversi.Components;
using Reversi.Helpers;
using System;
using System.Drawing;
using System.Linq;

namespace Reversi
{
    public class Game
    {
        public Tile[,] tiles;

        public CircularList<Player> players { get; set; }

        public Player currentPlayer { get; set; }

        public bool ShowHelp { get; set; }

        public event EventHandler ShowMessage;

        public Game()
        {
            tiles = new Tile[Settings.BoardWidth, Settings.BoardHeight];
            players = new CircularList<Player>();
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
            currentPlayer = players.Next(players.IndexOf(currentPlayer));
            currentPlayer.PlayerLabel.Text = '\u2022' + " " + currentPlayer.PlayerLabel.Text;

            bool gameEnd = true;
            foreach(Tile tile in tiles)
            {
                if(tile.IsOccupied == false)
                {
                    gameEnd = false;
                }
            }

            if (gameEnd)
            {
                if(players.First().Points > currentPlayer.Points)
                {
                    System.Windows.Forms.MessageBox.Show(players.First().PlayerName + " wins!!!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(currentPlayer.PlayerName + " wins!!!");
                }
            }

            // Since the board has changed, we need to recalculate the help for the player who's turn it is now.
            DisplayHelp();
        }

        public void DisplayHelp()
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
