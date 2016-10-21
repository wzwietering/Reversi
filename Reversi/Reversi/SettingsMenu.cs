using Reversi.Components;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reversi
{
    public partial class SettingsMenu : Form
    {
        public Player[] players;
        public Tile[,] tiles;

        public SettingsMenu(Player[] _players, Tile[,] _tiles)
        {
            players = _players;
            tiles = _tiles;
            PlayerOptions();
            InitializeComponent();
        }

        /// <summary>
        /// Show dialog to choose color, update color of tiles when changed
        /// </summary>
        private void ChooseColor(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            int name = Int32.Parse(((Button)sender).Name);
            if(result == DialogResult.OK)
            {
                players[name].Color = colorDialog.Color;
                for(int i = 0; i < tiles.GetLength(0); i++)
                {
                    for(int j = 0; j < tiles.GetLength(1); j++)
                    {
                        if(tiles[i, j].IsOccupied == true)
                        {
                            tiles[i, j].UpdateStone(tiles[i,j].Occupier);
                        }
                    }
                }
                players[name].PlayerLabel.ForeColor = colorDialog.Color;
            }
        }


        private void ChangePlayerName(object sender, EventArgs e)
        {
            int index = Int32.Parse(((TextBox)sender).Name);
            players[index].PlayerName = ((TextBox)sender).Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Settings.BoardHeight != (int)heightNUD.Value || Settings.BoardWidth != (int)widthNUD.Value)
            {
                Settings.BoardWidth = (int)widthNUD.Value;
                Settings.BoardHeight = (int)heightNUD.Value;
                MessageBox.Show("Changes to the board size will be applied when starting a new game.");
            }

            this.Close();
        }
    }
}
