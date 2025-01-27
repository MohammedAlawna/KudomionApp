using Kudomion.Features.SignUp;
using Kudomion.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.MVVM.Models
{
    public class SignUpViewModel : ViewModelBase
    {
        //Readonly:
        public SignUpFormViewModel SignUpFormViewModel { get; }

        public SignUpViewModel(SignUpFormViewModel signUpFormViewModel)
        {
            SignUpFormViewModel = signUpFormViewModel;
        }


    }
}
