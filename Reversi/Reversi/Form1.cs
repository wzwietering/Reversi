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

        private void SettingsMenu(object sender, EventArgs e)
        {
            var settingsGameMenu = new SettingsMenu();
            settingsGameMenu.Show();
        }

        private void NewGame(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
