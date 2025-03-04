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
          
        public List<List<Match>> RoundsInTournament { get; private set; }

        public Bracket(List<TournamentPlayer> playersInTournament) {
        //Check Player Numbers:
        if(playersInTournament.Count < 2 || playersInTournament.Count > 16)
            {
                throw new ArgumentException("The number of players must be between 2 and 16.");

                
            }

            //Shuffle Players (Using Built-in function):
            PlayersInTournament = playersInTournament.OrderBy(p => Guid.NewGuid()).ToList();

            //Generate Starting Matches (Round 1):
            GenerateInitialMatches();

        }    

        private void GenerateInitialMatches()
        {
            try
            {
                //First Round Parameters: 
                int roundNumber = 1;
                List<Match> firstRound = new List<Match>();

                //Looping Through Players To Generate First Round:
                for (int i = 0; i < PlayersInTournament.Count; i += 2)
                {
                    //If No Odd:
                    if (i + 1 < PlayersInTournament.Count)
                    {
                        firstRound.Add(new Match
                        {
                            Round = roundNumber,
                            Player1 = PlayersInTournament[i],
                            Player2 = PlayersInTournament[i + 1]
                        });
                    }
                    else
                    {
                        //If Odd, Auto advanice winner, dont make empty match:
                        firstRound.Add(new Match
                        {
                            Round = roundNumber,
                            Player1 = PlayersInTournament[i],
                            Winner = PlayersInTournament[i] 
                        });
                    }
                        }
                        RoundsInTournament.Add(firstRound);
                    } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void AdvanceWinner(TournamentPlayer winner, int roundNumber)
        {
            try
            {
                //Check if Tournaments is still not finished:
                if(RoundsInTournament.Count <= roundNumber)
                {
                    RoundsInTournament.Add(new List<Match>());
                }

                List<Match> nextRound = RoundsInTournament[roundNumber];

                if(nextRound.Count * 2 < RoundsInTournament[roundNumber - 1].Count)
                {
                    nextRound.Add(new Match
                    {
                        Round = roundNumber + 1, 
                        Player1 = winner
                    });
                }
                else
                {
                    nextRound[^1].Player2 = winner;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
