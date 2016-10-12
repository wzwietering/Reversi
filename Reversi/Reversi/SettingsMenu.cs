using Reversi.Components;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reversi
{
    public partial class SettingsMenu : Form
    {
        public List<Player> players;

        public SettingsMenu(List<Player> list)
        {
            players = list;
            ColorOptions();
            InitializeComponent();
        }

        private void saveSettings(object sender, EventArgs e)
        {
            Settings.BoardWidth = (int)widthNUD.Value;
            Settings.BoardHeight = (int)heightNUD.Value;
        }

        private void chooseColor(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            int name = Int32.Parse(((Button)sender).Name);
            if(result == DialogResult.OK)
            {
                players[name].color = colorDialog.Color;
            }
        }
    }
}
