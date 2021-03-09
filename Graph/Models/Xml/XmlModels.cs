using System.Collections.Generic;
using System.Xml.Serialization;

namespace Models.Graph.Xml
{
    [XmlRoot(TreeBuilder.Root)]
    public class XmlTree
    {
        [XmlArray("tree")]
        [XmlArrayItem("node")]
        public List<XmlNode> Nodes { get; set; }
    }

    public class XmlNode
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("bond")]
        public string Bond { get; set; }

        [XmlIgnore]
        public List<int> Bonds { get; set; }
    }
}
