using System;
using System.Threading.Tasks;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage.Request;

namespace t
{
    public interface IJibApi
    {
        Task<TokenResponse> PostToken(TokenRequest request);

        //https://us1.pusherplatform.io/services/chatkit/v2/d6100906-573e-4b40-b8ca-c5995b573c1b/rooms/19564764/messages
        //{"text":" 882","user_id":"neo_at_hotelsng"}
        Task<CreateMessageResponse> SendMessage(CreateMessageRequest request);
    }
}
