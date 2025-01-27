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
    public partial class UserProfile : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        //Target you'll be viewing:
        UserModel targetUser;
        string profiledUser;

        //Your Username as viewer to this page:
        UserModel getLoggedInUser;


        public UserProfile(string username)
        {
            InitializeComponent();

            //Load User Profile.
            LoadUserProfile(username);
            profiledUser = username;
            //DisplayAlert("User: ", $"You Are Viewing: {profiledUser}, Original: {username}", "OK!");
            
            //Load Picker Items.
            LoadPickerItems();

            //Switch Visibility As Default.
            stats.IsVisible = true;
            posts.IsVisible = false;
            signature.IsVisible = false;
            duels.IsVisible = false;

            
        }

       

       
        private async void LoadUserProfile(string name)
        {
            try
            {
                UserProfileName.Text = name;
                profiledUser = name;
                getLoggedInUser = await FirebaseHelper.GetUsrFromName(profiledUser);
                //targetUser = await firebase.GetUserByName(name);

                //Assign Profile Values. :D 
                noDuels.Text = getLoggedInUser.duels.ToString();
                noPoints.Text = getLoggedInUser.points.ToString();
                noRanking.Text = getLoggedInUser.ranking.ToString();

                       }
            catch(Exception ex)
            {
                await DisplayAlert("Error!" ,$"Please contact developer. {ex}", "OK!");
            }
        } 

        private async void ShowUserDuels(string username)
        {
            try
            {          
            FirebaseHelper firebase = new FirebaseHelper();
            List<Room> allRooms = await firebase.GetAllRoomsInDB();

            List<Room> roomsForSpecifiedUser = allRooms.Where(n => n.p1 == username || n.p2 == username).ToList();

            if(roomsForSpecifiedUser.Count == 0 || allRooms.Count == 0)
            {
               await DisplayAlert("Room List Alert!", "There are currently no duels for this user!", "OK!");
               return;
            }

            if(roomsForSpecifiedUser.Count > 0)
            {
                //await DisplayAlert("Duels List!", "Username: " + roomsForSpecifiedUser[0].p1 + " , " + roomsForSpecifiedUser[0].p2,"OK!");
                userDuels.ItemsSource = roomsForSpecifiedUser;
            }
            }
            catch(Exception e)
            {
                await DisplayAlert("Error","An Unexpected Issue.." + e.Message, "OK!");
            }
        }

        private void LoadPickerItems()
        {
            userStatPicker.Items.Add("Connect");
            userStatPicker.Items.Add("Duels");
            userStatPicker.Items.Add("Posts");
            userStatPicker.Items.Add("Signature");
            

            //Set To First One.
            userStatPicker.SelectedIndex = 0;

            userStatPicker.SelectedIndexChanged += (sender, args) =>
            {
                if(userStatPicker.SelectedIndex == 0)
                {
                    //TODO Show user Profile Stats.
                    

                    //Switch Visibility For StackLayout.
                    stats.IsVisible = true;
                    posts.IsVisible = false;
                    signature.IsVisible = false;
                    duels.IsVisible = false;
                }

                if(userStatPicker.SelectedIndex == 1)
                {
                    //TODO Show user Duels.
                    ShowUserDuels(UserProfileName.Text);

                    //Switch Visibility for StackLayout.
                    stats.IsVisible = false;
                    posts.IsVisible = false;
                    signature.IsVisible = false;
                    duels.IsVisible = true;
                }

                if(userStatPicker.SelectedIndex == 2)
                {
                    //TODO Show user Posts.
                    

                    //Switch Visibility for StackLayout.
                    stats.IsVisible = false;
                    posts.IsVisible = true;
                    signature.IsVisible = false;
                    duels.IsVisible = false;
                }

                if(userStatPicker.SelectedIndex == 3)
                {
                    //TODO Show user Signature.
                    

                    //Switch Visibility for StackLayout.
                    stats.IsVisible = false;
                    posts.IsVisible = false;
                    signature.IsVisible = true;
                    duels.IsVisible = false;
                }
            };
        }

        private async void InviteToDuelClicked(object sender, EventArgs e)
        {
            //Change BG of Button.
            // chatReq.BackgroundColor = Colors.White;
            //1- Send Friend Request to target user:
            /*NOTE: Changes will be made to server side
            So you may need to add sth to the 
                 newsLinq Implementation*/

            // Get YourUserName and TargetUserName:
            
            getLoggedInUser = await FirebaseHelper.GetUsrFromName(MainPage.currentLoggedInUser);
            targetUser = await firebase.GetUserByName(profiledUser);
            Console.WriteLine($"Your User: {getLoggedInUser.name} ," +
                $" Target User: {targetUser.name}");

            //List With New FriendRequest to TargetUser:
           /* var newRequestList = targetUser.friendRequests;
            newRequestList.Add(getLoggedInUser);*/

            // Add YourUsrname To TargetUserName -> friendRequests:
            UserModel usrToUdpate = new UserModel { 
                name = targetUser.name,
                blockedList = targetUser.blockedList,
                friendsList = targetUser.friendsList,
                duels = targetUser.duels,
                JoinedAt = targetUser.JoinedAt, 
                points = targetUser.points,
                ranking = targetUser.ranking,
                posts = targetUser.posts,
                status = targetUser.status,
                password = targetUser.password,
                Id = targetUser.Id, 
                usertype = targetUser.usertype,
                friendRequests = targetUser.friendRequests.Concat(
                    new[] { getLoggedInUser }).ToList(),
            };
           //TODO, add currentUser to already firends request.
              //Update User from API:
            await firebase.UpdateUser(targetUser.name, usrToUdpate);

            //TODO Send Notification to TargetUser: (Friend Req sent):

            //Change Text and Maybe:BG of the Button: (Sent..) (Disabled)
            InviteToDuelBtn.Text = "Friend Request -> SENT!";
            InviteToDuelBtn.IsEnabled = false;

            //2- Prompt (Pop-Up) chat UI: (will be developed later on)
            //Temp ChatUI pop-up for the duel only, if opp inactive 5 mins, disable:


            //Prompt Alert (Testing Purposes)
            await DisplayAlert("Warning!", "Duel/Chat Invitation is not available in thei beta release!", "OK!");
        }

        private void BlockBtnClicked(object sender, EventArgs e)
        {
            //Prompt Alert (Testing Purposes)
            DisplayAlert("Warning!", "You blocked this contact!", "OK!");

        }
    }
}