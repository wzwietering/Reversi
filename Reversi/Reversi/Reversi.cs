using System;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Reversi : Form
    {
        Game currentGame;

        public Reversi()
        {
            InitializeComponent();
            this.Paint += DrawForm;
            Tile.AddTile += AddTile;
            StartGame();
        }

        public void StartGame()
        {
            currentGame = new Game();
            currentGame.Start();
        }

        private void DrawForm(object sender, PaintEventArgs e)
        {
            currentGame.Draw(sender, e);
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
            var settingsGameMenu = new SettingsMenu();
            settingsGameMenu.Show();
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        private void NewGame(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Start();
        }

        private void AddTile(object sender, EventArgs e)
        {
            this.Controls.Add((Tile)sender);
        }
    }
}
