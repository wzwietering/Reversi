﻿using Reversi.Components;
using Reversi.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Reversi
{
    class Game
    {
        private Tile[,] tiles;

        public CircularList<Player> players { get; set; }

        private Player currentPlayer { get; set; }


        public static event EventHandler RedrawBoard;

        public Game()
        {
            tiles = new Tile[Settings.BoardWidth, Settings.BoardHeight];
            players = new CircularList<Player>();
        }

        /// <summary>
        /// Setup a new game (create the tiles, players, and startup scenario).
        /// </summary>
        internal void Start()
        {
            SetupPlayers();
            SetupTiles();
        }

        private void SetupPlayers()
        {
            for (int i = 1; i <= Settings.NumberOfPlayers; i++)
            {
                players.Add(new Player() { playerName = "player " + i, color = i == 1 ? Color.Blue : Color.Red });
            }

            currentPlayer = players.First();
        }

        private void SetupTiles()
        {
            // Generate a tile for the width and height settings
            for (int x = 0; x < Settings.BoardWidth; x++)
            {
                for (int y = 0; y < Settings.BoardHeight; y++)
                {
                    var tile = new Tile();
                    tile.SetCoordinates(x, y);
                    tile.Click += HandleTileClick;
                    tiles[x, y] = tile;
                }
            }

            // Set the starting positions; players occupy the middle 4 tiles:
            var middleX = Settings.BoardWidth / 2;
            var middleY = Settings.BoardHeight / 2;

            tiles[middleX, middleY].Occupy(players[0]);
            tiles[middleX - 1, middleY - 1].Occupy(players[0]);
            tiles[middleX - 1, middleY].Occupy(players[1]);
            tiles[middleX, middleY - 1].Occupy(players[1]);
        }

        /// <summary>
        /// Draw the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Draw(object sender, PaintEventArgs e)
        {
            foreach (var tile in tiles)
            {
                tile.Draw(sender, e);
            }
        }

        public void HandleTileClick(object sender, EventArgs e)
        {
            var moveHandler = new MoveHandler(this.tiles, this.currentPlayer);

            if (moveHandler.HandleMove((Tile)sender))
            {
                EndTurn();
            }
            else
            {
                ShowInvalidClickMessage();
            }
        }

        private void EndTurn()
        {
            currentPlayer = players.Next(players.IndexOf(currentPlayer));
            RedrawBoard(this, new EventArgs());
        }

        private void ShowInvalidClickMessage()
        {
            MessageBox.Show("This move is not valid!");
        }
    }
}
