using Kudomion.FirebaseManager;
using Kudomion.Model;
using Kudomion.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kudomion.MVVM.ViewModels;
using System.Windows.Input;


namespace Kudomion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leaderboard : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        const int RefreshDuration = 1;
       // bool isRefreshing = false;


        public Leaderboard()
        {
            InitializeComponent();
            RankAllUsers();
            BindingContext = this;
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshLeaderboardAsync());


        async Task RefreshLeaderboardAsync()
        {  
            //Process Refresh Indicator:
            RefreshIndicator.IsRefreshing = true;
            RankAllUsers();
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            RefreshIndicator.IsRefreshing = false;
        }

        public async void RankAllUsers()
        {
            try
            {
                List<UserModel> allUsers = await firebaseHelper.GetAllUsers();
                var rankedUsers = allUsers.OrderByDescending(p => p.points);
                var rankedList = rankedUsers.ToList();

                userRankingsToLoad.ItemsSource = rankedUsers;

                
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error!", $"Unexpected problem occured: {ex.Message}", "OK!");
            }
        }

        public void DisableRefreshIndicator()
        {
            RefreshIndicator.IsEnabled = false;
        }
        
        private async void UsernameClicked(object sender, EventArgs e)
        {
            var parent = (Label)sender;
            
            //Displaying The User Clicked (Debugging) -> Done: Is Working.
            //await DisplayAlert("Alert!", $"Sender is: {parent.Text}", "OK!"); -> Done!

            //Navigate to UserProfile Page with the clicked user card in ranking.
            await Navigation.PushAsync(new UserProfile(parent.Text));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Alert!", "Image Viewing isn't available!", "OK!");
        }
    }
    }