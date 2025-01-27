using Kudomion.FirebaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsFeed : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper(); 
        public NewsFeed()
        {
            InitializeComponent();
            //AddPostTrial();
            LoadNewsData();
           
        }

        async void LoadNewsData()
        {
            postsInNewsFeed.ItemsSource = await firebase.GetAllPosts();
        }

        async void AddPostTrial()
        {
            Post _postToAdd = new Post
            {
                content = "Welcome To Shadow Realm!",
                imageSource = "https://w.forfun.com/fetch/7c/7c169eed84dd6ff0a46ac71a130814f8.jpeg",
                YGOGoodReaction = 0
            };

            await firebase.AddPost(_postToAdd);
        }

        private async void CreatePostClicked(object sender, EventArgs e)
        {
            AddPostTrial();
            LoadNewsData();
            await DisplayAlert("Warning!", "Only Admins Can Create Posts In This Trial Release", "OK!");
        }

        private async void ReportPostClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Warning!", "Post Reporting Is Not Available In This Release", "OK!");
        }

        public void StandradReactClicked(object sender, EventArgs e)
        {
            
            var item = (Image)sender;
            var parent = (Grid)item.Parent;
            var child = (Label)parent.Children[3];

            int convertedString = Int16.Parse(child.Text);
            int incrementCounter = convertedString + 1;

            child.Text = incrementCounter.ToString();
            
        }
        
        
    }
}