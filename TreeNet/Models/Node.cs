using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TreeNet.ViewModels;

namespace TreeNet.Models
{
    public class Node: TreeNode
    {
        public int Weight { get; set; }

        public float Layer { get; set; }

        public PointF Point { get; set; }

        public int Position { get; set; }

        public List<Way> MaxWay { get; set; }

        public List<Way> MinWay { get; set; }

        public Node(string text, int weight, bool isRoot = false): base(text)
        {
            Weight = weight;
            Name = System.Guid.NewGuid().ToString();

            if (isRoot)
            {
                Layer = 1;
                Position = 1;
                Point = new PointF(Tree.STEEP, Tree.STEEP);
            }

        }

        public void AddNode(string text, int weight)
        {
            var node = new Node(text, weight);
           
            Nodes.Add(node);

            var parent = node.Parent as Node;
            node.Layer = parent.Layer + 1;
        }

        public void RemoveNode(string key)
        {
            if(Parent == null)
            {
                return;
            }

            Parent.Nodes.RemoveByKey(key);
        }

        public void UpdatePosition(int position)
        {
            Position = position;

            var y = Layer * Tree.STEEP;
            var x = position * Tree.STEEP;
            Point = new PointF(x , y);
        }
    }
}
