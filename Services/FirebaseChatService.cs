using KudomionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;

namespace KudomionApp.Services
{
    public class FirebaseChatService : IFirebaseChatService
    {
        private readonly FirebaseFirestore _firestore;

        public FirebaseChatService()
        {
            _firestore = FirebaseStore.Instance;
        }
    }
}
