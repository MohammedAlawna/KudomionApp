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
        public IRelayCommand InviteToDuelCommand { get; }

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
            InviteToDuelCommand = new AsyncRelayCommand(InviteToDuel);

        

        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("chatId"))
            {
                ChatId = query["chatId"]?.ToString();
                Debug.WriteLine($"[VM] ChatId received: {ChatId}");
               
                await LoadMessages(ChatId);
            }
        }

        public async Task OnNavigatedTo()
        {
            Debug.WriteLine("[OnNavigatedTo] Called — loading messages...");
            if (!string.IsNullOrEmpty(ChatId))
            {
                await LoadMessages(ChatId);
            }
            else
            {
                Debug.WriteLine("[OnNavigatedTo] Warning: ChatId is empty");
            }
        }

        public async Task InviteToDuel()
        {
            await Shell.Current.DisplayAlert("Feature Not Available","Invite To Duel Function will be available in later release", "OK!");
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

            if(messages == null)
            {
                Debug.WriteLine("[Load Messages] Warning: messages is null.");
                return;
            }

            Messages.Clear();

            foreach (var message in messages)
            {
                Messages.Add(message);
            }
        }

    }
}
