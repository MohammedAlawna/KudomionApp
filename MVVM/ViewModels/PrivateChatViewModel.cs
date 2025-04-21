using Kudomion.Shared.ViewModels;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KudomionApp.MVVM.ViewModels
{
     public class PrivateChatViewModel : ViewModelBase
    {
        private readonly IFirebaseChatService _chatService;
        public ObservableCollection<Message> Messages { get; set; } = new();

        //New Message
        public string NewMessage { get; set; }
        public ICommand SendMessageCommand { get; }


        public PrivateChatViewModel(IFirebaseChatService chatService)
        {
            _chatService = chatService;
            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new Command(async () => await SendMessage());
        }

        private async Task SendMessage()
        {
            if(string.IsNullOrWhiteSpace(NewMessage)) return;

            var message = new Message {
            Id = Guid.NewGuid().ToString(),
            ChatId = "assignedChatId", //ChatID should be retrieved dynamically.
            SenderId = "userId", //Get Current User Id.
            Content = NewMessage,
            MessageTimeStamp = DateTimeOffset.Now,
            Status = MessageStatus.Fired,
            };

            await _chatService.SendMessageAsync(message.ChatId, message.SenderId, message.Content);
            Messages.Add(message);

            NewMessage = string.Empty;
            OnPropertyChanged(nameof(NewMessage));

        }

        public async Task LoadMessages(string chatId)
        {
            var messages = await _chatService.GetMessagesAsync(chatId);
            Messages.Clear();

            foreach (var message in messages)
            {
                Messages.Add(message);
            }
        }

    }
}
