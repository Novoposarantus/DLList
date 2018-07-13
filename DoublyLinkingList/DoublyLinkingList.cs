using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkingListLibrary
{
    public class DoublyLinkingList<T>
    {
        internal DoublyLinking<T> head;
        internal DoublyLinking<T> current;
        internal DoublyLinking<T> end;
        public int Length { get; private set; }
        internal delegate DoublyLinking<T> GetLinqDelegate();

        public DoublyLinkingList(params T[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            for (int i = 0; i < value.Length; ++i)
            {
                AddToEnd(value[i]);
            }
        }
        public T Current => current.Value;
        public T this[int index]
        {
            get
            {   
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("Error.Index out of Range.");
                }
                var buffer = head;
                for (var i = 0; i < index; ++i)
                {
                        buffer = buffer.NextLinq;
                }
                return buffer.Value;
            }
        }
        public void GoToHead()
        {
            current = head;
        }
        public void GoToEnd()
        {
            current = end;
        }

        public void AddToEnd(T value)
        {
            Add(new DoublyLinking<T>(value), end, false);
        }
        public void AddToHead(T value)
        {
            Add(new DoublyLinking<T>(value), head);
        }
        public void AddBeforeSelected(T value)
        {
            Add(new DoublyLinking<T>(value), current);
        }
        void Add(DoublyLinking<T> node, DoublyLinking<T> selected, bool isnEnd = true)
        {
            ++Length;
            if (selected == null)
            {
                head = current = end = node;
                return;
            }
            node.PreviousLinq = isnEnd ? selected?.PreviousLinq : selected;
            node.NextLinq = isnEnd ? selected : null;
            if (isnEnd)
            {
                if (node.PreviousLinq != null)
                {
                    selected.PreviousLinq.NextLinq = node;
                    selected.PreviousLinq = node;
                }
                else
                {
                    selected.PreviousLinq = node;
                    head = node;
                }
            }
            else
            {
                selected.NextLinq = node;
                end = node;
            }
        }
        public void DeleteCurrent()
        {
            if (current == null)
            {
                throw new DeleteNullExeption();
            }

            if (Length == 1)
            {
                end = head = current = null;
                --Length;
                return;
            }


            DoublyLinking<T> buffer = null;
            buffer = current == head ? current.NextLinq : current.PreviousLinq;
            if (current == head)
            {
                head = current.NextLinq;
            }
            else if (current == end)
            {
                end = current.PreviousLinq;
            }
            else
            {
                current.PreviousLinq.NextLinq = current.NextLinq;
                current.NextLinq.PreviousLinq = current.PreviousLinq;
            }
            current.NextLinq = null;
            current.PreviousLinq = null;
            --Length;
            current = buffer;
        }
        public int GetIndexOfCurrent()
        {
            var buffer = head;
            var index = 0;
            while (buffer != current)
            {
                buffer = buffer.NextLinq;
                ++index;
            }
            return index;
        }
        public void ChangeCurrent(int count = 1)
        {
            if (count == 0)
            {
                return;
            }
            int indexOfCurrentAfterChange = GetIndexOfCurrent() + count;
            if ((indexOfCurrentAfterChange < 0) || (indexOfCurrentAfterChange > Length - 1))
            {
                throw new MoveExeption();
            }

            DoublyLinking<T> GetNextLinq() => current.NextLinq;
            DoublyLinking<T> GetPreviousLinq() => current.PreviousLinq;
            GetLinqDelegate getLinq;
            if (count > 0)
            {
                getLinq = GetNextLinq;
            }
            else
            {
                getLinq = GetPreviousLinq;
            }
            for (var i = 0; i < Math.Abs(count); ++i)
            {
                current = getLinq();
            }
        }
        public IEnumerable<T> AsEnumerable(bool reverse)
        {
            var buffer = reverse ? end : head;
            for (var i = 0; buffer != null; ++i)
            {
                yield return buffer.Value;
                buffer = reverse ? buffer?.PreviousLinq : buffer?.NextLinq;
            }
        }
    }
}
