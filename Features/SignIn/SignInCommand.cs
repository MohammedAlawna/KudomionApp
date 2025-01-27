using Firebase.Auth;
using Kudomion.Entities.Users;
using Kudomion.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.Features.SignIn
{
    public class SignInCommand : AsyncCommandBase
    {
        private readonly SignInFormViewModel _viewModel;
       // private readonly FirebaseAuthClient _authClient;
        private readonly CurrentUserStore _currentUserStore;

        public SignInCommand(
           SignInFormViewModel viewModel,
        //   FirebaseAuthClient authClient,
           CurrentUserStore currentUserStore)
        {
            _viewModel = viewModel;
         //   _authClient = authClient;
            _currentUserStore = currentUserStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
            /*    UserCredential userCredential = await _authClient.SignInWithEmailAndPasswordAsync(
                    _viewModel.Email, _viewModel.Password);*/

             //   _currentUserStore.CurrentUser = userCredential.User;

          //      await Application.Current.MainPage.Navigation.PushAsync(new LoginPage(/*currentLogin Should be passed*/ _currentUserStore.CurrentUser.Info.DisplayName));
               /* await Shell.Current.GoToAsync("//DecksList");
                

                await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed in!", "Ok");*/
               
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign in. Please try again later.", "Ok");
            }
        }

    }
}
