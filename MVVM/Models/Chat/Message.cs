using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace KudomionApp.MVVM.Models.Chat
{
    public class Message
    {
        //Unique Identifier for the Message.
        public string Id { get; set; }

        //Unique Identifier for this message's chat (Where it belongs)
        public string ChatId { get; set; }

        //Unique Identifier for the User who sent this message
        public string SenderId { get; set; }

        //The Message's content (Hello World, etc..)
        public string Content { get; set; }

        //The Time when the message was sent.
        public DateTime MessageTimeStamp { get; set; }

        //Was the Message Fired, Landed, Spotted.
        public MessageStatus Status { get; set; }

    }

    enum MessageStatus
    {
        Fired, //Means Sent 
        Landed, //Means Delivered
        Spotted //Means Seen
    }
}
