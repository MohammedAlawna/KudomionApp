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


💡 Code Snippet (Match Making)

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

💡 Code Snippet (Points-Based Ranking System)

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

> To extend user information, a UserModel is introduced, which inherits from the base authentication model and includes custom fields like Points, USERTYPE, Ranking and etc..

> A dedicated authentication service is implemented to interact with Firebase Auth, handling user registration and login securely. Separately, a user model service is responsible for storing and retrieving user data from Firestore, ensuring that the application remains modular and scalable.

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

📌 Screenshot

<div>
<img width="145" height="250" src="https://i.imgur.com/XeMe2Yg.png">
</div>

## Chat System Architecture - MVP & Scalability Plan

### 📌 Overview

The following depicts the design and implementation of the chat system, starting with Firebase for the MVP and ensuring flexibility for SignalR integration in future releases.

#### 🛠️ MVP: Firebase-Based Chat System

✅ User Authentication (via Firebase Auth).

✅ Private Chats & Public Channels.

✅ Message Sending & Receiving (Firestore-based real-time updates).

✅ Push Notifications (Firebase Cloud Messaging - FCM).

✅ Basic Message Actions (Send, Delete).

MVP: Basic Data Structure
```
Users Collection:
  - userId (string)
  - username (string)
  - lastSeen (timestamp)
  - isOnline (boolean)

Chats Collection:
  - chatId (string)
  - participants ([userId, userId])
  - lastMessage (string)
  - lastUpdated (timestamp)

Messages Collection:
  - messageId (string)
  - chatId (string)
  - senderId (string)
  - content (string)
  - timestamp (timestamp)
  - isDeleted (boolean)
```

### 📈 Future Plan: SignalR Integration

While Firebase provides a simple and effective chat solution, it has limitations in tracking presence, message delivery status, and handling heavy traffic efficiently.

To scale the chat system, we will introduce ASP.NET Core with SignalR for real-time communication.

📍 Features After MVP (With SignalR)

✅ Real-time message delivery using SignalR instead of Firestore reads.

✅ Presence Tracking (See who is online).

✅ Typing Indicators (Live feedback when someone is typing).

✅ Message Status Updates (Sent, Delivered, Seen).

✅ Better Scalability & Cost Optimization (Less Firestore reads).

📍 How SignalR Works in the Chat System
```
1- Client (Mobile/Web App) Connects to SignalR Hub
2- Establishes a WebSocket connection for real-time communication.
Sending Messages
3- When a user sends a message, it is sent to the SignalR Hub, stored in the SQL database, and broadcast to other clients in real time.
4- Tracking Message Status (Delivered/Seen)
5- When a recipient opens a message, SignalR updates the status instantly.
6- Presence Tracking (Online/Offline Users)
7- SignalR keeps track of connected users and updates their status.
```

## Chat System Data Model & Performance Optimization

Why Use IDs Instead of Full User Objects?

> To ensure performance, scalability, and efficiency, we store only user IDs in chats instead of full user objects.

### Why This Matters?

✔ Efficiency & Performance: If a user is in 500 chats, storing full user objects would duplicate data, slowing down reads and increasing storage costs.

✔ Data Consistency: User profile updates (e.g., username, avatar) instantly reflect across all chats without redundant updates.

✔ Faster Queries: We fetch user details only when needed, keeping chat documents lightweight.

## Message Storage Optimization

Instead of embedding messages in chat documents, we store them in a separate Messages collection:
```
Chats Collection:
  - chatId (string)
  - participants (array of userIds)

Messages Collection:
  - messageId (string)
  - chatId (string)
  - senderId (string)
  - content (string)
  - timestamp (timestamp)
```

Why Separate Messages?

✔Scalability: Chat documents won’t grow indefinitely, preventing performance issues.

✔Faster Load Times: Chat metadata loads instantly without fetching all messages.

✔Efficient Message Management: Supports pagination, edits, and deletions without affecting chat structure.

## Built for Future Growth

Our approach ensures a lightweight, high-performance chat system that can scale for millions of users while keeping storage optimized. Future enhancements like SignalR, typing indicators, and multimedia support can be seamlessly integrated without major refactoring.

## 🔄 Transition Plan: From Firebase to SignalR
1️⃣ Start with Firebase (Fast MVP launch).
2️⃣ Modify Data Structure to Support Both Firebase & SignalR.
3️⃣ Introduce SignalR as a Parallel System for Real-Time Updates.
4️⃣ Slowly Reduce Firestore Reads & Move to SQL + SignalR for Scalability.

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
