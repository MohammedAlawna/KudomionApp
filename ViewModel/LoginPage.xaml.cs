using Kudomion.FirebaseManager;
using Kudomion.ViewModel;
using Firebase;
//using FirebaseAdmin;
//using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kudomion.Model;
using Newtonsoft.Json;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kudomion.MVVM.Models;
using Kudomion.MVVM.ViewModels;
using Kudomion.MVVM.Views;



/*using Android.Text;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;*/

namespace Kudomion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        //Carousel List<View> (For Binding).
        List<EventsCarouselModel> eventsList { get; set; } = new List<EventsCarouselModel>();

        List<Tournament> AllTournamentsInDB;
        //Firebase Plugin Parameters..
        // private string _deviceToken;
        FirebaseHelper firebase = new FirebaseHelper();

        public string currentLoggedInUserName;

        const int RefreshDuration = 1;

        public LoginPage(string _username)
        {
            InitializeComponent();
            BindingContext = this;

            //Load Users to SearchBar.
            LoadUsersIntoSearchBar();



            //Load Duelist/User Profile.
            LoadUsersInfo();

            //Demo: Try Update Ranking of Specific User.
            ApplyDuelistsRanking();

            //Debugging Global APi
            //CreateTrialNewsItem();
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshLoggedInPageAsync());

        async Task RefreshLoggedInPageAsync()
        {
            //Process Refresh:
            RefreshIndicator.IsRefreshing = true;

            //Apply Rankings Updates;
            ApplyDuelistsRanking();

            //Load Users to SearchBar.
            LoadUsersIntoSearchBar();

            //Load Duelist/User Profile.
            LoadUsersInfo();

            //Delay 1 sec.
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));

            //Disable Refreshing Indicator:
            RefreshIndicator.IsRefreshing = false;
        }



        //Tourny Status to String
        async Task<string> IsTournyActive(int tournyIndex)
        {
            AllTournamentsInDB = await firebase.GetAllTournaments();
            if (AllTournamentsInDB[tournyIndex].signUpActive == true)
            {
                return "OPEN!";
            }
            if (AllTournamentsInDB[tournyIndex].signUpActive == false)
            {
                return "CLOSED!";
            }
            return "Unknown";
        }



        private async void CreateTrialNewsItem()
        {
            try
            {
                NewsLinq linq = new NewsLinq();
                var currentUser = await FirebaseHelper.GetUsrFromName("UKITAKE");
                List<Reactions> reactions = new List<Reactions>();
                reactions.Add(new Reactions { userThatReacted = currentUser, typeOfReaction = "LOVE" });
                var trialItem = new NewsItem { Content = "This is a trial post by Jehad", NoLoveReactions = 120, NoLaughReactions = 30, Psrc = "https://i.imgur.com/l6mfkDk.jpeg", ListOfReactions = reactions };
                await linq.CreateNewsItem(trialItem);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }
        async void ApplyDuelistsRanking()
        {
            try
            {
                List<UserModel> allUsers = await firebase.GetAllUsers();
                var rankedUsers = allUsers.OrderByDescending(p => p.points);
                var rankedList = rankedUsers.ToList();

                foreach (var user in rankedList)
                {
                    int getRankOfEachUser = rankedList.IndexOf(user) + 1;

                    //Testing Purposes..
                    //Console.WriteLine("Rank List: " + getRankOfEachUser + " " + user.name + "\n");

                    //Retrieve info for the duelists Ranking (which need to be applied).
                    UserModel userToBeUpdated = new UserModel
                    {
                        name = user.name,
                        password = user.password,
                        points = user.points,
                        posts = user.posts,
                        duels = user.duels,
                        usertype = user.usertype,
                        ranking = getRankOfEachUser,
                    };

                    //Update The Selected User Instance.
                    await firebase.UpdateUser(user.name, userToBeUpdated);
                }
            }

            catch (Exception ex)
            {
                await DisplayAlert("Error!", "An unexpected error just occured. " + ex.Message, "OK!");
            }
        }

        private async void LoadUsersIntoSearchBar()
        {
            try
            {
                searchUser.Users = await firebase.GetAllUsers();
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", "An Unexpected error just happened, please contact the developer. " + e.Message, "OK!");
            }
        }


        //Load User Info
        private async void LoadUsersInfo()
        {
            try
            {
                //Get CurrentLoggedInUser Info.
                currentLoggedInUserName = MainPage.currentUser.name;


                //Get User Stats.
                var AllUsers = await firebase.GetAllUsers();
                int UsersCount = AllUsers.Count;
                var getCurrentUser = await firebase.GetUserByName(currentLoggedInUserName);

                loggedInUser.Text = "Welcome, " + currentLoggedInUserName;
                usrPoints.Text = "Points: " + getCurrentUser.points;
                usrRank.Text = "Rank: " + getCurrentUser.ranking;

                //Get Last Registered User.
                var lastRegistered = AllUsers.LastOrDefault().name;


                //Get Number of Duels
                var AllRooms = await firebase.GetAllRoomsInDB();
                int NumberOfRooms = AllRooms.Count;

                //Get Tournaments and Their Number
                var AllTournaments = await firebase.GetAllTournaments();
                int NumberOfTournaments = AllTournaments.Count;

                //Load Stats:
                NOfUsers.Text = UsersCount.ToString();
                NOfTournaments.Text = NumberOfTournaments.ToString();
                NOfDuels.Text = NumberOfRooms.ToString();

            }
            catch (Exception e)
            {
                await DisplayAlert("Error", "An Unexpected error just happened, please contact the developer. " + e, "OK!");
            }
        }


        //Profile Button clicked.
        private async void OnProfileSettingsClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new UserSettings());
            } 
            catch (Exception ex)
            {
                await DisplayAlert("Error!", "An erorr occured. Please contact developer.", "OK!");
            }
        }

        private async void OnNewsFeedClicked(object sender, EventArgs e){
            try
            {
                await Navigation.PushAsync(new NewsFeed());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", "An erorr occured. Please contact developer.", "OK!");
            }
        }

        private async void OnClickYGOGames(object sender, EventArgs e)
        {
            string viewKey = "GAMESVIEW_VISIBLE";
            await Navigation.PushAsync(new MultiplePageContainer(viewKey));
            //Debugging Line:
            //await DisplayAlert("Button Clicked!", "You will be redirected to games section.", "OK!");
        }

        private async void OnClickYGOAnime(object sender, EventArgs e)
        {
            string viewKey = "YGOANIME_VISIBLE";
            await Navigation.PushAsync(new MultiplePageContainer(viewKey));
            //Debugging Line: 
            //await DisplayAlert("Button Clicked!", "You will be reidrected to anime section.", "OK!");
        }

        private async void OnClickYGOClassRoom(object sender, EventArgs e)
        {
            string viewKey = "CLASSROOM_VISIBLE";
            await Navigation.PushAsync(new MultiplePageContainer(viewKey));
            //Debugging Line: 
            //await DisplayAlert("Button Clicked!", "You will be redirected to classroom section.", "OK!");
        }


        private async void OnClickYGOTournies(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TournamentsDashboard());
            //Debugging Line: 
            //await DisplayAlert("Button Clicked!", "You will be redirected to tournies section.", "OK!");
        }

        private async void OnClickYGODecks(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DecksList());
            //Debugging Line: 
            //await DisplayAlert("Button Clicked!", "You will be redirected to decks section.", "OK!");
        }

        private async void Logout_Tapped(object sender, EventArgs e)
        {
            try {
                //1- Change currentLoggedIn User status to Offline:
                var tempUsrRef = MainPage.currentUser;
                tempUsrRef = new UserModel {
                    name = MainPage.currentUser.name,
                    duels = MainPage.currentUser.duels,
                    /*NumberOfPosts = currentUser.NumberOfPosts,*/
                    Id = MainPage.currentUser.Id,
                    password = MainPage.currentUser.password,
                    points = MainPage.currentUser.points,
                    posts = MainPage.currentUser.posts,
                    ranking = MainPage.currentUser.ranking,
                    usertype = MainPage.currentUser.usertype,
                    friendRequests = MainPage.currentUser.friendRequests,
                    blockedList = MainPage.currentUser.blockedList,
                    friendsList = MainPage.currentUser.friendsList,
                    JoinedAt = MainPage.currentUser.JoinedAt,
                    status = "OFFLINE"
                    /*TODO: Last Seen and other info*/
                };

                
                await firebase.UpdateUser(MainPage.currentLoggedInUser, tempUsrRef);
                /*NOTICE:: For a more advanced system of Online/Offline System
                please refer to the AppLifeCycle in .NET MAUI official documentation.*/

                //2- Clear Login Credentiatals:
                MainPage.currentLoggedInUser = string.Empty;
            MainPage.loggedIn = false;
            MainPage.currentUser = null;
            await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
               await DisplayAlert("Unexpected Error", $"Error, please contact developer.{ex}", "OK!");
            }
            
        }

    }
}