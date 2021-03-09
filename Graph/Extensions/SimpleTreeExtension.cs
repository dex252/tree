using Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Extensions
{
    public static class SimpleTreeExtension
    {
        public static List<SimpleNode> GetLeafs(this List<SimpleNode> list)
        {
            return list.Where(e=>e.Children.Count == 0).ToList();
        }

        /// <summary>
        /// Получить список новых деревьев с корнями в листьях
        /// </summary>
        /// <param name="list"></param>
        /// <param name="leafs"></param>
        /// <returns></returns>
        public static List<List<SimpleNode>> GetReverse(this List<SimpleNode> list, List<SimpleNode> leafs)
        {
            var source = new List<SimpleNode>(list);
            var reversed = new List<List<SimpleNode>>();

            foreach (var leaf in leafs)
            {
                var reverse = new List<SimpleNode>();
                var root = new SimpleNode(leaf.Id, null);
                root.Add(leaf.Parent);

                reverse.Add(root);

                NextLeaf(source, ref reverse, root, leaf.Parent);
                reversed.Add(reverse);
            }

            return reversed;
        }
        public static List<List<int?>> GetAllPath(this List<List<SimpleNode>> reverse)
        {
            var result = new List<List<int?>>();
            foreach (var tree in reverse)
            {
                var paths = AllPoints(tree);  
               
             
            }



            return result;

            List<List<int?>> AllPoints(List<SimpleNode> tree)
            {
                var paths = new List<List<int?>>();

                int? parent = null;
                var way = new List<int?>();
                Next(tree, parent, way);

                return paths;

                List<int?> Way()
                {
                    var way = new List<int?>();
                    return way;
                }
            }


        }

        private static void Next(List<SimpleNode> tree, int? parent, List<int?> way)
        {
            var node = tree.FirstOrDefault(e => e.Parent == parent);
            foreach (var child in node.Children)
            {
               
                way.Add(node.Id);
            }
        }

        private static void NextLeaf(List<SimpleNode> source, ref List<SimpleNode> reverse, SimpleNode parent, int? current)
        {
            var currentNode = source.FirstOrDefault(e => e.Id == current);
            var oldParent = currentNode.Parent;

            var node = new SimpleNode(Convert.ToInt32(current), parent.Id);

            var bonds = currentNode.Children.Where(e => e != parent.Id);
            foreach (var bond in bonds)
            {
                node.Add(bond);
                var child = source.FirstOrDefault(e => e.Id == bond);
            }

            reverse.Add(node);

            if (oldParent != null)
            {
                node.Add(oldParent);
                NextLeaf(source, ref reverse, node, oldParent);
            }
            else
            {
                FillOriginal(source, ref reverse);
            }

        }

        private static void FillOriginal(List<SimpleNode> source, ref List<SimpleNode> reverse)
        {
            foreach (var r in reverse)
            {
                source = source.Where(e => e.Id != r.Id).ToList();
            }

            foreach (var node in source)
            {
                reverse.Add(node);
            }
            
        }

    }
}
