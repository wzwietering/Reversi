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
            SetupGame();
            DrawBoard();
        }

        /// <summary>
        /// Draw all the components for a game of reversi.
        /// </summary>
        private void DrawBoard()
        {
            // Show the labels to display the points for each player
            foreach (var player in currentGame.players)
            {
                this.Controls.Add(player.playerLabel);
            }

            // Calculate offset for the tiles (we want them nicely in the center
            int offSetX = (this.Width - Settings.TileSize * Settings.BoardWidth) / 2;
            int offSetY = (this.Height - Settings.TileSize * Settings.BoardHeight) / 2 + (currentGame.players.Count * 30);

            // Now draw all the tiles!
            for (int x = 0; x < currentGame.tiles.GetLength(0); x++)
            {
                for (int y = 0; y < currentGame.tiles.GetLength(1); y++)
                {
                    var tile = currentGame.tiles[x, y];
                    tile.Location = new Point(x * Settings.TileSize + offSetX, y * Settings.TileSize + offSetY);

                    this.Controls.Add(tile);
                }
            }
        }

        private void RedrawBoard(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public void SetupGame()
        {
            currentGame = new Game();
            currentGame.Setup();
        }

        /// <summary>
        /// The user can exit the application using the menu
        /// </summary>
        private void ExitGame(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Shows a settings menu
        /// </summary>
        private void SettingsMenu(object sender, EventArgs e)
        {
            var settingsGameMenu = new SettingsMenu(currentGame.players, currentGame.tiles);
            settingsGameMenu.Show();
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        private void NewGame(object sender, EventArgs e)
        {
            SetupGame();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            currentGame.ShowHelp = ((CheckBox)sender).Checked;
            currentGame.DoShowHelp();
        }

        private void aboutMenu(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }
    }
}
