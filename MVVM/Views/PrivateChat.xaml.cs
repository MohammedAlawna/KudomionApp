using Google.Rpc;
using Kudomion;
using KudomionApp.Interfaces;
using KudomionApp.MVVM.ViewModels;
using KudomionApp.Services;
using System.Diagnostics;

namespace KudomionApp.MVVM.Views;

[QueryProperty(nameof(ChatId), "chatId")]
public partial class PrivateChat : ContentPage
{
	private readonly IFirebaseChatService chatService;
    public string ChatId
    {
        set
        {
            if (BindingContext is IQueryAttributable vm)
            {
                vm.ApplyQueryAttributes(new Dictionary<string, object>
                {
                    { "chatId", value }
                });
            }
        }
    }
    public PrivateChat(IFirebaseChatService chatService)
	{
		InitializeComponent();
		BindingContext = new PrivateChatViewModel(chatService);
	
		
	}



    private void EmojisListClicked(object sender, EventArgs e)
    {
		DisplayAlert("Feature Alert!","This Feature isn't available yet.", "OK!");
    }
}