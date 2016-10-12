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
            this.Paint += DrawBoard;
            Game.RedrawBoard += RedrawBoard;

            StartGame();
        }

        private void RedrawBoard(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public void StartGame()
        {
            currentGame = new Game();
            currentGame.Start();
        }

        private void DrawBoard(object sender, PaintEventArgs e)
        {
            for(int x = 0; x < currentGame.tiles.GetLength(0); x++)
            {
                for (int y = 0; y < currentGame.tiles.GetLength(1); y++)
                {
                    var tile = currentGame.tiles[x, y];
                    int offSetX = (((Form)sender).Width - Settings.TileSize * Settings.BoardWidth) / 2;
                    int offSetY = (((Form)sender).Height - Settings.TileSize * Settings.BoardHeight) / 2;

                    tile.Size = new Size(Settings.TileSize, Settings.TileSize);
                    tile.Location = new Point(x * Settings.TileSize + offSetX, y * Settings.TileSize + offSetY);
                    tile.BorderStyle = BorderStyle.FixedSingle;

                    if (tile.isOccupied)
                    {
                        tile.BackColor = tile.occupier.color;
                    }

                    this.Controls.Add(tile);
                }
            }
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
            var settingsGameMenu = new SettingsMenu(currentGame.players);
            settingsGameMenu.Show();
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        private void NewGame(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
