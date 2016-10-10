using System;
using System.Windows.Forms;

namespace Reversi
{
    public partial class SettingsMenu : Form
    {
        public SettingsMenu()
        {
            InitializeComponent();
        }

        private void saveSettings(object sender, EventArgs e)
        {
            Settings.BoardWidth = (int)widthNUD.Value;
            Settings.BoardHeight = (int)heightNUD.Value;
            this.Close();
        }
    }
}
