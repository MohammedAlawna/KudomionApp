using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.MVVM.Models
{
    public class Reactions
    {
        public UserModel userThatReacted { get; set; }

        //Values KeyMap: {(Love => "LOVE"), (Laugh => "LAUGH")}
        public string typeOfReaction { get; set; }
    }
}
