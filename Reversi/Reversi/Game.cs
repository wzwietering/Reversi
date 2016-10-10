using System;
using System.Collections.Generic;

namespace Reversi
{
    class Game
    {
    //    private List<Tile> tiles { get; set; }

        private Tile[,] tiles;

        private List<Player> players { get; set; }

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

            for(int x = 0; x < Settings.BoardWidth; x++)
            {
                for (int y = 0; y < Settings.BoardHeight; y++)
                {
                    var tile = new Tile();
                    tile.SetCoordinates(x, y);
                    tile.Click += HandleTileClick;
                    tiles[x, y] = tile;
                }
            }
        }

        private void HandleTileClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
