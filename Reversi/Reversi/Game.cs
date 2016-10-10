using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Game
    {
        private List<Tile> tiles { get; set; }

        private List<Player> players { get; set; }

        public Game()
        {
            tiles = new List<Tile>();
            players = new List<Player>();
        }

        internal void Start()
        {
            for(int i = 1; i <= Settings.numberOfPlayers; i++)
            {
                players.Add(new Player() { playerName = "player " + i });
            }

            for(int x = 0; x <= Settings.boardWidth; x++)
            {
                for (int y = 0; y <= Settings.boardHeight; y++)
                {
                    var tile = new Tile();
                    tile.SetCoordinates(x, y);
                    tiles.Add(tile);
                }
            }
        }
    }
}
