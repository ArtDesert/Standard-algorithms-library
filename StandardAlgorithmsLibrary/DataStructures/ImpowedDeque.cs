using System;

namespace StandardAlgorithmsLibrary.DataStructures
{
    /// <summary>
    /// Улучшенная двусторонняя очередь с эффективным добавлением элемента в конец и середину очереди, и удалением из начала очереди.
    /// </summary>
    public class ImprowedDeque
    {
        private Deque DHead;
        private Deque DTail;
        public int Count { get { return DHead.Count + DTail.Count; } }

        public ImprowedDeque()
        {
            DHead = new Deque();
            DTail = new Deque();
        }

        /// <summary>
        /// Добавляет элемента в конец очереди за O(1)
        /// </summary>
        /// <param name="value"></param>
        public void PushBack(int value)
        {
            if (DHead.Count == DTail.Count)
            {
                if (DHead.Count == 0)
                {
                    DHead.PushBack(value);
                }
                else
                {
                    DHead.PushBack(DTail.PopFront());
                    DTail.PushBack(value);
                }
            }
            else
            {
                DTail.PushBack(value);
            }
        }

        /// <summary>
        /// Удаляет элемент из начала очереди за O(1)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int PopFront()
        {
            if (Count == 0)
            {
				throw new InvalidOperationException();
			}
            else
            {
                if (DHead.Count == DTail.Count)
                {
                    DHead.PushBack(DTail.PopFront());
                }
                return DHead.PopFront();
            }
        }

        /// <summary>
        /// Добавляет элемент в середину очереди за O(1)
        /// </summary>
        /// <param name="value"></param>
        public void PushMiddle(int value)
        {
            if (DHead.Count == DTail.Count)
            {
                if (DHead.Count == 0)
                {
                    DHead.PushBack(value);
                }
                else
                {
                    DHead.PushBack(value);
                }
            }
            else
            {
                DTail.PushFront(value);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", DHead, DTail);
        }
    }
}
