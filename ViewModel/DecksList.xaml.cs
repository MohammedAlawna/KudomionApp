using Kudomion.FirebaseManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kudomion.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DecksList : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        const int RefreshDuration = 1;
   
        public DecksList()
        {
            InitializeComponent();
            LoadAllDecks();
            //AddDeckTrial();
            BindingContext = this; 
          
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshDecksAsync());

        async Task RefreshDecksAsync()
        {
            //Process Refresh:
            RefreshIndicator.IsRefreshing = true;
            LoadAllDecks();
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            RefreshIndicator.IsRefreshing = false;
        }

        async void LoadAllDecks()
        {
            try
            {
                //decksToLoad.ItemsSource = await firebase.GetAllDecks();
                var allDecks = await firebase.GetAllDecks();
                decksToLoad.ItemsSource = allDecks;
                /* Code Debug: Fixed~

                 Console.WriteLine("Decks: " + allDecks[0].link);
                */
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", $"An Exception Just Occured: {ex}", "OK!");
            }
        }

        async void AddDeckTrial()
        {
            DeckItem deckToAdd = new DeckItem
            {
                title = "Blue-Eyes White Dragon",
                thumbSrc = "https://i.imgur.com/ibaqv2S.png",
                code = "hellocode",
                link = "hello"
            };
            
            await firebase.AddDeck(deckToAdd);
        }

        private async void OpenTierList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TierList());
        }
        private async void DownloadDeckBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var getThisButton = (Button)sender;
                var getButtonParent = (StackLayout)getThisButton.Parent;
                var getMainParent = (StackLayout)getButtonParent.Parent;
                var getYDKSrc = (Label)getMainParent.Children[0];

                //Get DeckItem by It's Title.
                DeckItem findSelectedDeck = await firebase.GetDeckByName(getYDKSrc.Text);

                //Open in Browser to Download
                string deckUrl = findSelectedDeck.link;
                await Browser.OpenAsync(deckUrl);
            }

            catch(Exception ex)
            {
               await DisplayAlert("Exception", "Error. System Can't retrieve deck information. " + ex.Message, "OK!");
            }
        }

        private async void GetYDKE(object sender, EventArgs e)
        {
            try
            {
                var getThisButton = (Button)sender;
                var getButtonParent = (StackLayout)getThisButton.Parent;
                var getMainParent = (StackLayout)getButtonParent.Parent;
                var getYDKSrc = (Label)getMainParent.Children[0];


                //TODO Fix DeckItem Properties (YDKeCode and SrcYDK cuz its not showing):
                DeckItem findSelectedDeck = await firebase.GetDeckByName(getYDKSrc.Text);

                Console.WriteLine("YDKE: " + findSelectedDeck.code);

                //Copy Text to Clipboard.
                await Clipboard.SetTextAsync(findSelectedDeck.code);

                await DisplayAlert("Success!", "Deck YDKE Copied to Clipboard. Import it to your game (EDOPro, Omega etc.)", "OK!");
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
            }
        }

        private async void ViewDeckDetails(object sender, EventArgs e)
        {
            await DisplayAlert("Alert!", "View Details feature is not available in this release.", "OK!");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}