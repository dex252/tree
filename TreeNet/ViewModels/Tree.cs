using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TreeNet.Models;

namespace TreeNet.ViewModels
{
    public class Tree
    {
        public const string ROOT = "Root";

        public const float STEEP = 20;

        public const float NODE_SIZE = 10;

        public Node Root { get; set; }

        private List<Node> AllNodes { get; set; }

        public Tree()
        {
            Root = new Node(ROOT, 1, true);
        }

        public void DrawTree(Graphics canvas)
        {
            var nodePen = new Pen(Color.Blue);
            var bondPen = new Pen(Color.Gray);

            var nodes = GetAllNodes();

            foreach (var node in nodes)
            {
                canvas.DrawEllipse(nodePen, node.Point.X, node.Point.Y, NODE_SIZE, NODE_SIZE);

                if (node.Parent == null) continue;

                var parent = node.Parent as Node;
                canvas.DrawLine(bondPen, parent.Point, new PointF(node.Point.X, parent.Point.Y));
                canvas.DrawLine(bondPen, node.Point, new PointF(node.Point.X, parent.Point.Y));
            }
        }

        private List<Node> GetAllNodes()
        {
            var nodes = new List<Node>();
            var index = 1;
            nodes.Add(Root);

            AddChilds(nodes, Root.Nodes, ref index);

            AllNodes = nodes;
            return nodes;
        }

        private void AddChilds(List<Node> collection, TreeNodeCollection nodes, ref int index)
        {
            if (nodes == null || nodes.Count == 0)
            {
                return;
            }

            foreach (var next in nodes)
            {
                var node = next as Node;

                index++;
                node.UpdatePosition(index);

                collection.Add(node);
                AddChilds(collection, node.Nodes, ref index);
            }
        }

        public void CalculateAll()
        {
            foreach (var node in AllNodes)
            {
                Calculate(node);
            }
        }

        private void Calculate(Node node)
        {
            var ways = new Dictionary<string, Way>(AllNodes.Count);

            //Добавим себя самого, чтобы исключить повтора на родителях
            ways.Add(node.Name, null);

            //Пробег по детям
            foreach (var n in node.Nodes)
            {
                var child = n as Node;

                var way = new Way();

                way.Path.Add(child);
                way.LastNodeGuid = child.Name;
                way.LastNodeName = child.Text;
                way.Summ += child.Weight;

                ways.TryAdd(way.LastNodeGuid, way);
                CalculateChilds(child, ways);
            }

            //Если есть родитель - бежит по нему и его детям
            if (node.Parent != null)
            {
                var parent = node.Parent as Node;
                var pWay = new Way();
                pWay.Path.Add(parent);
                pWay.LastNodeGuid = parent.Name;
                pWay.LastNodeName = parent.Text;
                pWay.Summ += parent.Weight;
                ways.TryAdd(pWay.LastNodeGuid, pWay);

                CalculateParents(parent, ways);
            }

            System.Console.WriteLine(ways);

            //Удаляем себя
            ways.Remove(node.Name);

            //Вычислим наибольшее и наименьшее расстояния
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var way in ways)
            {
                if (way.Value.Summ == max)
                {
                    node.MaxWay.Add(way.Value);
                }

                if (way.Value.Summ > max)
                {
                    max = way.Value.Summ;
                    node.MaxWay = new List<Way>() 
                    {
                        way.Value
                    };
                }

                if (way.Value.Summ == min)
                {
                    node.MinWay.Add(way.Value);
                }

                if (way.Value.Summ < min)
                {
                    min = way.Value.Summ;
                    node.MinWay = new List<Way>()
                    {
                        way.Value
                    };
                }
            }
        }

        private void CalculateParents(Node node, Dictionary<string, Way> ways)
        {
            foreach (var n in node.Nodes)
            {
                var child = n as Node;

                if (ways.ContainsKey(child.Name))
                {
                    continue;
                }

                var parent = child.Parent as Node;
                var way = new Way();

                if (ways.ContainsKey(parent.Name))
                {
                    ways.TryGetValue(parent.Name, out var value);
                    way = new Way(value);
                }

                way.Path.Add(child);
                way.LastNodeGuid = child.Name;
                way.LastNodeName = child.Text;
                way.Summ += child.Weight;

                ways.TryAdd(way.LastNodeGuid, way);
                CalculateChilds(child, ways);
            }

            if (node.Parent != null)
            {
                var parent = node.Parent as Node;
                ways.TryGetValue(node.Name, out var value);

                var pWay = new Way(value);
                pWay.Path.Add(parent);
                pWay.LastNodeGuid = parent.Name;
                pWay.LastNodeName = parent.Text;
                pWay.Summ += parent.Weight;

                ways.TryAdd(pWay.LastNodeGuid, pWay);
                CalculateParents(parent, ways);
            }
        }

        private void CalculateChilds(Node node, Dictionary<string, Way> ways)
        {
            foreach (var n in node.Nodes)
            {
                var child = n as Node;
                var parent = child.Parent as Node;
                var way = new Way();

                if (ways.ContainsKey(parent.Name))
                {
                    ways.TryGetValue(parent.Name, out var value);
                    way = new Way(value);
                }

                way.Path.Add(child);
                way.LastNodeGuid = child.Name;
                way.LastNodeName = child.Text;
                way.Summ += child.Weight;

                ways.TryAdd(way.LastNodeGuid, way);
                CalculateChilds(child, ways);
            }
        }
    }
}
