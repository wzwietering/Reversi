﻿using Reversi.Components;
using System;
using System.Windows.Forms;

namespace Reversi
{
    /// <summary>
    /// This is the settings form. A user can change the player names, colors and the board size.
    /// Changes to the board size will be applied when user starts a new game, not immediately.
    /// </summary>
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
            int index = Int32.Parse(((Button)sender).Name);
            if(result == DialogResult.OK)
            {
                players[index].SetColor(colorDialog.Color);

                if (index == 0) Settings.player1Color = colorDialog.Color;
                else Settings.player2Color = colorDialog.Color;

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

        /// <summary>
        /// Change the name of a player. This handler is subscribed to the textchanged event of the player name textboxes.
        /// </summary>
        /// <param name="sender">The textbox in which the text was changed </param>
        /// <param name="e"></param>
        private void ChangePlayerName(object sender, EventArgs e)
        {
            int index = Int32.Parse(((TextBox)sender).Name);
            players[index].SetPlayerName(((TextBox)sender).Text);
        }

        /// <summary>
        /// User clicked the ok button. We won't apply board size settings immediately, because it will start a new game
        /// and the user might not want that to happen. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
