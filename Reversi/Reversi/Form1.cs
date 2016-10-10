using System;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Reversi : Form
    {
        public Reversi()
        {
            InitializeComponent();
            Game game = new Game();
            game.Start();
        }

        public void StartGame()
        {
            Game game = new Game();
            game.Graphics = this.CreateGraphics();
            game.Start();
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
    }
}
