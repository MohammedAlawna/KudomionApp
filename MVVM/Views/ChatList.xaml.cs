using Kudomion;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.ViewModels;

namespace KudomionApp.MVVM.Views;

public partial class ChatList : ContentPage
{
//	private readonly IFirebaseChatService _chatService; 
	public ChatList(/*IFirebaseChatService chatService*/ ChatListViewModel chatListViewModel)
	{
		InitializeComponent();
		BindingContext = chatListViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		ChatListView.SelectedItem = null;

		if(BindingContext is ChatListViewModel vm)
		{
			await vm.LoadChats(MainPage.currentLoggedInUser);
		}
    }
}