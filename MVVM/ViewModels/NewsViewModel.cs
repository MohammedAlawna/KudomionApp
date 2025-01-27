using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database.Query;
using Kudomion.FirebaseManager;
using Kudomion.Model;
using Kudomion.MVVM.Models;
using Kudomion.ViewModel.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Kudomion.MVVM.ViewModels
{
    public partial class NewsViewModel : ObservableObject
    {
        News news;
        NewsLinq newsLinq = new NewsLinq();
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        [ObservableProperty]
        List<NewsItem> newsList;

        [ObservableProperty]
        int loveReactionsCount = 0;

        [ObservableProperty]
        int laughReactionsCount = 0;

        [ObservableProperty]
        string loveReaction = "LOVE";

        [ObservableProperty]
        string laughReaction = "LAUGH";


        public NewsViewModel(News news)
        {
            this.news = news;
            LoadAllNews();

        }

     

      /*  async Task<bool> HasLoved(string username, string content)
        {
            
            try
            {
                //query Current User:
                User currentUser = await firebaseHelper.GetUserByName(username);

                //query Desired Post:
                NewsItem requiredNewsItem = await newsLinq.GetNewsItemByName(content);

                //Get All LoveReactedUsers in NewsItem:
                //var allLoveReactants = await requiredNewsItem.ListOfReactions.Where(r => r.LovedPost == true).ToList();

                //Check if CurrentUser is there
                //if Yes, then return true

                //if Not, then return false;

                return true;
            }

            catch(Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                return false;
            }        
        }*/

     /*   async Task<bool> HasLaughed(string username, string content)
        {
            try
            {
                //1- Query Current User:


                //2- Query Desired Post:


                //3- Query Laugh Reactions:


                //4- Check If Current User exists in Laugh Reactions:


                //5- Return value of existing:
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Ex: {ex.Message}");
                return false;
            }
        }*/

        async void LoadAllNews()
        {
            try
            {
               NewsList = await newsLinq.ViewAllNews();
               //Console.WriteLine("News: " + NewsList[0].Content);
            }
            catch (Exception ex)
            {
                 Debug.WriteLine("Error: " + ex);
            }
        }


        /*
         * CAUTION: ReactionButton are implemented in the code-behind file because of the inability to get the clicked instance
         * with current UI structure with the relay command. May be implemented later with MVVM, for now code-behind is fine, other
         * operations, loading, etc.. are implemented in this NewsViewModel.
         * 
                [RelayCommand]
                void React(string reaction)
                {

                    //Multi Reaction System Algorithm Starts
                    1. Check reaction(string).
                    2. (A) if reaction is LOVE then,
                       1st: Access parent stacklayout for the LoveReaction element.
                       2nd: Create a Reactions with type of LOVE and use the current user reacted
                       3rd: Attach that reaction to the news and update it to the fb database.
                       4th: Always check if the user reacted to post, if user reacted make bg of
                            that stacklayout for reaction's bacgkround == royalblue.
                       5th: Assign number of Love using special LINQ command. to get love reaction count.
                       (B) if reaction is LAUGH then,
                       == Do same as with LOVE just change the type of reaction to laugh D: ==

                    Algortihm Ends
                    try
                    {
                        //Element Getter Trial:
                        var targetElement = news.FindByName("LaughReactionImg") as Image;
                        var parentOfTarget = targetElement.Parent as StackLayout;
                        var BorderTarget = parentOfTarget.Parent as Border;
                        Debug.WriteLine("Target: "+ targetElement.Source + " Parent: " + parentOfTarget + " Border: " + BorderTarget);

                        if (reaction == LoveReaction)
                        {

                            //Get The Current Post Instance.
                            //news.Get

                            //Debug.WriteLine($"You Just Reacted {LoveReaction}, To This Post.");
                        }

                        if (reaction == LaughReaction)
                        {
                            Debug.WriteLine($"You Just Reacted {LaughReaction}, To This Post.");
                        }
                    }
                    catch(Exception ex)
                    {
                        Shell.Current.DisplayAlert("Error", $"Error: {ex}", "OK!");
                    }


                }
        */



        //MVVM Basics
        /* [ObservableProperty]
         string testBinding;

         [ObservableProperty]
         string lastTextBinding;



         public string fullBindedString => $"{TestBinding}: {LastTextBinding}: {IsEnabled.ToString()}";

         [ObservableProperty]
         [NotifyPropertyChangedFor(nameof(IsNotBusy))]
         bool isEnabled;

         public bool IsNotBusy => !isEnabled;

         [RelayCommand]
         void Tap() {
             isEnabled = true;
             Console.WriteLine(fullBindedString);
             isEnabled = false;
         }*/
    }
}
