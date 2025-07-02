using KudomionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using KudomionApp.MVVM.Models.Chat;
using System.Diagnostics;
using Google.Cloud.Firestore.V1;
using Google.Apis.Auth.OAuth2;
using System.Threading.Channels;
//using AVFoundation;



namespace KudomionApp.Services
{
    public class FirebaseChatService : IFirebaseChatService
    {

        private readonly FirestoreDb _firestore;

        public FirebaseChatService()
        {
            //  D:\fbkeys\serviceAcc.json
            // string path = @"C:\Users\YourName\firebase-keys\kudo1-service-account.json";


            /*   string path = "D:/fbkeys/serviceAcc.json";
               Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
               _firestore = FirestoreDb.Create("kudo1-38995");*/
            //Firestore Instance replaced with Google Cloud ID.

            var fileName = "serviceAcc.json";
            var destinationPath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            // Only copy once
            if (!File.Exists(destinationPath))
            {
                using var stream = FileSystem.OpenAppPackageFileAsync(fileName).Result;
                using var fileStream = File.Create(destinationPath);
                stream.CopyTo(fileStream);
            }

            // Set environment variable for Google APIs
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", destinationPath);

            // Create Firestore instance
            _firestore = FirestoreDb.Create("kudo1-38995");

        }

        //Create New Chat and Store It In Firestore:
        public async Task<string> CreateChatAsync(List<string> participantsIds, bool isPublic, bool isClan)
        {
            try
            {
                var chat = new Chat
                {
                    Id = Guid.NewGuid().ToString(),
                    IsPublic = isPublic,
                    IsClan = isClan,
                    ParticipantsIDs = participantsIds
                };

                //ref doc in Firestore:
                var docRef = _firestore.Collection("Chats").Document(chat.Id);
                await docRef.SetAsync(chat);
                return chat.Id;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception occurred: " + ex.Message);
                return "";
            }
        }

        //Send new Message and Store It in Firestore
        public async Task SendMessageAsync(string chatId, string senderId, string content)
        {
            try
            {
                var message = new Message {
                Id = Guid.NewGuid().ToString(),
                ChatId = chatId,
                SenderId = senderId,
                Content = content,
                MessageTimeStamp = DateTime.UtcNow,
                Status = "SENT",
                };

                //Store in Messages / Firestore Collection:
                var docRef = _firestore.Collection("Messages").Document(message.Id);
                await docRef.SetAsync(message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception occurred: " + ex.Message);
                
            }

        }



        public async Task<List<Chat>> GetChatsForUserAsync(string userId)
        {
            try
            {
                var chats = new List<Chat>();

                var querySnapshot = await _firestore.Collection("Chats").
                    WhereArrayContains("ParticipantsIDs", userId).GetSnapshotAsync();

                foreach(var document in querySnapshot.Documents)
                {
                    var chat = document.ConvertTo<Chat>();
                    chats.Add(chat);
                }
                return chats; 
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception occurred while getting chats: " + ex.Message);
                return new List<Chat>();
            }
        }

        public async Task<List<Message>> GetMessagesAsync(string chatId)
        {
            try
            {
                //List of Messages
                var messages = new List<Message>();

                //User the new GetSnapshotAsync() to fetch the required chat's data:
                var querySnap = await _firestore.Collection("Messages").
                    WhereEqualTo("ChatId", chatId).
                    OrderBy("MessageTimeStamp")
                    .GetSnapshotAsync();

                foreach(var document in querySnap.Documents)
                {
                    var message = document.ConvertTo<Message>();
                    messages.Add(message);
                }

                return messages;

            }

            catch(Exception ex)
            {
                Debug.WriteLine("Exception Occurred: " + ex);
                return new List<Message>();
            }

        }

    }
}
