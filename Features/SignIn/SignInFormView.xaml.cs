using Firebase.Auth;
using Kudomion.Features.SignUp;
using System.Runtime.CompilerServices;

namespace Kudomion.Features.SignIn;

public partial class SignInFormView : ContentView
{
	public SignInFormView()
	{
		InitializeComponent();
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		Navigation.PushAsync(new SignUpPage());
		//Shell.Current.DisplayAlert("Alert!", "Go To SignYp Page MVVM with Firebase Auth (TODO)", "OK!");
	}
}