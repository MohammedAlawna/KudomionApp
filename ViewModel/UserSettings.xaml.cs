using Kudomion.FirebaseManager;
using Kudomion.Model;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Kudomion.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSettings : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        public UserSettings()
        {
            InitializeComponent();
        }

        private async void SubmitButton(object sender, EventArgs e)
        {
           try
            {
                //Get All Users.
                List<UserModel> GetAllUsers = await firebase.GetAllUsers();


                if (AreEntriesEmpty() == true)
                {
                    //  await DisplayAlert("Empty Field!", "System Detected Empty fields!", "OK!");
                    return;
                }

                if (UserExist(GetAllUsers) == true)
                {
                    await DisplayAlert("Name Error!", "Name Already Taken, Please Specify Another Name!", "OK!");
                    return;
                }


                //   User getCurrentUser = await firebase.GetUserByName(log.GetOriginalUserName());
                UserModel getCurrentUser = MainPage.currentUser;

                //Assign New Values To The Current Logged In User.
                UserModel userToBeUpdated = new UserModel
                {
                    name = nUser.Text,
                    password = nPass.Text,
                    points = getCurrentUser.points,
                    posts = getCurrentUser.posts,
                    duels = getCurrentUser.duels,
                    usertype = getCurrentUser.usertype,
                    //TODO Email.
                    //TODO ImageSrc.
                };


                //Update User Via Firebase.
                await firebase.UpdateUser(MainPage.currentUser.name, userToBeUpdated);

                //Update Current Logged In User Name.
                MainPage.currentLoggedInUser = nUser.Text;
                //  log.UpdateNameLabel(nUser.Text);






                //Reset Values

                nUser.Text = String.Empty;
               // nEmail.Text = String.Empty;
                nPass.Text = String.Empty;
                nPassConfirm.Text = String.Empty;


                //Display Alert
                var saveChanges = await DisplayAlert("Save Changes?", "Are you sure you want to apply new user credentials?", "Yes", "No");
                if (saveChanges)
                {
                    await Navigation.PushAsync(new LoginPage(MainPage.currentLoggedInUser));
                    return;

                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error",$"Exception: {ex}", "OK!");
            }
        }

        //Check If The New User (Name) already used..
        private bool UserExist(List<UserModel> allUsrs)
        {
            try
            {
                //Variables (array, users list)..
                List<string> userStrings = new List<string>();
                List<UserModel> AllUsersDB = allUsrs;
                //bool isUserExist;

                foreach (UserModel usr in AllUsersDB)
                {
                    userStrings.Add(usr.name.ToLower());
                }

                if (userStrings.Count == 0)
                {
                    //  isUserExist = true;
                    return false;
                }

                //Boolean Check (Worked~)
                bool checkUserDB = userStrings.Contains(nUser.Text.ToLower());

                if (checkUserDB)
                {
                    return true;
                }

                if (checkUserDB == false)
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                DisplayAlert("Warning!", "Error Just Occured! " + e.Message, "OK!");
            }
            return true;
        }

        private bool AreEntriesEmpty()
        {
            if (string.IsNullOrEmpty(nUser.Text))
            {
                DisplayAlert("Missing Credentials!", "Please Enter The New Username..", "OK!");
                return true;
            }

            if (string.IsNullOrEmpty(nPass.Text))
            {
                DisplayAlert("Missing Credentials!", "Please Enter The New Password..", "OK!");
                return true;
            }

            if (string.IsNullOrEmpty(nPassConfirm.Text))
            {
                DisplayAlert("Missing Credentials!", "Please Enter The New Password Confirmation..", "OK!");
                return true;
            }

            return false;
            /* TODO:: When Email Authentication Implemented In The Project.
            if(nEmail.Text == "")
            {
                DisplayAlert("Missing Credentials!", "Please Enter The New Email..", "OK!");
                return;
            }*/
        }

        private void OnClickAvatar(object sender, TappedEventArgs e)
        {
            DisplayAlert("Not Available", "Sorry. This feature is not available in this release.", "OK!");
            //Console.WriteLine("You just clicked the save avatar.");
        }
    }
}