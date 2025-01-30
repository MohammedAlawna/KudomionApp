using Kudomion.Features.SignIn;
using Kudomion.FirebaseManager;
using Kudomion.Model;
using Kudomion.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Firebase.Auth;

namespace Kudomion;
public partial class MainPage : ContentPage
{
    public FirebaseAuthProvider authProvider;

    //FirebaseAuthProvider authProvider;
    public static string currentLoggedInUser;
    public static UserModel currentUser = null;
    FirebaseHelper firebase = new FirebaseHelper();
    public static bool loggedIn = false;

    //Testing Timer
    System.Timers.Timer oneDayTimer = new System.Timers.Timer(
                TimeSpan.FromHours(24).TotalMilliseconds);


    //FirebaseAuthClient _authClient;
    public MainPage(/*object bindingContext*/)
    {
        InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAaahksGmC2M1IpC2gKmIY0DBIQcBqZInA"));

        oneDayTimer.Start();
        oneDayTimer.Elapsed += OnTimedEvent;
        oneDayTimer.AutoReset = false;
        oneDayTimer.Enabled = true;
        
        // firebase.GetUserByName(Home.GetLoggedInUser().Result.name);
        // BindingContext = bindingContext;
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Time Elapsed: ", e.SignalTime);
    }

    


    private async void ForgetPasswordClicked(object sender, EventArgs e)
    {
        try
        {
            //Prompt Email Input:
            string email = await DisplayPromptAsync("Password Recovery", "Please enter the email you already used to create your account?");

            //Console.WriteLine("Entered Prompt: " + email); => Tested and Debugged: is working.
            await authProvider.SendPasswordResetEmailAsync(email);

            //Alert Success Message:
            await DisplayAlert("Password Reset Link!", "Password-reset email was sent. Please check your email.", "OK!");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error!", "An error just occured. Please contact developer. " + ex.Message, "OK!");
        }
        //  await Navigation.PushAsync(new SignUpPage());
    }

    public void ViewUserProfile(string username)
    {
        Navigation.PushAsync(new UserProfile(username));
    }

    //This method is used to login (Only for verified accounts).
    //If verified, you'll login and create user (duelists) custom profile.
    //If not verified, you'll get a prompt to verify your account.
    async void SignInWithVerification(object sender, EventArgs e)
    {
        try
        {
            //1- Check if UserVerified (By Email Verify Link):
            var loggedInAuthLink =  await authProvider.SignInWithEmailAndPasswordAsync(emailEntry.Text, passwordText.Text);
            

            //2- Implicitly Reload/Refresh FirebaseAuthed User by Forcing The Token Refresh:
            var tokenRefresh = await loggedInAuthLink.GetFreshAuthAsync();

            Console.WriteLine("Was Email Verified: " + loggedInAuthLink.User.IsEmailVerified);

          /*     if (tokenRefresh.User.IsEmailVerified)
               {
                await DisplayAlert("Success","VERIF: true!", "OK!");
               }*/ 

            //Debugging Line for Email Verif:

            //If Verified, add to users db, if not, don't add:


        }
        catch(Exception ex)
        {
           await DisplayAlert("Error!", "An error just occured. Please Contact Developer. " + ex.Message , "OK!");
        }
    }

    /*                PRE-ALPHA RELEASE
    private async void SignInClicked(object sender, EventArgs e)
    {
        try
        {
           currentLoggedInUser = userNameText.Text;
            UserModel outPut = await firebase.GetUserByName(currentLoggedInUser);
            //Console.WriteLine("This OUTPUT!!" + outPut.name + " -- Lowered Case: " + outPut.name.ToLower() + ",  --" + userNameText.Text.ToLower());
            currentUser = outPut;
            //Case Insensitive Strings
           string loweredCaseName = userNameText.Text.ToLower().ToString();
            string loweredCaseNameDB = outPut.name.ToLower().ToString();

            //Case Insensitive Check using => string.Equals()
            bool caseInsensitiveCheck = string.Equals(loweredCaseName, loweredCaseNameDB, StringComparison.CurrentCultureIgnoreCase);


            if (caseInsensitiveCheck == true && passwordText.Text == outPut.password)
            {
                //Navigate to loggedIn (LoginPage):
                await Navigation.PushAsync(new LoginPage(userNameText.Text));
                
                //Store CurrentLoggedIn User:
                currentLoggedInUser = userNameText.Text;

                //Disable SignIn temp to deny multi-clicking:
                SignInBtn.IsEnabled = false;

                //Change LoggedInUser status to Online:
                currentUser = new UserModel() {
                    name = currentUser.name,
                    duels = currentUser.duels,
                    //NumberOfPosts = currentUser.NumberOfPosts,
                    Id = currentUser.Id,
                    password = currentUser.password,
                    points = currentUser.points,
                    posts = currentUser.posts,
                    ranking = currentUser.ranking,
                    usertype = currentUser.usertype,
                    status = "ONLINE"
                };
                await firebase.UpdateUser(currentLoggedInUser, currentUser);
                return;

            }

            if (outPut == null)
            {

                await DisplayAlert("User Not Found!", "No such user exist!", "OK!");
                return;
            }



            else
            {
                await DisplayAlert("Wrong Credentials!", "Either Password or Useranme incorrect!", "OK!");
                return;
            }
        }

        catch (NullReferenceException n)
        {
            await DisplayAlert("Exception!", $"Null Reference Exception caught! -- {n.Data}", "OK!");
            return;
        }

    }*/


    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignUpPage());
    }


    //Providers:
    //1- Google:
    private void GoogleAuthTapped(object sender, EventArgs e)
    {
        DisplayAlert("Google Auth System!", "Google Authnetication is not available in this current closed-beta release.", "OK!");
    }


    //2- Facebook:
    private void FacebookAuthTapped(object sender, EventArgs e)
    {
        DisplayAlert("Facebook Auth System!", "Facebook Authnetication is not available in this current closed-beta release.", "OK!");

    }


    //3- GitHub:
    private void DiscordAuthTapped(object sender, EventArgs e)
    {
        DisplayAlert("Discord Auth System!", "Discord Authnetication is not available in this current closed-beta release.", "OK!");
    }

}

