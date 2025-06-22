using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace KudomionApp.MVVM.Models.Chat
{
    //Firestore Attributes to avoid any error regarding conversion to document in collection. (serialize/deserialize)
    [FirestoreData]
    public class Message
    {
        public Message() { }


        //Unique Identifier for the Message.
        [FirestoreProperty]
        public string Id { get; set; }

        //Unique Identifier for this message's chat (Where it belongs)
        [FirestoreProperty]
        public string ChatId { get; set; }

        //Unique Identifier for the User who sent this message
        [FirestoreProperty]
        public string SenderId { get; set; }

        //The Message's content (Hello World, etc..)
        [FirestoreProperty]
        public string Content { get; set; }

        //The Time when the message was sent.
        [FirestoreProperty]
        public DateTime MessageTimeStamp { get; set; }

        //Was the Message Fired, Landed, Spotted.
        [FirestoreProperty]
        public string Status { get; set; }

    }

   
    //Enum can cause some issues with firebase so, string will be sued for status:
   /* public enum MessageStatus
    {
        Fired, //Means Sent 
        Landed, //Means Delivered
        Spotted //Means Seen
    }*/
}
