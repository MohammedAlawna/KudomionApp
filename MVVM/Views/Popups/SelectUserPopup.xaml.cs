using CommunityToolkit.Maui.Views;
using Firebase.Auth;
using Kudomion.Model;
using KudomionApp.MVVM.ViewModels.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KudomionApp.MVVM.Views.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectUserPopup : Popup
	{
		private readonly List<UserModel> _users;
		private readonly Action<User> _onUserSelected;

		public SelectUserPopup(List<UserModel> users, Action<User> onUserSelected)
		{
			InitializeComponent();
			_users = users;
			_onUserSelected = onUserSelected;

			UserPicker.ItemsSource = _users;
			UserPicker.ItemDisplayBinding = new Binding("DisplayName");
		}

		private void OnStartChatClicked(object sender, EventArgs ev)
		{
			var selectedUser = UserPicker.SelectedItem as User; 
			if (selectedUser != null)
			{
				_onUserSelected?.Invoke(selectedUser);
				Close();
			}
			else
			{
				Shell.Current.DisplayAlert("Missing Info..", "Please select a user first..", "OK!");
			}
		}

	}
}