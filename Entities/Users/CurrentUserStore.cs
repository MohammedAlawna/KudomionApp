using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.Entities.Users
{
    public class CurrentUserStore
    {
        public User CurrentUser { get; set; }
    }
}
