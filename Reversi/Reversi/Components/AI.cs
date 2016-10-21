using Reversi.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace Reversi.Components
{
    class AI : Player
    {
        /// <summary>
        /// Calculates the best move
        /// </summary>
        /// <param name="tiles">Using tiles</param>
        /// <param name="players">A list of players</param>
        /// <param name="currentPlayer">And the current player</param>
        public override void DoMove(Tile[,] tiles, CircularList<Player> players, Player currentPlayer, Game game)
        {
            //Mainnode is the node which contains the gamestate before the AI starts.
            MoveHandler mh = new MoveHandler(tiles, this);
            Node mainNode = new Node();
            mainNode.tiles = tiles;
            mainNode.parent = null;
            int moves = 0;

            for(int i = 0; i < tiles.GetLength(0); i++)
            {
                for(int j = 0; j < tiles.GetLength(1); j++)
                {
                    bool possible = mh.HandleMove(tiles[i, j], false);
                    if (possible)
                    {
                        //The copy is used to simulate a move, without modifying the old game state
                        Tile[,] tilesCopy = tiles;
                        Point move = new Point(i, j);
                        moves++;

                        //A child is created to save data about the simulation
                        mainNode.AddChild(move);

                        //When the child is created, the scores are calculated.
                        Node baby = mainNode.GetLastChild();

                        //Over here you can find a simulation of the future
                        MoveHandler mh2 = new MoveHandler(tilesCopy, currentPlayer);
                        List<Tile> flippables = mh2.GetTilesToFlip(tilesCopy[i, j]);
                        baby.score += flippables.Count;

                        //The baby gets the simulated game state to play with.
                        baby.tiles = mh2.tiles;
                        baby.score += GetWeight(baby);
                    }
                }
            }

            //Determine which move is the best, and execute it.
            Node best = new Node();
            int boardsize = tiles.Length;

            //Using a different strategy at the beginning of the game gives better results later on
            if(game.turns < boardsize / 10)
            {
                best.score = 999;
                foreach(Node n in mainNode.GetChildren())
                {
                    if (n.score < best.score) best = n;
                }
            }
            else
            {
                best.score = -999;
                foreach (Node n in mainNode.GetChildren())
                {
                    if (n.score > best.score) best = n;
                }
            }
            

            //No move possible means pass
            if(mainNode.GetChildren().Count == 0)
            {
                game.EndTurn();
            }
            else
            {
                mh.HandleMove(best.tiles[best.position.X, best.position.Y]);
                game.EndTurn();
            }
        }

        /// <summary>
        /// Returns the weight of a tile. The weight tells how important the tile is for the game strategy.
        /// </summary>
        /// <param name="node">The node to calculate the weight of.</param>
        /// <returns></returns>
        private int GetWeight(Node node)
        {
            int width = node.tiles.GetLength(0);
            int height = node.tiles.GetLength(1);
            int nodeX = node.position.X;
            int nodeY = node.position.Y;
            int weight = 3;
            int antiweight = -3;

            //This code checks the occupation of corners and edges
            if (nodeX == 0 || nodeX == width)
            {
                if (nodeY == 0 || nodeY == height) return (weight * 3);
                else if (nodeY == 1 || nodeY == height - 1) return (weight * antiweight);
                else return weight;
            }
            else if (nodeX == 1 || nodeX == width - 1)
            {
                if (nodeY == 0 || nodeY == height) return (weight * antiweight);
                else if (nodeY == 1 || nodeY == height - 1) return (weight * antiweight);
                else return weight;
            }
            else return 0;
        }
    }
}
