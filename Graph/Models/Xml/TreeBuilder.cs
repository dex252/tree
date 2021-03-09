using Graph.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Models.Graph.Xml
{
    public class TreeBuilder
    {
        internal const string Root = "root";

        /// <summary>
        /// Получить готовое дерево на основе xml
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Node GetTree(string fileName)
        {
            var text = ReadText(fileName);
            var source = ReadByXml<XmlTree>(text);
            PrepareToBuild(source);
            var tree = BuildTree(source);

            return tree;
        }

        public static List<SimpleNode> GetSimpleTree(string fileName)
        {
            var text = ReadText(fileName);
            var source = ReadByXml<XmlTree>(text);
            PrepareToBuild(source);
            var tree = BuildSimpleTree(source);

            return tree;
        }

        private static List<SimpleNode> BuildSimpleTree(XmlTree source)
        {
            //Ищем все вершины, у которых нет родителей и имеются дети
            var detached = source.Nodes.Where(e => {
                var parents = source.Nodes.Where(q => q.Bonds.Contains(e.Id));
                if (parents.Count() == 0)
                {
                    return true;
                }

                return false;
            }).Where(e => e.Bonds.Count() > 0);

            if (detached.Count() != 1)
            {
                throw new Exception("Корень дерева не найден, задано более одного дерева или вершины дерева зациклены");
            }

            //Задаем корень
            var root = detached.FirstOrDefault();
            var simpleRoot = new SimpleNode(root.Id, null);
            foreach (var bond in root.Bonds)
            {
                simpleRoot.Add(bond);
            }

            var simpleTree = new List<SimpleNode>();
            simpleTree.Add(simpleRoot);

            AddSimpleChildren(simpleRoot, simpleTree, source);

            return simpleTree;
        }

        private static void AddSimpleChildren(SimpleNode sourceNode, List<SimpleNode> simpleTree, XmlTree source)
        {
            foreach (var id in sourceNode.Children)
            {
                var node = source.Nodes.FirstOrDefault(e => e.Id == id);
                var simpleNode = new SimpleNode(id, sourceNode.Id);
                foreach (var bond in node.Bonds)
                {
                    simpleNode.Add(bond);
                }
                simpleTree.Add(simpleNode);

                AddSimpleChildren(simpleNode, simpleTree, source);
            }
        }

        private static Node BuildTree(XmlTree source)
        {
            //Ищем все вершины, у которых нет родителей и имеются дети
            var detached = source.Nodes.Where(e => {
                var parents = source.Nodes.Where(q => q.Bonds.Contains(e.Id));
                if (parents.Count() == 0)
                {
                    return true;
                }

                return false;
            }).Where(e => e.Bonds.Count() > 0);

            if(detached.Count() != 1)
            {
                throw new Exception("Корень дерева не найден, задано более одного дерева или вершины дерева зациклены");
            }

            //Задаем корень
            var root = detached.FirstOrDefault();
            var node = new Node(root.Id, null);

            AddChildren(node, source);

            return node;
        }

        /// <summary>
        /// Рекурсивно заполняем дерево
        /// </summary>
        /// <param name="node"></param>
        /// <param name="source"></param>
        private static void AddChildren(Node node, XmlTree source)
        {
            var bonds = source.Nodes.FirstOrDefault(e => e.Id == node.Id).Bonds;
            foreach (var id in bonds)
            {
                var child = new Node(id, node);
                AddChildren(child, source);
                node.Add(child);
            }
        }

        private static void PrepareToBuild(XmlTree source)
        {
            var hash = new HashSet<string>();
            var count = source.Nodes.Count();
            source.Nodes.ForEach(e => {

                if (string.IsNullOrWhiteSpace(e.Bond))
                {
                    e.Bonds = new List<int>();
                    return;
                }

                e.Bonds = e.Bond.Trim()
                                  .Split(' ')
                                  .Select(e => 
                                  {
                                      if (hash.Contains(e))
                                      {
                                          throw new Exception($"Вершина {e} имеет более, чем одного родителя");
                                      }

                                      hash.Add(e);
                                      return Convert.ToInt32(e);
                                  })
                                  .ToList();
            });
        }

        private static string ReadText(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetManifestResourceNames().FirstOrDefault(e => e.EndsWith(resourceName));

            if (assemblyName == null)
            {
                throw new Exception($"Файл {resourceName} не найден");
            }

            using (var stream = assembly.GetManifestResourceStream(assemblyName))
            using (var reader = new StreamReader(stream))
            {
                var text = reader.ReadToEnd();
                return text;
            }
        }

        private static T ReadByXml<T>(string xml) 
            where T:class
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                throw new Exception($"Ошибка десириализации, передана пустая строка");
            }

            var document = new XmlDocument();
            document.LoadXml(xml);


            var response = document.DocumentElement.SelectSingleNode($"//{Root}");

            if (response == null)
            {
                throw new Exception($"Ошибка десириализации, не удалось найти корень xml: {Root}");
            }

            var outerXml = response.OuterXml;

            if (string.IsNullOrEmpty(outerXml))
            {
                throw new Exception($"Ошибка десириализации, корневой элемент пуст");
            }

            using (var stream = new StringReader(outerXml))
            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(XmlTree));
                var isSerializeable = serializer.CanDeserialize(reader);

                if (!isSerializeable)
                {
                    throw new Exception($"Ошибка десириализации, xml не соответствует заявленной модели");
                }

                var obj = serializer.Deserialize(reader);
                var result = obj as T;

                return result;
            }
        }
    }
}
