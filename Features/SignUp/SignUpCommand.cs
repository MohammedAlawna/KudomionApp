using Firebase.Auth;
using Kudomion.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.Features.SignUp
{
    public class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpFormViewModel _viewModel;
    //    private readonly FirebaseAuthClient _authClient;
      /*  public SignUpCommand(SignUpFormViewModel viewModel, FirebaseAuthClient authClient)
        {
            _viewModel = viewModel;
            _authClient = authClient;
        }*/

        protected override async Task ExecuteAsync(object parameter)
        {
            if(_viewModel.Password != _viewModel.ConfirmPassword)
            {
                await Shell.Current.DisplayAlert("Matching Error!", "Password and Confirm Password are not the same. Please double check you spelling!", "OK!");
                return; 
            }

            try
            {
             //   await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                await Shell.Current.DisplayAlert("Success!", "You were successfully signed up.", "OK!");

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "There was a problem signing you in. Please try agian later."
                    + ex, "OK!"); 
            }
        }
    }
}
