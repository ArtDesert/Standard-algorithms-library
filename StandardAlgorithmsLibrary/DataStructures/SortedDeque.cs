using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAlgorithmsLibrary.DataStructures
{
    /// <summary>
    /// Двусторонняя очередь с эффективным добавлением в конец, удалением из начала и поиском минимума всей очереди
    /// </summary>
    public class SortedDeque
    {
        SortedStack SHead;
        SortedStack STail;

        public SortedDeque()
        {
            SHead = new SortedStack();
            STail = new SortedStack();
        }

        /// <summary>
        /// Добавляет элемент в конец очереди за О(1)
        /// </summary>
        /// <param name="value"></param>
        public void PushBack(int value)
        {
            STail.Push(value);
        }

        /// <summary>
        /// Удаляет элемент из начала очереди за О(1)
        /// </summary>
        /// <returns></returns>
        public int PopFront() 
        {
            if (SHead.Count == 0)
            {
                while (STail.Count != 0)
                {
                    SHead.Push(STail.Pop());
                }
            }
            return SHead.Pop();
        }

        /// <summary>
        /// Возвращает минимальный элемент в очереди за О(1)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int Min()
        {
            if (SHead.Count == 0 && STail.Count == 0) throw new InvalidOperationException();
            else if (SHead.Count == 0) return STail.Min();
            else if (STail.Count == 0) return SHead.Min();
            else return Math.Min(SHead.Min(), STail.Min());
        }
    }
}
