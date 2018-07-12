using System;

namespace DoublyLinkingListLibrary
{
    [Serializable()]
    public class DeleteNullExeption : Exception
    {
        public DeleteNullExeption() : base("Error. Try to Delete Null Current.") { }
    }
    [Serializable()]
    public class NullGoExeption : Exception
    {
        public NullGoExeption() : base("Error. Try go to Null.") { }
    }
}
