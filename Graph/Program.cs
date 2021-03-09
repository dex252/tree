using Graph.Extensions;
using Graph.Models;
using Models.Graph.Xml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = TreeBuilder.GetTree("tree.xml");
            tree.Draw();

            var simpleTree = TreeBuilder.GetSimpleTree("tree.xml");
            var leafs = simpleTree.Where(e => e.Children.Count == 0).ToList();

            //Получить список новых деревьев, где каждый из листьев - корень
            var reverse = simpleTree.GetReverse(leafs);

            var path = reverse.GetAllPath();
            Console.ReadKey();
        }

    }
}
