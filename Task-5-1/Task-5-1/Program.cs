using System;
using System.Collections.Generic;

namespace Task_5_1
{
    public class TestCase
    {
       
       public int[] stepbfs { get; set; }
       public int[] stepdfs { get; set; }
        
    }

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
        public static List<int> BFS(TreeNode node,int value)
        {
            List<int> bfs = new List<int>();//для теста
            int step = 0;
            var queue = new Queue<TreeNode>();
            var root = node.Root;
            var a = root;
            queue.Enqueue(root);
            
            while (queue.Count != 0)
            {
                step++;

                if (queue.Peek().Value == value)
                {

                    Console.WriteLine($"Шаг {step}. узел значение-{queue.Peek().Value}. Найдено {value}");
                    a = queue.Peek();
                    
                    break;

                }
                else
                {
                    if (queue.Peek().LefttChild != null)
                    {
                        queue.Enqueue(queue.Peek().LefttChild);
                    }
                    if (queue.Peek().RightChild != null)
                    {
                        queue.Enqueue(queue.Peek().RightChild);
                    }


                    a=queue.Dequeue();

                    Console.WriteLine($"Шаг {step}. узел значение-{a.Value}. не найдено");
                    bfs.Add(a.Value);

                }

            }
            return bfs;
        }
        public static List<int> DFS(TreeNode node, int value)
        {
            List<int> dfs = new List<int>();//для теста
            int step = 0;
            var stack = new Stack<TreeNode>();
            var root = node.Root;
            stack.Push(root);
            var a=root;
            while (stack.Count != 0)
            {
                step++;
                if (stack.Peek().Value == value)
                {

                    Console.WriteLine($"Шаг {step}. узел значение-{stack.Peek().Value}. Найдено {value}");
                    
                    break;
                }
                else
                {
                    if (stack.Peek().LefttChild != null)
                    {
                        a = stack.Peek();
                        stack.Push(stack.Peek().LefttChild);
                       
                    }
                    else
                    {
                        if (stack.Peek().RightChild != null)
                        {
                            a = stack.Peek();
                            stack.Push(stack.Peek().RightChild);
                            
                        }
                        else
                        {
                            if(stack.Peek().LefttChild == null)
                            {
                                stack.Peek().Parent.LefttChild = null;
                               a= stack.Pop();
                                if (stack.Count != 0)
                                {
                                    stack.Push(stack.Pop().RightChild);
                                }
                                
                            }
                         
                        }

                    }

                    Console.WriteLine($"Шаг {step}. узел значение-{a.Value}. не найдено");
                    dfs.Add(a.Value);
                }

            }
            return dfs;
        }
        public static void TestStep(int[]arr,TestCase testCase)
        {
            int search = 0;
            bool y = true;
            bool n = true;
            
            TreeNode node = new TreeNode();
            for (int i = 0; i < arr.Length; i++)
            {
                node.AddItem(arr[i]);

            }
            var bfs = BFS(node, search);
            var dfs = DFS(node, search);
            Console.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                if (testCase.stepbfs[i] == bfs[i])
                {
                    y = true;
                }
                else
                {
                    n = false;

                }
                if (testCase.stepdfs[i] == dfs[i])
                {
                    y = true;
                }
                else
                {
                    n = false;

                }

            }
            if (y==n)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }

        }
        static void Main(string[] args)
        {
            int[] arr = { 8, 6, 10, 7,5, 9, 11 };
            TreeNode node = new TreeNode();

            TestCase testCase = new TestCase();
            testCase.stepbfs = new[] { 8, 6, 10, 5, 7, 9, 11 };//тестовая последовательность BFS
            testCase.stepdfs = new[] { 8, 6, 5, 7, 10, 9, 11 };//тестовая последовательность DFS
            TestStep(arr, testCase);
            for (int i = 0; i < arr.Length; i++)
            {
                node.AddItem(arr[i]);

            }
            BFS(node, 11);
            Console.WriteLine();
            DFS(node, 11);


        }
    }
}
