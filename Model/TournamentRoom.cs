using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.Model
{
    public class TournamentRoom
    {
        public UserModel p1 { get; set; }
        public UserModel p2 { get; set; }
        public UserModel winner { get; set; }
        public bool isDone { get; set; }
    }
}
