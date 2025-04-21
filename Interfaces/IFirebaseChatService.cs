using KudomionApp.MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.Interfaces
{
    public interface IFirebaseChatService
    {
        Task<string> CreateChatAsync(List<string> participantsIDs, bool isPublic, bool isClan);
        Task SendMessageAsync(string chatId, string senderId, string content);
        Task<List<Message>> GetMessagesAsync(string chatId);
    }
}
