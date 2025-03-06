# Kudomion

Kudomion is a .NET MAUI social media application built for the Yu-Gi-Oh! community, offering a modern way for duelists to connect, compete, and share strategies. It represents the Yukajo Duel Academy forum (est. 2008) and brings its competitive scene into a modern mobile and desktop experience.

> 🛠 Started in 2022 using Xamarin, later upgraded to .NET MAUI. Due to compatibility issues with NuGet package versions, the project was fully migrated to a new repository for stability and maintainability.


# 🚀 Features & Functionality


## 🎮 Tournament System

A bracket-based tournament system designed for competitive Yu-Gi-Oh! events:

✔ Fixed 16-Player Format (Structured rounds: Round 1 → Quarter-Finals → Semi-Finals → Finals).

✔ Automated Pairing & Match Progression.

✔ Dynamic UI for Tracking Brackets.

📌 Screenshot

<div>
<img width="145" height="250" src="https://i.imgur.com/UTbpHO2.png">
<img width="145" height="250" src="https://i.imgur.com/ohGxkvD.png">
<img width="145" height="250" src="https://i.imgur.com/NH0IWlB.png">
<img width="145" height="250" src="https://i.imgur.com/corI7Pi.png">
</div>


💡 Code Snippet (Match Making, Advancing to next round, etc.)

### Advance Winner
```
public void AdvanceWinner(TournamentPlayer winner, int roundNumber)
{
    try
    {
        //Check if Tournaments is still not finished:
        if(RoundsInTournament.Count <= roundNumber)
        {
            RoundsInTournament.Add(new List<Match>());
        }

        List<Match> nextRound = RoundsInTournament[roundNumber];

        if(nextRound.Count * 2 < RoundsInTournament[roundNumber - 1].Count)
        {
            nextRound.Add(new Match
            {
                Round = roundNumber + 1, 
                Player1 = winner
            });
        }
        else
        {
            nextRound[^1].Player2 = winner;
        }
    }
    catch(Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
}
```

### Generate Initial Matches (For the first round)
```
private void GenerateInitialMatches()
{
    try
    {
        //First Round Parameters: 
        int roundNumber = 1;
        List<Match> firstRound = new List<Match>();

        //Looping Through Players To Generate First Round:
        for (int i = 0; i < PlayersInTournament.Count; i += 2)
        {
            //If No Odd:
            if (i + 1 < PlayersInTournament.Count)
            {
                firstRound.Add(new Match
                {
                    Round = roundNumber,
                    Player1 = PlayersInTournament[i],
                    Player2 = PlayersInTournament[i + 1]
                });
            }
            else
            {
                //If Odd, Auto advanice winner, dont make empty match:
                firstRound.Add(new Match
                {
                    Round = roundNumber,
                    Player1 = PlayersInTournament[i],
                    Winner = PlayersInTournament[i] 
                });
            }
                }
                RoundsInTournament.Add(firstRound);
            } 
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
}
```

***
## 🏆 Leaderboard & League System

A ranking system for competitive duelists:

✔ Players can initiate duels and report results.

✔ Win = +3 points (Winner is awarded points after the opponent confirms defeat).

✔ Supports Monthly Leagues & Special Events.

📌 Screenshot

<div>
<img width="145" height="250" src="https://i.imgur.com/HaRAtSi.png">
<img width="145" height="250" src="https://i.imgur.com/zbqUZyH.png">
</div>

💡 CS (CreateRoom, Admit Defeat, Points-Based Ranking System, etc..)
### CreateRoom
```
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
```

### AdmitDefeat
```
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
```

### Points-Based Ranking System
```
public async void RankAllUsers()
{
    try
    {
        List<UserModel> allUsers = await firebaseHelper.GetAllUsers();
        var rankedUsers = allUsers.OrderByDescending(p => p.points);
        var rankedList = rankedUsers.ToList();

        userRankingsToLoad.ItemsSource = rankedUsers;

        
    }
    catch(Exception ex)
    {
        await DisplayAlert("Error!", $"Unexpected problem occured: {ex.Message}", "OK!");
    }
}
```

## 📂 Yu-Gi-Oh! Deck Library

A deck-sharing platform for players to explore and download competitive deck builds:

✔ View Decks with detailed builds.

✔ Download .YDK deck files (for use in YGOPro/EdoPro).

✔ Generate YDKE codes for easy online sharing.

✔ Deck Tutorials, Combos, and Strategy Guides.

📌 Screenshot

<div>
<img width="145" height="250" src="https://i.imgur.com/29CzgRh.png">
</div>

💡 CS (YDKe Import)

### Convert YDKe (YDK to YDKE)
```
public string ConvertToYDKE(string ydkPath)
    {
        if (!File.Exists(ydkPath)) return "File not found.";

        var lines = File.ReadAllLines(ydkPath)
                        .Where(l => !l.StartsWith("#") && !string.IsNullOrWhiteSpace(l))
                        .ToList();

        int sideIndex = lines.IndexOf("!side");
        var mainDeck = string.Concat(lines.Take(sideIndex));
        var sideDeck = string.Concat(lines.Skip(sideIndex + 1));

        return $"https://ygoprodeck.com/deck/?ydke={mainDeck}!!{sideDeck}";
    }
```

