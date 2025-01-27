using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.Model
{
    public class Tournament
    {
        public string title { get; set; }
        public UserModel winner { get; set; }
        public UserModel secondPlace { get; set; }
        public UserModel thirdPlace { get; set; }
        public bool signUpActive { get; set; }
        public string tournyBannerSrc { get; set; }
        public List<UserModel> registeredUsers { get; set; }
        public List<UserModel> semiFinals { get; set; }
        public List<UserModel> final { get; set; }

        public Tournament()
        {
            registeredUsers = new List<UserModel>();
            semiFinals = new List<UserModel>();
            final = new List<UserModel>();
        }
    }
}
