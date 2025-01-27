//using Android.OS;
using Kudomion.FirebaseManager;
using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TierList : ContentPage
    {
        FirebaseHelper fbHelper = new FirebaseHelper();
        
        //Commented Out MVVM Implementation (Dependency Injector)
        public TierList(/*ViewModelTest vm*/)
        {
            InitializeComponent();

            //CreateTopDeckTrial();
            LoadTierListFromDb();

            //Set Binding Context Using Dependency Injection.
            //Check MauiProgram.cs for viewing the registration of the dependency injection.
            //BindingContext = vm;
        }

        async void LoadTierListFromDb()
        {
            try
            {
                var allTopDecks = await fbHelper.GetAllTopDecks();
                topDecksToLoad.ItemsSource = allTopDecks;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK!");
            }   
        }

        async void CreateTopDeckTrial()
        {
            TopDeck deckToAdd = new TopDeck
            {
                topDeckName = "Blue-Eyes White Dragon", 
                topDeckSrc = "https://i.imgur.com/hV8MQN2.jpg",
            };
            await fbHelper.AddTopDeck(deckToAdd);
           // await DisplayAlert("Alert!", "Item Trial Function Printed. " + fbHelper.AddTopDeck, "OK!");
        }

        private void ViewDeckButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Feature not available.", "Viewing Tier Deck is not available in this release.", "OK!");
        }

        private void DownloadDeckButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Feature not available.", "Downloading Tier Deck is not available in this release", "OK!");
        }
    }
}