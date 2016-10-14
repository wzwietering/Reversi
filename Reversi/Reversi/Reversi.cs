using Reversi.Components;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Reversi : Form
    {
        Game currentGame;

        public Reversi()
        {
            InitializeComponent();
            StartGame();
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        private void NewGame(object sender, EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// The user can exit the application using the menu
        /// </summary>
        private void ExitGame(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ShowMessage(object sender, EventArgs e)
        {
            this.MessageBox.Visible = ((MessageEventArgs)e).DisplayMessage;
            if (this.MessageBox.Visible)
            {
                this.MessageBox.Text = ((MessageEventArgs)e).Message;
                this.MessageBox.ForeColor = ((MessageEventArgs)e).IsError ? Color.DarkRed : Color.Black;
            }
        }

        private void StartGame()
        {
            // First set visible to false, otherwise you see all controls slowly dissapearing
            this.currentGameContainer.Visible = false;
            this.currentGameContainer.Controls.Clear();

            currentGame = new Game();
            currentGame.Setup();
            DrawBoard();

            this.currentGameContainer.Visible = true;

            currentGame.ShowMessage += ShowMessage;
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
            int offSetY = currentGame.players.Count * 30 + 30;

            // Now draw all the tiles!
            for (int x = 0; x < currentGame.tiles.GetLength(0); x++)
            {
                for (int y = 0; y < currentGame.tiles.GetLength(1); y++)
                {
                    var tile = currentGame.tiles[x, y];
                    tile.Location = new Point(x * Settings.TileSize + offSetX, y * Settings.TileSize + offSetY);

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            currentGame.ShowHelp = ((CheckBox)sender).Checked;
            currentGame.DisplayHelp();
        }

        private void aboutMenu(object sender, EventArgs e)
        {
            AboutForm ab = new AboutForm();
            ab.Show();
        }
    }
}
