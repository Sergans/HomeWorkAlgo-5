using System;

namespace Task_5_1
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode LefttChild { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Root { get; set; }

        public void AddItem(int value)
        {

            if (Root == null)
            {
                TreeNode root = new TreeNode { Value = value };
                Root = root;
            }
           
            else
            {
                Add(Root, value);
            }

        }
        public void Add(TreeNode node, int value)
        {
            TreeNode next = new TreeNode { Value = value };
            if (node.Value > value)
            {
                
                if (node.LefttChild == null)
                {
                    node.LefttChild = next;
                    next.Parent = node;
                }
                else
                {
                    
                    Add(node.LefttChild, value);
                }
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = next;
                    next.Parent = node;
                }
                else
                {
                    
                    Add(node.RightChild, value);
                }


            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 8, 6, 10, 5, 7, 9, 11 };
            TreeNode node = new TreeNode();
            for (int i = 0; i < arr.Length; i++)
            {
                node.AddItem(arr[i]);

            }

           
        }
    }
}
