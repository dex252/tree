using System.Collections.Generic;

namespace TreeNet.Models
{
    public class Way
    {
        public string LastNodeGuid { get; set; }

        public string LastNodeName { get; set; }

        public int Summ { get; set; }

        public List<Node> Path { get; set; } = new List<Node>();

        public Way()
        {

        }

        public Way(Way way)
        {
            LastNodeGuid = way.LastNodeGuid;
            LastNodeName = way.LastNodeName;
            Summ = way.Summ;
            Path = new List<Node>(way.Path);
        }
    }
}
