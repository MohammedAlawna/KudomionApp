using CommunityToolkit.Maui.Views;
using Firebase.Auth;
using Kudomion;
using Kudomion.FirebaseManager;
using Kudomion.Model;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.ViewModels;
using KudomionApp.MVVM.ViewModels.Popups;
using KudomionApp.Services;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KudomionApp.MVVM.Views.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectUserPopup : Popup
	{
		private readonly IFirebaseChatService _chatService;
		private readonly ChatListViewModel _clViewModel;
		FirebaseHelper firebaseHelper = new FirebaseHelper();

		public SelectUserPopup(ChatListViewModel clViewModel ,IFirebaseChatService chatService)
		{
			InitializeComponent();
			_chatService = chatService;
			_clViewModel = clViewModel;
			LoadUsersData();

			/*_users = users;
			_onUserSelected = onUserSelected;

		//	UserPicker.ItemsSource = GetAllUsersInDb();
			UserPicker.ItemDisplayBinding = new Binding("DisplayName");*/
		}

		private async void LoadUsersData()
		{	
            var listOfUsers = await firebaseHelper.GetAllUserStrings();
            UserPicker.ItemsSource = listOfUsers;
        }
		



       	private async void OnStartChatClicked(object sender, EventArgs ev)
        {

			try
			{
				var selectedUser = UserPicker.SelectedItem as string;

				if (!string.IsNullOrEmpty(selectedUser))
				{

					var existingChat = _clViewModel.Chats.FirstOrDefault(chat =>
					chat.ParticipantsIDs.Count == 2 &&
					chat.ParticipantsIDs.Contains(MainPage.currentLoggedInUser) &&
					chat.ParticipantsIDs.Contains(selectedUser));
					
					if(existingChat != null)
					{
						await Shell.Current.DisplayAlert("Chat Exists", "You already have a chat with this user.", "OK!");
						return;
					}

                   await _chatService.CreateChatAsync(
                        new List<string> { MainPage.currentLoggedInUser, selectedUser },
                        isPublic: false,
                        isClan: false
                        );

			
					await _clViewModel.LoadChats(MainPage.currentLoggedInUser, isRefresh: true);

					Close();
				}
				else
				{
                    await Shell.Current.DisplayAlert("Missing Info", "Please select a user first.", "OK");
                }
			}
			catch(Exception ex)
			{
				await Shell.Current.DisplayAlert("OOps..", "Something went wrong.." + ex, "OK!");
			}
        
        }

    }
    }