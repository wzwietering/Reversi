using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class GameModeForm : Form
    {
        private Game CurrentGame;

        public GameModeForm(Game game)
        {
            this.CurrentGame = game;
            InitializeComponent();
        }

        private void pvp_Click(object sender, EventArgs e)
        {
            CurrentGame.mode = GameMode.PlayervPlayer;
            this.Close();
        }

        private void pvc_Click(object sender, EventArgs e)
        {
            CurrentGame.mode = GameMode.PlayervAI;
            this.Close();
        }

        private void cvc_Click(object sender, EventArgs e)
        {
            CurrentGame.mode = GameMode.AIvAI;
            this.Close();
        }
    }
}
