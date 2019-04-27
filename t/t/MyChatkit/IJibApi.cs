using System;
using System.Threading.Tasks;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage.Request;
using t.MyChatkit.ModelChatkit.ModelRelatedUsers.Request;

namespace t
{
    public interface IJibApi
    {
        Task<TokenResponse> PostToken(TokenRequest request);
        Task<CreateMessageResponse> SendMessage(CreateMessageRequest request);
        Task<User[]> GetUsers(GetUsersRequest request);


        Task<User[]> CreateRoom(GetUsersRequest request);
    }
}
