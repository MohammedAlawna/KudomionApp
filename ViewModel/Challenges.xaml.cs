using Kudomion.FirebaseManager;
using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Challenges : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        //static int roomID;
        public Challenges()
        {
            InitializeComponent();
            ResetRoomValues();
            LoadDuelistsData();
           

           // DisplayAlert("Room ID!","Current Room ID is:" + roomID++ ,"OK!");
        }
      

        private async void ProcessRoomCreation()
        {
            await firebase.GetAllRooms();
        }
        private async void LoadDuelistsData()
        {
            try
            {
                

                /*Trial Line To Debug only.
                 * This code was and will be used for debugging rooms LINQ..
                var selectedRoom = unfinishedRooms.Where(r => r.p1 == "admin" && r.p2 == "UKITAKE").ToList();
               
                Debug.WriteLine($"Selected Room: {selectedRoom[0].isDone}, {selectedRoom[0].p1}, {selectedRoom[0].p2}");
                Debug.WriteLine($"Selected Room Count: {selectedRoom.Count}");
               foreach(var room in unfinishedRooms)
                {
                    Debug.WriteLine($"Unfinished Rooms: {room.p1}, {room.p2}, {room.winner}, {room.isDone}");
                    Debug.WriteLine($"Size of UnfinishedRooms: {unfinishedRooms.Count}");
                }
                */

                //Load LoggedInUser Name.
                // var loggedInUserName = await FirebaseHelper.GetUsrFromName(MainPage.currentLoggedInUser);
                UserModel loggedInUserName = MainPage.currentUser;
                p1.Text = MainPage.currentLoggedInUser;
                p1.IsEnabled = false;

                //Load AllUsersIntoSelector.
                List<UserModel> listOfUsers = await firebase.GetAllUsers();
                p2.ItemsSource = listOfUsers;

                //Load All Rooms In The Lobby.
                roomsCollectionView.ItemsSource = await firebase.GetAllRooms();
            }
            catch(Exception e)
            {
                await DisplayAlert("Error!", "Unexpected error just occured! " + e.Message, "OK!");
            }
        }

     
        private async void UpdateRoomsList()
        {
            try
            {
            //roomsCollectionView.ItemsSource = App.MyDatabase.GetActiveRoom(Home.GetLoggedInUser().name);
            roomsCollectionView.ItemsSource = await firebase.GetAllRooms();
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            p2.SelectedItem = null;
            //CheckRooms();
            
        }

        //private Room getPlayerRoom = null;
        public UserModel firstPlayer = null;
        public UserModel secondPlayer = null;
        public UserModel getWinningPlayer = null;

        private async void AdmitDefeat_Clicked(object sender, EventArgs e)
        {
            
            try {
                //The Following Code Is Needed To Get The Specific Room!
                //1- Get Current Button (Clicked Button)
                var el = (Button)sender;

                //2- Get Parent of The Button (Main Grid).
                var parent = (Grid)el.Parent;

                //3- Get First Player Name.
                var firstPlayerChild = (Label)parent.Children[0];

                //4- Get Second Player Name.
                var secondPlayerChild = (Label)parent.Children[2];

                var getRooms = await firebase.GetAllRoomsInDB();
                //var unfinishedRooms = getRooms.Where(r => r.winner == "" && r.isDone == false).ToList();


                //First:: Get Selected Room (The One You Clicked At).
                var getPlayerRoom = getRooms.Where(r => !r.isDone && r.p1 == firstPlayerChild.Text && r.p2 == secondPlayerChild.Text).ToList();
                firstPlayer = await FirebaseHelper.GetUsrFromName(getPlayerRoom[0].p1);
                secondPlayer = await FirebaseHelper.GetUsrFromName(getPlayerRoom[0].p2);

                Console.WriteLine($"First Player Is: {firstPlayer.name} Room is: P1 {getPlayerRoom[0].p1} + {getPlayerRoom[0].p2}" + $", Second Player Is: {secondPlayer.name}");
               
                //Second:: Get Selected User From That Room.
                string getSelectedPlayer = getPlayerRoom[0].p1;

                UserModel getLoggedInPlayer = await FirebaseHelper.GetUsrFromName(MainPage.currentLoggedInUser);

              
                getWinningPlayer = null;
                if(MainPage.currentUser.name != getPlayerRoom[0].p1 && MainPage.currentUser.name != getPlayerRoom[0].p2)
                {
                    await DisplayAlert("Duellist not found", "Admit Defeat is not allowed: You are not included in this match.", "OK!");
                    return;
                }

              
                if (MainPage.currentUser.name == getPlayerRoom[0].p1)
                {
                   

                    //Second Player => winner.
                    getWinningPlayer = secondPlayer;
                    getWinningPlayer.duels += 1;
                    getWinningPlayer.points += 3;
                    firstPlayer.duels += 1;
                    getPlayerRoom[0].isDone = true;
                    getPlayerRoom[0].winner = getWinningPlayer.name;

                    //Update User and Room Records.
                    await firebase.UpdateUser(getWinningPlayer.name, getWinningPlayer);
                    await firebase.UpdateUser(firstPlayer.name, firstPlayer);
                    await firebase.UpdateRoom(getPlayerRoom[0].p1, getPlayerRoom[0].p2, getPlayerRoom[0], getPlayerRoom[0].isDone);

                    //Update User Profile In Home Page.
                    UserModel currentUser = await FirebaseHelper.GetUsrFromName(MainPage.currentUser.name);

                  
                    //Prompt Admit Defeat!
                    await DisplayAlert("You Lost!", $"You just admit defeated! Duel Records Will be change", "OK!");

                    //Update Rooms List.
                    UpdateRoomsList();

                    

                    //Reseting Room Values:
                    ResetRoomValues();

                    return;
                }
                if (MainPage.currentUser.name != getPlayerRoom[0].p1)
                {
                   // getPlayerRoom = await firebase.GetPlayerRoom(MainPage.currentUser.name);

                    //First Player => winner.
                    getWinningPlayer = firstPlayer;
                    getWinningPlayer.duels += 1;
                    getWinningPlayer.points += 3;
                    secondPlayer.duels += 1;
                    getPlayerRoom[0].isDone = true;
                    getPlayerRoom[0].winner = getWinningPlayer.name;

                    //Update User and Room Records.
                    await firebase.UpdateUser(getWinningPlayer.name, getWinningPlayer);
                    await firebase.UpdateUser(secondPlayer.name, secondPlayer);
                    await firebase.UpdateRoom(getPlayerRoom[0].p2, getPlayerRoom[0].p1, getPlayerRoom[0], getPlayerRoom[0].isDone);

                    //Update User Profile In Home Page.
                    UserModel currentUser = await FirebaseHelper.GetUsrFromName(MainPage.currentUser.name);
                 
                    //Prompt Admit Defeat.
                    await DisplayAlert("You Lost!", $"You just admit defeated! Duel Records Will be changed!" + getWinningPlayer.name, "OK");

                    //Update Rooms List.
                    UpdateRoomsList();

                    //Reseting Room Values:
                    ResetRoomValues();
                    

                    return;
                }

            }
            catch(Exception er)
            {
                await DisplayAlert("Exception!", $"{er}, {er.Message}", "OK!");
            }
        }


        void ResetRoomValues()
        {
            try
            {
               // getPlayerRoom = null;
                firstPlayer = null;
                secondPlayer = null;
                getWinningPlayer = null;
            }
            catch(Exception e)
            {
                DisplayAlert("Error!", "An UnExpected Error Just Occured! " + e.Message, "OK!");
            }
        }

       
        private async void CreateRoom_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (p2 == null)
                {
                    await DisplayAlert("Missing Player!", "Please Enter Your Opponent Name", "OK!");
                    return;
                }
                bool isUserExist = await firebase.CheckIfUserExists();
                Console.WriteLine($"Is User Exist: {isUserExist}");
                if (isUserExist == true)
                {
                    await DisplayAlert("User Exist!", "You can't have more than one room at once. Please, complete your first match..", "OK!");
                    return;
                }

                if (p1.Text.ToLower() == p2.Items[p2.SelectedIndex].ToLower())
                {
                    await DisplayAlert("Same User!", "You can't duel yourself! C'mon! Please Specify Another Opponent..", "OK!");
                    return;
                }

                if (p1.Text != MainPage.currentLoggedInUser)
                {
                    await DisplayAlert("Room Error", "You can't create a room using another username.", "OK!");
                    return;
                }

                //Check If P1 and P2 Dueled Today (24 hours Timer):
                //TODO 24 hr countdown timer for 2 duelists:
                //LimitedDuels and LimitedRooms => Models.
                /*For Same room of p1 and p2, if less than 12 hours
                 * since its time, then deny the duel.
                  */

                Room roomToCreate = new Room();
                roomToCreate.p1 = p1.Text;
                // roomToCreate.p2 = "opp";
                roomToCreate.p2 = p2.Items[p2.SelectedIndex];
                roomToCreate.isDone = false;
                roomToCreate.winner = "";

                await firebase.CreateRoom(roomToCreate);

                //TODO Update Number of Duels for both players by 1.
                UpdateRoomsList();
                //CheckRooms();
                await DisplayAlert("Success!", "Room Added! Waiting for your opponent..", "OK!");
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }

        }
        
       
    }
}