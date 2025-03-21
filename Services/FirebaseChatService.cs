using KudomionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using KudomionApp.MVVM.Models.Chat;
using System.Diagnostics;



namespace KudomionApp.Services
{
    public class FirebaseChatService : IFirebaseChatService
    {
        private readonly FirestoreDb _firestore;

        public FirebaseChatService()
        {
            //Firestore Instance replaced with Google Cloud ID.
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
                MessageTimeStamp = DateTimeOffset.UtcNow,
                Status = MessageStatus.Fired
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

        public async Task<List<Message>> GetMessagesAsync(string chatId)
        {
            try
            {
                //List of Messages
                var messages = new List<Message>();

                //User the new GetSnapshotAsync() to fetch the required chat's data:
                var querySnap = await _firestore.Collection("Messages").
                    WhereEqualTo("ChatId", chatId).
                    OrderBy("MessageTimestamp")
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
                Debug.WriteLine("Exception Occurred: " + ex.Message);
                return null;
            }

        }

    }
}
