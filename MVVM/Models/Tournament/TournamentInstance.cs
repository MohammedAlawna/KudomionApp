using Android.Net.Wifi.Aware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.Models.Tournament
{
    //This model is different from the tournament previous data model.
    //This model is more improved and expandable, currently it handles up to 16 participants.
    public class TournamentInstance
    {
        public string TournamentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isActive { get; set; } = true;
        public List<TournamentPlayer> Players { get; set; } = new();
        public List<List<Match>> Rounds { get; set; } = new();

        //This parameterless constructor is used for FB, data retrieval.
        //FB requires empty constructor.
        //For Deserialization: converting stored data json etc from FB back to C sharp objects.
        public TournamentInstance()
        {

        }

        public TournamentInstance(string name)
        {
            //Assign Unique ID, as this is FB entity:
            TournamentId = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}
