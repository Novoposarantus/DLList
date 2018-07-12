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
            DoublyLinking<T> buffer = reverse ? dlList.end : dlList.head;
            
            while (buffer != null)
            {
                Console.WriteLine(buffer.Value);
                buffer = reverse ? buffer.PreviousLinq : buffer.NextLinq;
            }
        }
    }
}
