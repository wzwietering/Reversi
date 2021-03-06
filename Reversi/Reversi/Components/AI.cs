﻿using Reversi.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Reversi.Components
{
    class AI : Player
    {
        public AI(string name) : base(name) { } 
         
        /// <summary>
        /// Calculates and executes the best move
        /// </summary>
        /// <param name="game">Contains all useful information for the AI</param>
        public void DoMove(Game game)
        {
            //Mainnode is the node which contains the gamestate before the AI starts.
            Node mainNode = new Node();
            Player currentPlayer = this;
            mainNode.tiles = game.tiles;

            //Create children of the mainnode, the contain possible moves.
            MakeChildren(mainNode, currentPlayer);

            //Determine which move is the best, and execute it.
            Node best = new Node();
            int boardsize = game.tiles.Length - 4;

            //Using a different strategy at the beginning of the game gives better results later on, this is a CPU friendly way to differ in stategies.
            if(game.turns < boardsize / 10)
            {
                best.score = 999;
                foreach(Node n in mainNode.GetChildren())
                {
                    //Only the absolute score matters, the weight is still important for strategy
                    if (n.score + GetWeight(n) < best.score) best = n;
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
                // Click the best tile!
                best.tiles[best.position.X, best.position.Y].ProgrammaticClick();
            }
        }

        /// <summary>
        /// The bedroom of the AI. It makes nodes, which have a possible game state.
        /// </summary>
        /// <param name="n">The node to give children to</param>
        /// <param name="currentPlayer">The player is used to check availability</param>
        private void MakeChildren(Node n, Player currentPlayer)
        {
            MoveHandler mh = new MoveHandler(n.tiles, currentPlayer);
            for (int i = 0; i < n.tiles.GetLength(0); i++)
            {
                for (int j = 0; j < n.tiles.GetLength(1); j++)
                {
                    bool possible = mh.HandleMove(n.tiles[i, j], false);
                    if (possible)
                    {
                        //The copy is used to simulate a move, without modifying the old game state
                        Tile[,] tilesCopy = n.tiles;
                        Point move = new Point(i, j);

                        //A child is created to save data about the simulation
                        n.AddChild(move);

                        //When the child is created, the scores are calculated.
                        Node baby = n.GetLastChild();

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
        }

        /// <summary>
        /// Returns the weight of a tile. The weight tells how important the tile is for the game strategy.
        /// </summary>
        /// <param name="node">The node to calculate the weight of.</param>
        /// <returns></returns>
        private int GetWeight(Node node)
        {
            int width = node.tiles.GetLength(0) - 1;
            int height = node.tiles.GetLength(1) - 1;
            int nodeX = node.position.X;
            int nodeY = node.position.Y;
            int weight = 4;
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
