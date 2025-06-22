using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.Models.Chat
{
    //Firestore Attributes to avoid any errors resuling from converting chat to firestore document.
    [FirestoreData]
   public class Chat
    {
        public Chat() { }


        //Unique Identifier for the chat/conversation
        [FirestoreProperty]
        public string Id { get; set; }

        //If True: This is clan chat (special permissions for each clan)
        //If False: It will be private user to user chat.
        [FirestoreProperty]
        public bool IsClan { get; set; }

        //If True: This is public chatto everyone,
        //If False: Private chat or group.
        [FirestoreProperty]
        public bool IsPublic { get; set; }

        //Unique Identifier for Users in the Chat.
        [FirestoreProperty]
        public List<string> ParticipantsIDs { get; set; }
    }
}
