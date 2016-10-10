using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi
{
    class Game
    {
        private Tile[,] tiles;

        private List<Player> players { get; set; }

        private Player currentPlayer { get; set; }

        public Game()
        {
            tiles = new Tile[Settings.BoardWidth, Settings.BoardHeight];
            players = new List<Player>();
        }

        internal void Start()
        {
            for(int i = 1; i <= Settings.NumberOfPlayers; i++)
            {
                players.Add(new Player() { playerName = "player " + i });
            }

            currentPlayer = players.First();

            for(int x = 0; x <= Settings.BoardWidth; x++)
            {
                for (int y = 0; y <= Settings.BoardHeight; y++)
                {
                    var tile = new Tile();
                    tile.SetCoordinates(x, y);
                    tile.Click += HandleTileClick;
                    tiles[x, y] = tile;
                }
            }

            var middleX = Settings.BoardWidth / 2;
            var middleY = Settings.BoardHeight / 2;

            tiles[middleX, middleY].Occupy(players[0]);
            tiles[middleX + 1, middleY + 1].Occupy(players[0]);
            tiles[middleX + 1, middleY].Occupy(players[1]);
            tiles[middleX, middleY + 1].Occupy(players[1]);

            foreach(var tile in tiles)
            {
                tile.Draw();
            }
        }

        private void HandleTileClick(object sender, EventArgs e)
        {
            if (((Tile)sender).isOccupied)
            {
                return;
            }

        }
    }
}
