using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAlgorithmsLibrary.DataStructures
{
    /// <summary>
    /// Несбалансированное бинарное дерево поиска
    /// </summary>
    public class BinaryTree
    {
        private Node root;
        public BinaryTree()
        {
            root = null;
        }

        public void Add(int value)
        {
            Add(ref root, value);
        }

        /// <summary>
        /// Добавляет элемент в бинарное дерево начиная с данного поддерева
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private void Add(ref Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                if (value != root.value)
                {
                    if (value > root.value)
                    {
                        Add(ref root.right, value);
                    }
                    else if (value < root.value)
                    {
                        Add(ref root.left, value);
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает минимальный элемент в дереве, больший или равный value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Next(int value) //Ok
        {
            int min = -1;
            return Next(root, value, ref min);
        }

        private int Next(Node root, int value, ref int min)
        {
			if (root == null)
			{
				return min;
			}

			if (value < root.value)
            {
                min = root.value;
                return Next(root.left, value, ref min);
            }
            
            else if (value > root.value)
            {
                return Next(root.right, value, ref min);
            }

			else
			{
				return value;
			}
		}

        public int Min()
        {
            return Min(root);
        }

        private int Min(Node node)
        {
            node = root;
            while (node.left != null)
            {
                node = node.left;
			} 
            return node.value;
        }

        public bool Contains(int value)
        {
            return Contains(root, value);
        }

        private bool Contains(Node node, int value)
        {
            if (node == null)
            {
                return false;
            }
            else
            {
                if (node.value == value) return true;
                else if (value < node.value) return Contains(node.left, value);
                else return Contains(node.right, value);
            }
        }

        public void Print()
        {
            Print(root);
        }

        private void Print(Node root)
        {
            if (root != null)
            {
                Print(root.left);
                Console.WriteLine(root.value);
                Print(root.right);
            }
        }
    }

    /// <summary>
    /// Узел дерева
    /// </summary>
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }
}
