using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.AdvTree;

namespace Framework.Security.UI
{
    internal class CatalogNode
    {
        public CatalogNode(Node node)
        {
            TreeNode = node;
            node.Tag = this;
            Children = new List<FeatureNode>();
        }

        public Node TreeNode { get; private set; }

        public List<FeatureNode> Children { get; private set; }
    }
}
