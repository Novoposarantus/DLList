using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkingListLibrary
{
    internal class DoublyLinking<T>
    {
        internal DoublyLinking<T> PreviousLinq { get; set; }
        internal T Value { get; set; }
        internal DoublyLinking<T> NextLinq { get; set; }

        internal DoublyLinking(T value)
        {
            PreviousLinq = null;
            Value = value != null ? value : default(T);
            NextLinq = null;
        }
    }
    
}

