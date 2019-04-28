using System;
using System.Threading.Tasks;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedRooms.Request;
using t.MyChatkit.ModelChatkit.ModelRelatedRooms.Response;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage.Request;
using t.MyChatkit.ModelChatkit.ModelRelatedUsers.Request;

namespace t
{
    public interface IJibApi
    {
        Task<TokenResponse> PostToken(TokenRequest request);
        Task<CreateMessageResponse> SendMessage(CreateMessageRequest request);
        Task<User[]> GetUsers(GetUsersRequest request);


        Task<CreateRoomResponse> CreateRoom(CreateRoomRequest request);
        Task<CreateRoomResponse> UpdateRoom(CreateRoomRequest request);
        Task<BaseResponse> DeleteRoom(DeleteRoomRequest request);
    }
}
