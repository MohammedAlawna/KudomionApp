using Kudomion.FirebaseManager;
using Kudomion.Model;
using System.Diagnostics;
using System.Windows.Input;

namespace Kudomion.ViewModel;

public partial class TournamentsDashboard : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	const int RefreshDuration = 2;

	public TournamentsDashboard()
	{
		InitializeComponent();


		//Create A Trial Tournament (Comment Out when stop testing)
		//AddTournamentTrial();

		//Load All Tournaments.
		LoadAllTournaments();
		BindingContext = this;
	}

    public ICommand RefreshCommand => new Command(async () => await RefreshTournamentsAsync());

	async Task RefreshTournamentsAsync()
	{
		RefreshIndicator.IsRefreshing = true;
		LoadAllTournaments();
		await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
		RefreshIndicator.IsRefreshing = false;
	}

    async void LoadAllTournaments()
	{
		try
		{
			TournamentsToLoad.ItemsSource = await firebaseHelper.GetAllTournaments();
		}
		catch(Exception ex)
		{
			await DisplayAlert("Error!" ,$"An excpetion just occured! {ex.Message}" ,"OK!");
		}
	}

	async void AddTournamentTrial()
	{
		UserModel firstPlaceMock = new UserModel() { name = "winner" };
		UserModel secondPlaceMock = new UserModel() { name = "secondPlace" };

		Tournament newTourny = new  Tournament{
			title = "YKJ Live Tournament #2",
			tournyBannerSrc = "https://i.imgur.com/BvY1VfZ.jpg",
			winner = firstPlaceMock,
			secondPlace = secondPlaceMock,
			signUpActive = true,
			registeredUsers = new List<UserModel>(),	
			semiFinals = new List<UserModel>() { new UserModel { name = "KuDo" } },
			final = new List<UserModel>() { new UserModel { name = "KuDo" } },
		};
		await firebaseHelper.AddTournament(newTourny);
		//await DisplayAlert("UI Debugger", $"SemiFinals: {newTourny.semiFinals.Count}", "OK!");
	}

    private async void ViewDetailsButtonClicked(object sender, EventArgs e)
    {
		try
		{
			//Access The Main Parent in the Stack. 
			var getCurrent = (Button)sender;
			var getStackLayout = (StackLayout)getCurrent.Parent;
			var getMainStackLayout = (StackLayout)getStackLayout.Parent;

			//Get The Tournament name/title.
			var getTextChild = (Label)getMainStackLayout.Children[0];

			//Check If Tournament Started or Not:
			//If Not, Display Alert and Return, 
			var getTournament = await firebaseHelper.GetTournamentByName(getTextChild.Text);
			bool isSignUpActive = getTournament.signUpActive;


            if (isSignUpActive == true) //SignUpActive: true => Tourny Starts: false. 
            {
                await DisplayAlert("Sign Up Pending", "You can't view tournament. Viewing will be available when it starts.", "OK!");
            }

            if (isSignUpActive == false) //SignUpActive: false => Tourny Starts: true.
			{
                //If Started, Pass Info to New Page, and Navigate to it!
                await Navigation.PushAsync(new TournamentDetails(getTextChild.Text));
            }

        }
		catch(Exception ex)
		{
			Debug.WriteLine($"Error: {ex.Message}");
		}
    }

    private async void SignUpButtonClicked(object sender, EventArgs e)
    {
		try
		{
			//Access The Main Parent in the Stack. 
			var getCurrent = (Button)sender;
			var getStackLayout = (StackLayout)getCurrent.Parent;
			var getMainStackLayout = (StackLayout)getStackLayout.Parent;

			//Get The Tournament name/title.
			var getTextChild = (Label)getMainStackLayout.Children[0];


			//Check and Register User To Tournament..
			//1- Get Current LoggedInUser.
			UserModel currentLoggedInUser = await firebaseHelper.GetUserByName(MainPage.currentLoggedInUser);


			//2- Get Tournament Instance (that was clicked - from tourny name).
			Tournament selectedTournament = await firebaseHelper.GetTournamentByName(getTextChild.Text);


			if(selectedTournament.signUpActive == false)
			{
				await DisplayAlert("Sign Up Closed", "You cant Join thie event. Registeration is closed", "OK!");
				return;
			}

			//Check if RegisteredUsers equal 8 (may be updated in upcoming releases)
			if(selectedTournament.registeredUsers.Count == 8)
			{
				//Update Tournament When Count = 8, Sign Up = false
				selectedTournament.signUpActive = false;
				await firebaseHelper.UpdateTournamentBasic(selectedTournament.title, selectedTournament);

				await DisplayAlert("Tournament System", "Reached Maximum number of participants.", "OK!");
				return;
			}

			//Check if current user exist in registered users
			//If Exist, return and throw an error that user already registered
			var usersInTourny = selectedTournament.registeredUsers;
			List<string> userStrings = new List<string>();
            bool isUserExist;

            foreach (UserModel usr in usersInTourny)
			{
				userStrings.Add(usr.name.ToLower());
			}
			if(userStrings.Count == 0 || selectedTournament.registeredUsers == null || userStrings == null)
			{
				isUserExist = false;
			}
			isUserExist = userStrings.Contains(currentLoggedInUser.name.ToLower());

			if (isUserExist)
			{
                await DisplayAlert("Error", "You already registered in this event!", "OK!");
				return;
            }
        

            //If not continure the block.
            Tournament tournyToUpdate = new Tournament
			{
				title = selectedTournament.title,
				tournyBannerSrc= selectedTournament.tournyBannerSrc,
				registeredUsers = selectedTournament.registeredUsers.
				Concat(new[] {currentLoggedInUser}).ToList(),
				semiFinals = selectedTournament.semiFinals,
				final = selectedTournament.final,
				winner = selectedTournament.winner,
				secondPlace = selectedTournament.secondPlace,
				signUpActive = selectedTournament.signUpActive,
			};

            await firebaseHelper.UpdateTournamentBasic(selectedTournament.title, tournyToUpdate);
           
            //5- Disable The Join/Sign-Up Button.
            getCurrent.IsEnabled = false;

            //Debugging Line Only..
            await DisplayAlert("Success!", $"You Joined The Tournament: ", "OK!");
		}
		catch(Exception ex)
		{
			await DisplayAlert("Error!", $"Exception: {ex}", "OK!");
		}
    }
}