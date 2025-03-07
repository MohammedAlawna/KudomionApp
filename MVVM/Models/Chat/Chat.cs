using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.Models.Chat
{
    class Chat
    {

        //Unique Identifier for the chat/conversation
        public string Id { get; set; }

        //If True: This is clan chat (special permissions for each clan)
        //If False: It will be private user to user chat.
        public bool IsClan { get; set; }

        //If True: This is public chatto everyone,
        //If False: Private chat or group.
        public bool IsPublic { get; set; }

        //Unique Identifier for Users in the Chat.
        public List<string> ParticipantsIDs { get; set; }
    }
}
