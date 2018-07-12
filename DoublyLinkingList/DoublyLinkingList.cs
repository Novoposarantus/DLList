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
            if (current == head)
            {
                buffer = current.NextLinq;
                head = current.NextLinq;
                head.PreviousLinq = null;
                current.NextLinq = null;
            }
            else if (current == end)
            {
                buffer = current.PreviousLinq;
                end = current.PreviousLinq;
                end.NextLinq = null;
                current.PreviousLinq = null;
            }
            else
            {
                try
                {
                    buffer = current.PreviousLinq;
                    current.PreviousLinq.NextLinq = current.NextLinq;
                    current.NextLinq.PreviousLinq = current.PreviousLinq;
                    current.NextLinq = null;
                    current.PreviousLinq = null;
                }
                catch (NullReferenceException)
                {
                    throw new MoveExeption();
                }
            }
            --Length;
            current = buffer;
        }
        public void ChangeCurrent(int count = 1)
        {
            for (var i = 0; i < Math.Abs(count); ++i)
            {
                if (current == null) {
                    throw new MoveExeption();
                }
                //Заменить на делегат
                current = count > 0 ? current.NextLinq : current.PreviousLinq;
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
