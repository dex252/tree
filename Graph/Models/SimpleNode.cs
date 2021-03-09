using System;
using System.Collections.Generic;

namespace Graph.Models
{
    public class SimpleNode
    {
        public int? Id { get; }

        public int? Parent { get; }

        public List<int?> Children { get; }

        public SimpleNode(int? id, int? parent)
        {
            Id = id;
            Parent = parent;
            Children = new List<int?>();
        }

        public void Add(int? id)
        {
            Children.Add(id);
        }
    }
}
