using Firebase.Auth;
//using Firebase.Auth.Requests;
using Kudomion.Features.SignIn;
using Kudomion.FirebaseManager;
using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kudomion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        //private readonly FirebaseAuthClient authClient;
        public SignUpPage(/*object bindingContext*/)
        {
            InitializeComponent();
            
           /* urName.ReturnCommand = new Command(() => userName.Focus());
            password.ReturnCommand = new Command(() => password.Focus());
            confirmPassword.ReturnCommand = new Command(() => confirmPassword.Focus());*/

          //  BindingContext = bindingContext;
           

        }

     private async void SignUpEmailAuthFirebase(object sender, EventArgs e)
     {
            try
            {
                //Checking before proceeding:

                //Create UserAsync (UN, EMAIL, PW) => FirebaseAuth.
                var newUserCreated =  await firebase.authProvider.CreateUserWithEmailAndPasswordAsync(email.Text, userName.Text, password.Text);
                
                //Send Email Verification Link:
                await firebase.authProvider.SendEmailVerificationAsync(newUserCreated.FirebaseToken);

                //Disable Sign-Up Btn:
                SignUpBtn.IsEnabled = false;

                //DisplayAlert:
                await DisplayAlert("Welcome! One More Step..", "A verification email was sent. Please Check your email inbox.", "OK!");

                //Reset Values:
                userName.Text = string.Empty;
                password.Text = string.Empty;
                confirmPassword.Text = string.Empty;
                email.Text = string.Empty;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error!", "An error just occured. Please try again later. ", "OK!");
            }
     }

        private async void SignUpButtonClicked(object sender, EventArgs e)
        {
            try {
            //Disable SignUp Button Temp to prevent multi-reg:
            SignUpBtn.IsEnabled = false;

            //Variables (array, list<user>, bool)
            List<string> userStrings = new List<string>();
            List<UserModel> AllUsersDB = await firebase.GetAllUsers();
            bool isUserExist;
            
            foreach(UserModel user in AllUsersDB)
            {
                userStrings.Add(user.name.ToLower());
            }

            if (userStrings.Count == 0) { isUserExist = false; }

            //Boolean Check (Worked!~)
            isUserExist = userStrings.Contains(userName.Text.ToLower());

            //Testing Prompt (Worked!~)
            //await DisplayAlert("Warning!", "User Registered Success!" + userStrings[0] + "-- Bool: " + isUserExist, "OK!");

            //Check if username already in the DB records. (Worked!~)
            if (isUserExist)
            {
                await DisplayAlert("Error!", "Username already exists. Please choose another name.", "OK!");
                return;
            }

            else if (!isUserExist)
            {
                //Check for Whitespaces and Empty Strings.
                if (string.IsNullOrWhiteSpace(userName.Text) || string.IsNullOrWhiteSpace(password.Text) || string.IsNullOrWhiteSpace(confirmPassword.Text))
                {
                    await DisplayAlert("Invalid", "Whitespace or Blank Value is Invalid.", "OK!");
                    return;
                }

                //Check If Input (User, Pass) is/are Empty.
                if (string.IsNullOrWhiteSpace(userName.Text) || string.IsNullOrWhiteSpace(password.Text) || string.IsNullOrWhiteSpace(confirmPassword.Text))
                {
                    await DisplayAlert("Invalid", "Whitespace or Blank Value is Invalid.", "OK!");
                    return;
                }

                //Check If Credentials Are Mis-Matched.
                if (password.Text != confirmPassword.Text)
                {

                    await DisplayAlert("Password Mismatch!", "Please Make Sure That Passwords Are Match!", "OK!");
                    return;
                }

                RegisterNewUser();
            }
            
            } catch(Exception ex)
            {
                await DisplayAlert("Unexpected Error!", $"An error just occured. {ex}", "");
            }

        }
  
        private async void RegisterNewUser()
        {
            //Add User To DB.
            await firebase.AddUser(userName.Text, password.Text);
            await DisplayAlert("Success!", "User Registered Succesffully!", "OK!");

            //Reset Values
            userName.Text = string.Empty;
            password.Text = string.Empty;
            confirmPassword.Text = string.Empty;
            email.Text = string.Empty;
        }


    }
}