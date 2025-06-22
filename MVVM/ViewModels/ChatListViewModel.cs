using CommunityToolkit.Mvvm.Input;
using Kudomion.Shared.ViewModels;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.ViewModels
{
    public class ChatListViewModel : ViewModelBase
    {
        private readonly IFirebaseChatService _chatService;
        public ObservableCollection<Chat> Chats { get; set; } = new(); 
        public IAsyncRelayCommand CreateTestChatCommand { get; }
        public IAsyncRelayCommand<Chat> OpenChatCommand { get; }
        public IRelayCommand<string> LoadChatsCommand { get; }
        public IAsyncRelayCommand<Chat> ChatSelectedCommand { get; }
        string currentUserId;

        public ChatListViewModel(IFirebaseChatService chatService)
        {
            _chatService = chatService;
            Chats = new ObservableCollection<Chat>();


            CreateTestChatCommand = new AsyncRelayCommand(CreateTestChat);

            //Load All Chats:
            AsyncChatsLoader();

            //Commands:
            OpenChatCommand = new AsyncRelayCommand<Chat>(OpenChat);
            ChatSelectedCommand = new AsyncRelayCommand<Chat>(ChatSelected);
            LoadChatsCommand = new AsyncRelayCommand<string>(LoadChats);

        }
        public ChatListViewModel() { }

        public async Task LoadChats(string? userId)
        {
            var userChats = await _chatService.GetChatsForUserAsync(userId);
            Chats.Clear();
            foreach(var chat in userChats)
            {
                Chats.Add(chat);
            }
        }

        private async void AsyncChatsLoader()
        {
            await LoadChats("user_1");
        }

        
        public async Task CreateTestChat()
        {
             
            try
            {
                var testChadId = await _chatService.CreateChatAsync(
                    new List<string> { "user_1", "user_2" },
                    isPublic: false, 
                    isClan: false
                    );

                Debug.WriteLine($"Test chat created with ID: {testChadId}");

                await LoadChats("user_1");
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error creating test chat: {ex.Message}");
            }
        }

        private async Task ChatSelected(Chat? selectedChat)
        {
            if(selectedChat == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"PrivateChat?chatId={selectedChat.Id}");
        }

        public async Task OpenChat(Chat? selectedChat)
        {
            //Debugging Line: 
            Debug.WriteLine("Open Chat Command Clicked and Working..");

            //TODO Understand more of that..
            await Shell.Current.GoToAsync($"PrivateChatView?chatId={selectedChat.Id}");
        }
    }
}
