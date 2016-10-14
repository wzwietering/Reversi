using Reversi.Components;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reversi
{
    public partial class SettingsMenu : Form
    {
        public List<Player> players;
        public Tile[,] tiles;

        public SettingsMenu(List<Player> list, Tile[,] array)
        {
            players = list;
            tiles = array;
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
            }
        }
    }
}
