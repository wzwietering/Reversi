﻿using Reversi.Components;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi
{
    /// <summary>
    /// The reversi window. Handles all the controls and user settings and starting of a new game.
    /// </summary>
    public partial class ReversiWindow : Form
    {
        Game currentGame;

        public ReversiWindow()
        {
            InitializeComponent();
            NewGame();
        }

        /// <summary>
        /// Handles user click on new game and starts a new game.
        /// </summary>
        private void NewGame_Clicked(object sender, EventArgs e)
        {
            NewGame();
        }

        /// <summary>
        /// The user can exit the application using the menu
        /// </summary>
        private void ExitGame(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This subscribes to the ShowMessage event. It displays a message to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessage(object sender, EventArgs e)
        {
            if (((MessageEventArgs)e).DisplayMessage)
            {
                this.AlertMessage.Text = ((MessageEventArgs)e).Message;
                this.AlertMessage.ForeColor = ((MessageEventArgs)e).IsError ? Color.DarkRed : Color.Black;
                this.AlertMessage.Location = new Point(this.Width / 2 - AlertMessage.Width / 2, 80 );
                this.AlertMessage.Visible = true;
            }
            else { this.AlertMessage.Visible = false; }
        }

        /// <summary>
        /// Start a new game!
        /// </summary>
        private void NewGame()
        {
            // First set visible to false, otherwise you see all controls slowly dissapearing
            this.currentGameContainer.Visible = false;
            this.currentGameContainer.Controls.Clear();

            // Create a new game.
            currentGame = new Game();
            currentGame.ShowMessage += ShowMessage;

            // Let the user choose the game mode first.
            var gameModeForm = new GameModeForm(currentGame);
            gameModeForm.ShowDialog();

            // Now we have the game mode, we can setup all components.
            currentGame.Setup();
            DrawBoard();

            this.currentGameContainer.Visible = true;

            // If the first player is an AI player (when game mode is AI v AI) we need to get the ball rolling
            // by letting the first player do a move.
            if(currentGame.currentPlayer.GetType() == typeof(AI))
            {
                ((AI)currentGame.currentPlayer).DoMove(currentGame);
            }
        }

        /// <summary>
        /// Draw the board for a game of reversi.
        /// </summary>
        private void DrawBoard()
        {
            // Show the labels to display the points for each player
            foreach (var player in currentGame.players)
            {
                this.currentGameContainer.Controls.Add(player.PlayerLabel);
            }

            // Calculate offset for the tiles (we want them nicely in the center
            int offSetX = (this.Width - Settings.TileSize * Settings.BoardWidth) / 2;

            // Now draw all the tiles!
            for (int x = 0; x < currentGame.tiles.GetLength(0); x++)
            {
                for (int y = 0; y < currentGame.tiles.GetLength(1); y++)
                {
                    var tile = currentGame.tiles[x, y];
                    tile.Location = new Point(x * Settings.TileSize + offSetX, y * Settings.TileSize + 90);

                    this.currentGameContainer.Controls.Add(tile);
                }
            }
        }

        /// <summary>
        /// Shows a settings menu
        /// </summary>
        private void SettingsMenu(object sender, EventArgs e)
        {
            var settingsGameMenu = new SettingsMenu(currentGame.players, currentGame.tiles);
            settingsGameMenu.Show();
        }

        // the user wants a hint...
        private void hintButton_CheckedChanged(object sender, EventArgs e)
        {
            currentGame.ShowHints = ((CheckBox)sender).Checked;
            currentGame.DisplayHints(true);
        }

        private void aboutMenu(object sender, EventArgs e)
        {
            AboutForm ab = new AboutForm();
            ab.Show();
        }

        private void PassTurn(object sender, EventArgs e)
        {
            currentGame.EndTurn();
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Use your mouse to place colored stones on the board. 
You may place a stone anywhere on the board, as long as it surrounds a group of your opponent's stones on opposite sides. 
You can surround stones horizontally, vertically, or diagonally. 
After you place your stone, any stones that you surrounded will flip over to your color. 

If you need help, you can click the 'hint' button to see which moves are available to you.
Try to end the game with as many stones of your color as possible!");
        }
    }
}
