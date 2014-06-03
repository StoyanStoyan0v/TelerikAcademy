using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; set; }

        public bool HasParent { get; set; }

        public TreeNode()
        {
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
            : this()
        {
            this.Value = value;
        }

    }
}
