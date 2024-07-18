using System.Collections.Generic;
using System.Text;

namespace StandardAlgorithmsLibrary.DataStructures
{
    /// <summary>
    /// Двусторонняя очередь с эффективным добавлением и удалением из начала и конца очереди
    /// </summary>
    public class Deque
    {
        public Stack<int> head;
        public Stack<int> tail;
        public int Count { get { return head.Count + tail.Count; } }

        public Deque()
        {
            head = new Stack<int>();
            tail = new Stack<int>();
        }

        /// <summary>
        /// Добавляет элемент в конец очереди за O(1)
        /// </summary>
        /// <param name="value"></param>
        public void PushBack(int value)
        {
            tail.Push(value);
        }

        /// <summary>
        /// Добавляет элемент в начало очереди за O(1)
        /// </summary>
        /// <param name="value"></param>
        public void PushFront(int value)
        {
            head.Push(value);
        }

        /// <summary>
        /// Удаляет элмент из конца очереди за О(1)
        /// </summary>
        /// <returns></returns>
        public int PopBack()
        {
            if (tail.Count == 0)
            {
                while (head.Count != 0)
                {
                    tail.Push(head.Pop());
                }
            }
            return tail.Pop();
        }
        
        /// <summary>
        /// Удаляет элемент из начала очереди за О(1)
        /// </summary>
        /// <returns></returns>
        public int PopFront()
        {
            if (head.Count == 0)
            {
                while (tail.Count != 0)
                {
                    head.Push(tail.Pop());
                }
            }
            return head.Pop();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            while (head.Count != 0)
            {
                builder.Append(string.Format("{0} ", head.Pop()));
            }
            while (tail.Count != 0)
            {
                head.Push(tail.Pop());
            }
            while (head.Count != 0)
            {
                builder.Append(string.Format("{0} ", head.Pop()));
            }
            return builder.ToString();
        }
    }
}
