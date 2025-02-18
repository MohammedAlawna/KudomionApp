using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.Models.Tournament
{
    public class Match
    {
        public int Round { get; set; }
        public TournamentPlayer? Player1 { get; set; }
        public TournamentPlayer? Player2 { get; set; }
        public TournamentPlayer? Winner { get; set; }
        public bool IsCompleted => Winner != null;
    }
}
