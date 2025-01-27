using Kudomion.Features.SignIn;
using Kudomion.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.MVVM.Models
{
    public class SignInViewModel: ViewModelBase
    {
        public SignInFormViewModel SignInFormViewModel { get; }

        public SignInViewModel(SignInFormViewModel signInFormViewModel) {
            SignInFormViewModel = signInFormViewModel;
        }
    }
}
