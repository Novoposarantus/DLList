using System;

namespace DoublyLinkingListLibrary
{
    [Serializable()]
    public class DeleteNullExeption : Exception
    {
        public DeleteNullExeption() : base("Error. Try to Delete Null Current.") { }
    }
    [Serializable()]
    public class MoveExeption : Exception
    {
        public MoveExeption() : base("Error. Try go to Null.") { }
    }
}
