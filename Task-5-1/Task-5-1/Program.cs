using System;
using System.Collections.Generic;

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
        public static void BFS(TreeNode node,int value)
        {
            
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


                }

            }

        }
        public static void DFS(TreeNode node, int value)
        {
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
                }

            }

        }
        static void Main(string[] args)
        {
            int[] arr = { 8, 6, 10, 7,5, 9, 11 };
            TreeNode node = new TreeNode();
            for (int i = 0; i < arr.Length; i++)
            {
                node.AddItem(arr[i]);

            }
            
            
            BFS(node, 11);
            Console.WriteLine();
            DFS(node, 11);


            //var qItemOne = queue.Dequeue();
            //var qItemTwo = queue.Dequeue();
            //Console.WriteLine($"{qItemOne},  {qItemTwo} ");

            //var stack = new Stack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            //stack.Push(5);
            //while (stack.Count > 0)
            //{
            //    var sItemOne = stack.Pop();
            //    Console.WriteLine($"{sItemOne} ");


        }
    }
}
