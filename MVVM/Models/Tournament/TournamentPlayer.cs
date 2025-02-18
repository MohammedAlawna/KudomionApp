using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.Models.Tournament
{
    public class TournamentPlayer
    {
        public string TournamentId { get; set; }
        public UserModel Player { get; set; }
        public bool Eliminated { get; set; }
    }
}
