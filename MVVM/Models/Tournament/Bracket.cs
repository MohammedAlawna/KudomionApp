using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.MVVM.Models.Tournament
{
    public class Bracket
    {
        //Bracket Generation:
        public List<TournamentPlayer> PlayersInTournament { get; private set; } 
            = new List<TournamentPlayer>();
        public List<List<Match>> RoundsInTournament { get; private set; }

        public Bracket(List<TournamentPlayer> playersInTournament) {
        //Check Player Numbers:
        if(playersInTournament.Count < 2 || playersInTournament.Count > 16)
            {
                Debug.WriteLine("The number of players must be between 2 and 16.");
            }

            //Shuffle Players (Using Built-in function):
            PlayersInTournament = playersInTournament.OrderBy(p => Guid.NewGuid()).ToList();

            //Generate Starting Matches (Round 1):


        }    

        private void GenerateInitialMatches()
        {
            try
            {
                //First Round Parameters: 
                int roundNumber = 1;
                List<Match> firstRound = new List<Match>();

                //Looping Through Players To Generate First Round:
                for(int i = 0; i < PlayersInTournament.Count; i += 2)
                {
                    firstRound.Add(new Match
                    {
                        Round = roundNumber,
                        Player1 = PlayersInTournament[i],
                        Player2 = (i + 1 < PlayersInTournament.Count) ? PlayersInTournament[i+1]: null
                });
                }
                RoundsInTournament.Add(firstRound);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
