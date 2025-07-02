using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.ViewModels.Popups
{
    public class SelectUserPopupViewModel : ObservableObject
    {
        public ObservableCollection<User> Users { get; set; }
        public IRelayCommand<User> SelectUserCommand { get; }

        private readonly Action<User> _onUserSelected;

        public SelectUserPopupViewModel(IEnumerable<User> users, Action<User> onUserSelected)
        {
            Users = new ObservableCollection<User>(users);
            _onUserSelected = onUserSelected;

            SelectUserCommand = new RelayCommand<User>(user =>
            {
                _onUserSelected?.Invoke(user);
               
            });
        }


    }
}
