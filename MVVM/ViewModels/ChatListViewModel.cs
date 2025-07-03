using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Kudomion;
using Kudomion.FirebaseManager;
using Kudomion.Shared.ViewModels;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.Models.Chat;
using KudomionApp.MVVM.Views;
using KudomionApp.MVVM.Views.Popups;
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
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        private readonly IFirebaseChatService _chatService;
        public ObservableCollection<Chat> Chats { get; set; } = new(); 
        public IAsyncRelayCommand CreateTestChatCommand { get; }
        public IAsyncRelayCommand CreateNewChatCommand { get; }
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
            CreateNewChatCommand = new AsyncRelayCommand(CreateNewChat);
        }

        public ChatListViewModel() { }


        public async Task CreateNewChat()
        {
            try
            {



                // 1. Get all users from your service (adjust as needed)
                var allUsers = await firebaseHelper.GetAllUsers(); // Make sure this returns List<User>

                // 2. Define the action to perform when a user is selected
                Action<User> onUserSelected = async (selectedUser) =>
                {


                    // TODO: Call method to create or open chat with selectedUser
                    await _chatService.CreateChatAsync(
                        new List<string> { MainPage.currentUser.name, selectedUser.DisplayName },
                        isPublic: false,
                        isClan: false
                        );
                    //await CreateChatWithUser(selectedUser);
                };

                // 3. Create and show the popup
                var popup = new SelectUserPopup(allUsers, onUserSelected);
                Shell.Current.CurrentPage.ShowPopup(popup);
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Exception occured: " + ex, "OK!");
            }
            /* var popup = new SelectUserPopup();
             Shell.Current.CurrentPage.ShowPopup(popup);*/
        }

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

       /*     var chatId = selectedChat.Id;
            var route = $"//Chat/PrivateChat?chatId={chatId}&_={Guid.NewGuid()}";

            await Shell.Current.GoToAsync(route, true);*/

            await Shell.Current.GoToAsync($"//Chat/PrivateChat?chatId={selectedChat.Id}&_={Guid.NewGuid()}");
            // await Shell.Current.GoToAsync($"PrivateChat?chatId={selectedChat.Id}&t={DateTime.Now.Ticks}");


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