## 💬 Real-Time Chat System

A built-in chat feature designed for duelists:

✔ One-on-One & Group Chats.

✔ Instant Messaging with Firebase Backend.

✔ Yu-Gi-Oh! Themed Emojis & Reactions.

📌 Screenshot in app, and Systematic Design of the Chat System

💡 CS


## 🔍 User Profiles & Search System

✔ User Profile Viewing (Check duelists’ rankings, activity, and achievements).

✔ Search Functionality (Find duelists, decks, and tournaments).

📌 Screenshot

<div>
<img width="145" height="250" src="https://i.imgur.com/mTBR34k.png">
</div>

## 🔐 Authentication System (Powered by Firebase)

✔ Secure Email & Password Login.

✔ Email Verification & Password Reset.

✔ Push Notifications (via Firebase & Azure).

💡 Firebase User Model - Secure Implementation

>  This implementation follows separation of concerns, ensuring Firebase authentication is separate from user data storage while keeping security and scalability in mind.

> In this implementation, Firebase Authentication is used to handle user sign-ups and logins, ensuring that authentication logic is completely separate from user data storage. A base user model (FirebaseUser) is created to store only essential authentication details like the UID and email, maintaining a clear distinction between authentication and application-specific data.

> To extend user information, a UserProfile model is introduced, which inherits from the base authentication model and includes custom fields like Points, USERTYPE, Ranking and etc..

> A dedicated authentication service is implemented to interact with Firebase Auth, handling user registration and login securely. Separately, a user profile service is responsible for storing and retrieving user data from Firestore, ensuring that the application remains modular and scalable.

> To enforce security, Firestore Security Rules are applied, ensuring that users can only read and modify their own data, preventing unauthorized access. This ensures data integrity and security, following Firebase best practices.


### UserModel.cs

```
public class UserModel
{
    public string Id { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public string JoinedAt { get; set; }
    public bool isVerified { get; set; }

    public List<UserModel> friendsList { get; set; }
    public List<UserModel> blockedList { get; set; }
    public List<UserModel> friendRequests { get; set; }
    public int posts { get; set; }

    public int duels { get; set; }
    public int ranking { get; set; }
    public int points { get; set; }
  
    public string usertype { get; set; }
    
    public string password { get; set; }
   
    public string NumberOfPosts
    {
        get
        {
            return posts.ToString();
        }
    }

    public UserModel()
    {
        friendRequests = new List<UserModel>();
        friendsList = new List<UserModel>();
        blockedList = new List<UserModel>();
    }
}
```

### Create User in Firebase, Add it to your realtime DB:
```
await mainAuthProvider.authProvider.SendEmailVerificationAsync(newUserCreated.FirebaseToken);

var userID = await mainAuthProvider.authProvider.GetUserAsync(newUserCreated.FirebaseToken); 

//Register User in RealTime DB (UserModel):
await firebase.AddUser(userName.Text, userID.LocalId);
```

## 📰 News System with Custom Reactions

✔ Yu-Gi-Oh! Themed News Feed.

✔ Customizable Reactions (Like Facebook, but optimized for Yu-Gi-Oh!).

✔ Community Discussions & Announcements.

📌 SS

💡 CS (Custom Reaction, React)


## ⚙️ Tech Stack & Development History

Frontend & Backend: .NET MAUI (Previously Xamarin).

Database & Authentication: Firebase.

Cloud Services: Azure (for notifications).


## Project Evolution

1️⃣ Started in 2022 with Xamarin as the initial framework.

2️⃣ Upgraded to .NET MAUI to ensure better cross-platform support.

3️⃣ Full migration to a new repository due to NuGet package conflicts.

4️⃣ Current Stable Version runs on .NET MAUI with Firebase & Azure.


## 📌 Older Repositories (For Reference & Learning):

🔗 Xamarin Version: https://github.com/MohammedAlawna/Kudomion

🔗 Early .NET MAUI Version (Before Migration): https://github.com/MohammedAlawna/KudomionMAUi


## 🛠 Installation & Setup

1️⃣ Clone the repository

```
git clone https://github.com/yourusername/Kudomion.git
cd Kudomion
```

2️⃣ Setup Firebase (Authentication, Firestore, Push Notifications).

3️⃣ Configure .NET MAUI Dependencies.

4️⃣ Run the application

```
dotnet build
dotnet run
```
***


## 👨‍💻 Your Role & Contributions

This project is a fully self-developed application, highlighting:

✔ Expertise in .NET MAUI and cross-platform development.

✔ Firebase integration (Authentication, Database, Push Notifications).

✔ Azure cloud implementation.

✔ Handling migrations from Xamarin to .NET MAUI.

✔ Building a complete tournament, league, and chat system from scratch.


## 🎯 Why This Project Matters for Startups

🔹 Scalable & Modern Tech Stack – Uses .NET MAUI, Firebase, and Azure.

🔹 Real-World Application – Designed for a global gaming community.

🔹 Advanced Features – Competitive rankings, real-time chat, deck library.

🔹 Demonstrates Full-Stack Capability – Frontend, Backend, Cloud Services.

🔹 Cross-Platform Readiness – Works on Android, iOS, and Windows.
