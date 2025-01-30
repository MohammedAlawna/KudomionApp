using System;
using System.Collections.Generic;
using System.Text;

namespace Kudomion.Model
{
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
}
