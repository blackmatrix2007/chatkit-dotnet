using System;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;

namespace t
{
    public interface ISubcriptionJib
    {
        event EventHandler<string> MessageReceived;
        event EventHandler<string> RoomsReceived;
        event EventHandler<string> OnOffHandle;


        /// <summary>
        /// Request token from chatkit
        /// </summary>
        void Connect();

        string GetChatkitId();
        string GetToken();

        void JoinRoom(Room room);
        void LeaveRoom();
        void SubcribeUserStateOnOff(string partnerid);
    }
}
