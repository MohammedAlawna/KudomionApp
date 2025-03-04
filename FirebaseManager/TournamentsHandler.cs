using Firebase.Database;
using Firebase.Database.Query;
using Kudomion.Model;
using KudomionApp.MVVM.Models.Tournament;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KudomionApp.FirebaseManager
{
    public class TournamentsHandler
    {
        private readonly FirebaseClient firebaseClient;

        public TournamentsHandler()
        {
            firebaseClient = new FirebaseClient("https://kudo1-38995-default-rtdb.firebaseio.com/");
        }

        public async Task SaveTournament(TournamentInstance tournament)
        {
            try
            {
                await firebaseClient.Child("tournies").Child(tournament.TournamentId).
                    PutAsync(tournament);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}" );
            }
        }

        public async Task<TournamentInstance> GetTournament(string tournamentId)
        {
          try
            {
                return await firebaseClient.Child("tournies").Child(tournamentId)
                  .OnceSingleAsync<TournamentInstance>();
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }
              
           
           
        }
    }
}