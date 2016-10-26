using Reversi.Components;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Reversi.Helpers
{
    /// <summary>
    /// Nodes are used to creation relations between objects
    /// </summary>
    class Node
    {
        public Node parent;
        List<Node> children = new List<Node>();
        public Tile[,] tiles;
        public int score = 0;
        public Point position;

        /// <summary>
        /// Adds a child to the node
        /// </summary>
        public void AddChild(Point p)
        {
            children.Add(new Node());
            children.Last().parent = this;
            children.Last().position = p;
        }

        /// <summary>
        /// Returns the children
        /// </summary>
        /// <returns>A list of children</returns>
        public List<Node> GetChildren()
        {
            return children;
        }

        /// <summary>
        /// Used for getting the youngest child of the familiy
        /// </summary>
        /// <returns>The latest child</returns>
        public Node GetLastChild()
        {
            return children.Last();
        }
    }
}
