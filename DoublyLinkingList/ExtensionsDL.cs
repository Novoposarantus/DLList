using System;
using System.Collections.Generic;
using System.Text;
using DoublyLinkingListLibrary;

namespace ExtensionsMehodsForDL
{
    public static class ExtensionsDL
    {
        public static void WriteList<T>(this DoublyLinkingList<T> dlList, bool reverse)
        {
            if (dlList.Length == 0)
            {
                return;
            }
            DoublyLinking<T> buffer = reverse ? dlList.end : dlList.head;
            DoublyLinking<T> GetNextLinq() => buffer.NextLinq;
            DoublyLinking<T> GetPreviousLinq() => buffer.PreviousLinq;
            DoublyLinkingList<T>.GetLinqDelegate getLinq;
            if (reverse)
            {
                getLinq = GetPreviousLinq;
            }
            else
            {
                getLinq = GetNextLinq;
            }
            while (buffer != null)
            {
                Console.WriteLine(buffer.Value);
                buffer = getLinq();
            }
        }
    }
}
