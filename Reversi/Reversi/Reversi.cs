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
            Tile.AddTile += new EventHandler(AddTile);
            StartGame();
        }

        public void StartGame()
        {
            currentGame = new Game();
            currentGame.Start();
        }

        private void DrawForm(object sender, PaintEventArgs e)
        {
            currentGame.Draw(e.Graphics);
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

        private void AddTile(object sender, EventArgs e)
        {
            this.Controls.Add((Tile)sender);
        }
    }
}
