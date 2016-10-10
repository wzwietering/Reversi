using System;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Reversi : Form
    {
        public Reversi()
        {
            InitializeComponent();
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

        private void NewGame(object sender, EventArgs e)
        {
            var newGameMenu = new NewGame();
            newGameMenu.Show();
        }
    }
}
