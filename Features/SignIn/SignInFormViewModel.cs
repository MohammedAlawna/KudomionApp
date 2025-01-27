using Firebase.Auth;
using Kudomion.Entities.Users;
using Kudomion.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kudomion.Features.SignIn
{
    public class SignInFormViewModel : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand SignInCommand { get; }
       

      /*  public SignInFormViewModel(FirebaseAuthClient authClient, CurrentUserStore currentUserStore)
        {
            SignInCommand = new SignInCommand(this, authClient, currentUserStore);
        }*/

    }
}
