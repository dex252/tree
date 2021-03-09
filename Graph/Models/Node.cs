using System;
using System.Collections.Generic;
namespace Graph.Models
{
    public class Node
    {

        public int Id { get; }

        public Node Parent { get; }

        public List<Node> Children { get; }


        public Node(int id, Node parent, List<Node> children = null)
        {
            Id = id;
            Parent = parent;
            Children = new List<Node>();

            if(children != null)
            {
                Children = new List<Node>(children);
            }
        }

        public Node(Node node)
        {
            Id = node.Id;
            Children = new List<Node>(node.Children);
        }

        public void Add(Node node)
        {
            Children.Add(node);
        }

        /// <summary>
        /// Отрисовать дерево в консоли
        /// </summary>
        public void Draw()
        {
            var space = CalculateSpaces(Parent, "");

            Console.Write(space);
            Console.Write(Id);

            if (Children.Count > 0)
            {
                Console.Write("--");
                Console.WriteLine();
                space = CalculateSpaces(Parent, "  ");
                Console.Write(space);
                Console.Write(" |");
            }


            Console.WriteLine();
            foreach (var child in Children)
            {
                child.Draw();
            }
        }

        private string CalculateSpaces(Node parent, string space)
        {
            if(parent != null)
            {
                space += "   ";
                space = CalculateSpaces(parent.Parent, space);
            }

            return space;
        }
    }
}
