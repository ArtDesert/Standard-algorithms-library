using System;
using System.Collections.Generic;

namespace StandardAlgorithmsLibrary.DataStructures
{
    public class Pair
    {
        public int Value { get; set; }
        public int Min { get; set; }

        public Pair(int value, int min)
        {
            Value = value;
            Min = min;
        }
    }

    /// <summary>
    /// Стек с эффективным возвратом 
    /// </summary>
    public class SortedStack
    {
        public Stack<Pair> stack;
        public int Count { get { return stack.Count; } }

        public SortedStack()
        {
            stack = new Stack<Pair>();
        }

        /// <summary>
        /// Добавляет элемент в голову стека за О(1)
        /// </summary>
        /// <param name="value"></param>
        public void Push(int value) 
        {
            if (stack.Count == 0) stack.Push(new Pair(value, value));
            else
            {
                int min = Math.Min(stack.Peek().Min, value);
                stack.Push(new Pair(value, min));
            }
        }

        /// <summary>
        /// Удаляет элемент из верхушки стека за О(1)
        /// </summary>
        /// <returns></returns>
        public int Pop() 
        {
            return stack.Pop().Value;
        }

        /// <summary>
        /// Возвращает минимальный элемент в стеке за О(1)
        /// </summary>
        /// <returns></returns>
        public int Min()
        {
            return stack.Peek().Min;
        }
    }
}
