using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Google.Cloud.Firestore;
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
using System.Reflection.Metadata;
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
        //Storing LastSnapShot for Pagination -> beter performance, lazy loading:
        private DocumentSnapshot? _lastChatSnapShot; 
        private bool _isLoadingChats = false;
        private bool _hasMoreChats = true;
        public IAsyncRelayCommand CreateTestChatCommand { get; }
        public IAsyncRelayCommand CreateNewChatCommand { get; }
        public IAsyncRelayCommand<Chat> OpenChatCommand { get; }
        public IRelayCommand<string> LoadChatsCommand { get; }
        public IRelayCommand LoadMoreChatsCommand { get; }
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
            LoadChatsCommand = new AsyncRelayCommand<string>(userId => LoadChats(userId));
            CreateNewChatCommand = new AsyncRelayCommand(CreateNewChat);
            LoadMoreChatsCommand = new AsyncRelayCommand(LoadMoreChats);
        }

  
        private async Task LoadMoreChats()
        {
            if (_isLoadingChats || !_hasMoreChats) return;

            _isLoadingChats = true;

            var result = await _chatService.GetChatsForUserAsync(MainPage.currentLoggedInUser, _lastChatSnapShot);

            foreach(var chat in result.Chats)
            {
                Chats.Add(chat);
            }

            _isLoadingChats = false;
        }


        public async Task CreateNewChat()
        {
            try
            {
                // 3. Create and show the popup
                var provider = App.Current.Handler.MauiContext.Services;
                var popup = new SelectUserPopup(provider.GetRequiredService<ChatListViewModel>()
                    , provider.GetRequiredService<IFirebaseChatService>());
                Shell.Current.CurrentPage.ShowPopup(popup);
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Exception occured: " + ex, "OK!");
            }
            /* var popup = new SelectUserPopup();
             Shell.Current.CurrentPage.ShowPopup(popup);*/
        }

        public async Task LoadChats(string? userId, bool isRefresh = false)
        {
            if (isRefresh)
            {
                Chats.Clear();
                _lastChatSnapShot = null;
                _hasMoreChats = true;
            }

            if (_isLoadingChats || !_hasMoreChats || userId is null) return;

            _isLoadingChats = true;

            var result = await _chatService.GetChatsForUserAsync(userId, _lastChatSnapShot);

            var chats = result.Chats;
            var lastSnapshot = result.LastSnapshot;

            foreach (var chat in chats)
            {
                Chats.Add(chat);
            }

            _lastChatSnapShot = lastSnapshot;

            if (chats.Count < 20)
                _hasMoreChats = false;

            _isLoadingChats = false;

            /*     if(isRefresh)
                 {
                     Chats.Clear();
                     _lastSnapShot = null;
                 }*/




            var rslts = await _chatService.GetChatsForUserAsync(userId);
            Chats.Clear();
            foreach(var chat in rslts.Chats)
            {
                Chats.Add(chat);
            }
        }

        private async void AsyncChatsLoader()
        {
            await LoadChats(MainPage.currentLoggedInUser);
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
