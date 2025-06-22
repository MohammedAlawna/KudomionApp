using CommunityToolkit.Mvvm.Input;
using Kudomion;
using Kudomion.Shared.ViewModels;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KudomionApp.MVVM.ViewModels
{
     public class PrivateChatViewModel : ViewModelBase, IQueryAttributable
    {
        private readonly IFirebaseChatService _chatService;
        public ObservableCollection<Message> Messages { get; set; } = new();


        //New Message
        public string NewMessage { get; set; }
        public IRelayCommand SendMessageCommand { get; }

        //Chat ID:
        private string _chatId;
        public string ChatId
        {
            get => _chatId;
            set
            {
                _chatId = value;
                OnPropertyChanged(nameof(ChatId));
            }
        }

     
        public PrivateChatViewModel(IFirebaseChatService chatService)
        {
            _chatService = chatService;
            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new AsyncRelayCommand(SendMessage);

        }

        public PrivateChatViewModel()
        {

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("chatId"))
            {
                ChatId = query["chatId"]?.ToString();
                Debug.WriteLine($"[VM] ChatId received: {ChatId}");
            }
        }


        public async Task SendMessage()
        {
            //Test Line: => Command Working!!
          //  await Shell.Current.DisplayAlert("Alert!", "Binding Btn..", "OK!");
           

            if(string.IsNullOrWhiteSpace(NewMessage)) return;

            var message = new Message {
            Id = Guid.NewGuid().ToString(),
            ChatId = ChatId, //ChatID should be retrieved dynamically.
            SenderId = "user_1", //Get Current User Id.
            Content = NewMessage,
            MessageTimeStamp = DateTime.Now,
            //Status = MessageStatus.Fired,
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
