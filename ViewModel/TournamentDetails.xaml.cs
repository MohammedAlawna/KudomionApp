using Kudomion.FirebaseManager;
using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TournamentDetails : ContentPage
    {
        FirebaseHelper fbHelper = new FirebaseHelper();
        
        public TournamentDetails(string tournamentName)
        {
            InitializeComponent();
            info.IsVisible = true;
            LoadPickerItems();
            LoadTourmamentDetails(tournamentName);
        }

       

        async void LoadTourmamentDetails(string name)
        {
            try
            {
                //Assign TournyName to the Main Title.
                tournamentTitle.Text = name;
               

                //Get Tourny from DB using the passed name.
                Tournament tournyInstance = await fbHelper.GetTournamentByName(name);

                //Testing Line
                /*tournyInstance.semiFinals.Add(new User { name="Mo3taz"});
                await fbHelper.UpdateTournamentBasic(name, tournyInstance);*/
                //Debug.WriteLine("Semi-Finals: " + tournyInstance.semiFinals.Count);

                //Load winners if tourny is done.
                winnerText.Text ="Winner: " +  tournyInstance.winner.name;
                secondPlaceText.Text = "Second Place: " + tournyInstance.secondPlace.name;

                //Comment Out(Checking Details Status Only): await DisplayAlert("Alert!", $"Name: {tournyInstance.title}", "OK!");
                //Assign Rest of The Tourny Values (Brackets, info and etc..)
                TournamentBanner.Source = tournyInstance.tournyBannerSrc;
                if (tournyInstance.signUpActive == false)
                {
                    SignupStatus.Text = "* CLOSED! You are not allowed to join this event.";
                }
                if (tournyInstance.signUpActive)
                {
                    SignupStatus.Text = "OPEN! You are allowed to join this event.";
                }


                //Check if number of registeredPlayers equals to 16
                //If "YES" prepare brackets, if "NOT" do not
                if (tournyInstance.registeredUsers.Count == 16)
                {
                    //Prepare Brackets, start round! => R1, R2, R3, R4...
                    //2- Create 3 Rounds
                    //A- First Round: 4 matches
                    //Matches are filled with P's(8) from qualifiedPlayers list.
                     R1P1.Text = tournyInstance.registeredUsers[0].name;
                     R1P2.Text = tournyInstance.registeredUsers[1].name;
                     R1P3.Text = tournyInstance.registeredUsers[2].name;
                     R1P4.Text = tournyInstance.registeredUsers[3].name;
                     R1P5.Text = tournyInstance.registeredUsers[4].name;
                     R1P6.Text = tournyInstance.registeredUsers[5].name;
                     R1P7.Text = tournyInstance.registeredUsers[6].name;
                     R1P8.Text = tournyInstance.registeredUsers[7].name;
                     R1P9.Text = tournyInstance.registeredUsers[8].name;
                     R1P10.Text = tournyInstance.registeredUsers[9].name;
                     R1P11.Text = tournyInstance.registeredUsers[10].name;
                     R1P12.Text = tournyInstance.registeredUsers[11].name;
                     R1P13.Text = tournyInstance.registeredUsers[12].name;
                     R1P14.Text = tournyInstance.registeredUsers[13].name;
                     R1P15.Text = tournyInstance.registeredUsers[14].name;
                     R1P16.Text = tournyInstance.registeredUsers[15].name;
                }
                else
                {
                    //Prompt indicator message.
                   // await DisplayAlert("Bracket Auto System", "Brackets will be available once the number of required participants satisfied", "OK!");
                    return;
                }

                // Semi-Finals (Round-2) Checker..
                if(tournyInstance.semiFinals.Count == 4)
                {
                    R2P1.Text = tournyInstance.semiFinals[0].name;
                    R2P2.Text = tournyInstance.semiFinals[1].name;
                    R2P3.Text = tournyInstance.semiFinals[2].name;
                    R2P4.Text = tournyInstance.semiFinals[3].name;
                }

                // Final (Round-3) Checker..
                if(tournyInstance.final.Count == 2)
                {
                    R3P1.Text = tournyInstance.final[0].name;
                    R3P2.Text = tournyInstance.final[1].name;

                    //Results Assigner (1st Place, 2nd Place).
                    winnerText.Text = "Winner: " + tournyInstance.winner.name;
                    secondPlaceText.Text = "Second Place: " + tournyInstance.secondPlace.name;
                }
            }
            catch(Exception e)
            {
                await DisplayAlert("Exception" ,$"Error: {e}", "OK!");
            }
        }



        void LoadPickerItems()
        {
            tournamentState.Items.Add("Info");
            tournamentState.Items.Add("Sign-Up");
            tournamentState.Items.Add("Brackets");
            tournamentState.Items.Add("Results");

            tournamentState.SelectedIndex = 0;

            //Triggering any change to the SelectedIndex.
            tournamentState.SelectedIndexChanged += (sender, args) =>
            {
                //Checking SelectedIndex in Picker.
                if (tournamentState.SelectedIndex == 0)
                {
                    //Show Tournament Info
                    info.IsVisible = true;
                    bracket.IsVisible = false;
                    SignUp.IsVisible = false;
                    result.IsVisible = false;
                }

                if(tournamentState.SelectedIndex == 1)
                {
                    //Show Tournament Sign-Up Page.
                    SignUp.IsVisible = true;
                    info.IsVisible = false;
                    bracket.IsVisible = false;
                    result.IsVisible = false;
                }

                if(tournamentState.SelectedIndex == 2)
                {
                    //Show Tournament's Bracket.
                    bracket.IsVisible = true;
                    info.IsVisible = false;
                    SignUp.IsVisible = false;
                    result.IsVisible = false;
                }

                if(tournamentState.SelectedIndex == 3)
                {
                    //Show Tournament Result Page.
                    result.IsVisible = true;
                    bracket.IsVisible = false;
                    info.IsVisible = false;
                    SignUp.IsVisible = false;
                }
            };

          
        }
        
        private void JoinBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success!", "You Successfuly Signed-Up to our tournament." ,"OK!");
            return;
        }

      /*  private async void ProcessSecondRound(object sender, EventArgs e)
        {
            try
            {
                //Process Round (From SecondRound List)..
                Tournament currentTourny = await fbHelper.GetTournamentByName(tournamentTitle.Text);
                Console.WriteLine(currentTourny.semiFinals.Count);
                
                //Assign Duels
                R2P1.Text = currentTourny.semiFinals[0].name;
                R2P2.Text = currentTourny.semiFinals[1].name;
                R2P3.Text = currentTourny.semiFinals[2].name;
                R2P4.Text = currentTourny.semiFinals[3].name;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alert", $"An Exception: {ex}", "OK!");
            }
        }*/

      /*  private async void ProcessFinal(object sender, EventArgs e)
        {
            try
            {
                //Process Final Round (From FinalRound List)..
                Tournament currentTourny = await fbHelper.GetTournamentByName(tournamentTitle.Text);

                //Assign Final Duels
                R3P1.Text = currentTourny.final[0].name;
                R3P2.Text = currentTourny.final[1].name;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alert", $"An Exception: {ex}", "OK!");
            }
        }*/
    }
}