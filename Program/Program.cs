using System;
using System.Collections.Generic;
using DoublyLinkingListLibrary;
using ExtensionsMehodsForDL;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var dlList = new DoublyLinkingList<int>(1, 2, 3, 4);
            var dlList2 = new DoublyLinkingList<char>('c', 'd', 'f');
            dlList.WriteList(false);
            dlList2.WriteList(true);
        }
    }
}
