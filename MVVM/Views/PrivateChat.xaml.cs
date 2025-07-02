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
    public PrivateChat(PrivateChatViewModel viewModel /*IFirebaseChatService chatService*/)
	{
		InitializeComponent();
        BindingContext = viewModel;
		
	
		
	}

    private async void OnBackButtonClicked(object sender, EventArgs eventArgs)
    {
        // await Shell.Current.GoToAsync("//Chat", true);

        /* if (Shell.Current.Navigation.NavigationStack.Count > 1)
         {
             await Shell.Current.Navigation.PopAsync();

         }*/

        await Shell.Current.Navigation.PopAsync();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if(BindingContext is PrivateChatViewModel vm)
        {
            await vm.OnNavigatedTo();
        }
    }

    private void EmojisListClicked(object sender, EventArgs e)
    {
		DisplayAlert("Feature Alert!","This Feature isn't available yet.", "OK!");
    }
}