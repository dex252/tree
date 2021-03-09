using Graph.Models;
using System;
using System.Collections.Generic;

namespace Graph.Extensions
{
    public static class TreeExtension
    {
        public static List<List<string>> GetPath(this Node n, List<int> leafs)
        {

            var node = new Node(n);
            var path = new List<List<string>>();
            //найти пути между всеми парами листьев в дереве
            leafs.ForEach(a => {
                leafs.ForEach(b =>
                {
                    if (a == b)
                    {
                        return;
                    }

                    var way = node.Dist(a, b);
                    path.Add(way);
                });
            });

            return path;
        }


        /// <summary>
        /// Найти путь из точки a в точку b
        /// </summary>
        /// <param name="node"></param>
        /// <param name="a"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static List<string> Dist(this Node n, int a, int b)
        {
            var node = new Node(n);
            var search = node.Search(a);
            var reverse = search.Reverse();
            var way = search.GetWay(b);

            return way;
        }

        private static List<string> GetWay(this Node n, int b)
        {
            throw new NotImplementedException();
        }

        private static Node Reverse(this Node n)
        {
            throw new NotImplementedException();
        }

        private static Node Search(this Node n, int a)
        {
            if(n.Id == a)
            {
                return n;
            }

            foreach (var child in n.Children)
            {
                var node = child.Search(a);
                if(node != null)
                {
                    return node;
                }
            }

            return null;
        }

        /// <summary>
        /// Получить список id листьев дерева
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public static List<int> GetLeafs(this Node n, bool isShow = true)
        {
            var node = new Node(n);
            var leafs = new List<int>();

            FillLeaf(node, leafs);

            if (isShow)
            {
                Console.WriteLine($"\nЛистья: {string.Join(' ', leafs)}");
            }

            return leafs;
        }

        private static void FillLeaf(Node node, List<int> leafs)
        {
            if (node.Children.Count == 0)
            {
                leafs.Add(node.Id);
                return;
            }

            foreach (var child in node.Children)
            {
                FillLeaf(child, leafs);
            }

        }


    }
}
