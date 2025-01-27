using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Kudomion.MVVM.Models;
using System.Diagnostics;
using Kudomion.MVVM.ViewModels;
using Kudomion.Model;

namespace Kudomion.FirebaseManager
{
    public class NewsLinq
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
       // public FirebaseClient fbClient = new FirebaseClient();
        public NewsLinq() {
        
        }

        //1- View News: Mostly used to view latet news by the user
        public async Task<List<NewsItem>> ViewAllNews()
        {
            try
            {
                //Getting Users Info:
               var allUserStrings = await firebaseHelper.GetAllUserStrings();
                 
               var currentUser = await firebaseHelper.GetUserByName(MainPage.currentLoggedInUser);
               var checkBool = allUserStrings.Contains(currentUser.name);


                /*  Debug.WriteLine($"Checker All User: {allUserStrings[2]}, Current Checker: {checkBool}");
                 IT"S WORKING!
                 */

                var newsList = (await FirebaseHelper.GlobalFBClient.Child("News").OnceAsync<NewsItem>()).Select(item => new NewsItem
                {
                    Author = item.Object.Author,
                    Content = item.Object.Content,
                    ListOfReactions = item.Object.ListOfReactions,
                    NoLaughReactions = item.Object.NoLaughReactions,
                    NoLoveReactions = item.Object.NoLoveReactions,
                    LovedPost = item.Object.LovedPost,
                    LaughedAtPost = item.Object.LaughedAtPost,
                    Psrc = item.Object.Psrc,
                    LaughBtnReactedColor = item.Object.LaughBtnReactedColor,
                    LoveBtnReactedColor = item.Object.LoveBtnReactedColor,
                    //roomsInTourny = item.Object.roomsInTourny,
                }).ToList();
                return newsList;
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Database error {ex}", "OK!");
                return null;
            }
        }

        /*
    Rest of functions should be implemented later and they're meant to the mods
    with their own CP 
    */

        //2- Create
        public async Task<bool> CreateNewsItem(NewsItem newsItem)
        {
            try
            {
                await FirebaseHelper.GlobalFBClient.Child("News").PostAsync(newsItem);
                return true;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", $"Database Error: {ex}", "OK!");
                return false;
            }
        }

        //3- Modify/Edit

        //4- Delete Single News Instance (Selected)
        public async Task<bool> DeleteNewsItem(string newsContent)
        {
            try
            {
                var itemToDelete = (await FirebaseHelper.GlobalFBClient.Child("News").OnceAsync<NewsItem>()).
                    Where(c => c.Object.Content.ToLower() == newsContent.ToLower()).FirstOrDefault();
                await FirebaseHelper.GlobalFBClient.Child("News").Child(itemToDelete.Key).DeleteAsync();
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"An Excpetion: {ex}");
                return false;
            }
        }


        //5- Delete all news in db


        //6- Update News Instance:
        public async Task<bool> UpdateNewsItem(string content ,NewsItem newsToUpdate)
        {
            try
            {
                //Find NewsItem:
                var selectedItem = (await FirebaseHelper.GlobalFBClient.Child("News")
                    .OnceAsync<NewsItem>()).Where( c => c.Object.Content.ToLower() == content.ToLower())
                    .FirstOrDefault();

                //Update found room:
                //await FirebaseHelper.GlobalFBClient.Child(selectedItem.Key).PutAsync(newsToUpdate);
                await FirebaseHelper.GlobalFBClient.Child("News").Child(selectedItem.Key).PutAsync(newsToUpdate);

                //return
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error: {ex}");
                return false;
            }
        }

        //7- Get News Item By Name:
        public async Task<NewsItem> GetNewsItemByName(string postContent)
        {
            try
            {
                var allNewsItems = await ViewAllNews();
                await FirebaseHelper.GlobalFBClient.Child("News").OnceAsync<NewsItem>();
                return allNewsItems.Where(p=> p.Content.ToLower() ==  postContent.ToLower()).FirstOrDefault();
            }

            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"An Error Occured {ex}", "OK!");
                return null;
            }
        }


    }




}
