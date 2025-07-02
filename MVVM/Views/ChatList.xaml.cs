using KudomionApp.Interfaces;
using KudomionApp.MVVM.ViewModels;

namespace KudomionApp.MVVM.Views;

public partial class ChatList : ContentPage
{
	private readonly IFirebaseChatService _chatService; 
	public ChatList(IFirebaseChatService chatService)
	{
		InitializeComponent();
		BindingContext = new ChatListViewModel(chatService);
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		ChatListView.SelectedItem = null;
    }
}