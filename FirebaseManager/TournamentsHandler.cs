using Firebase.Database;
using Kudomion.Model;
using KudomionApp.MVVM.Models.Tournament;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                await firebaseClient.Child("tournies").Client(tournament.TournamentId).
                    PutAsync(tournament);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}" );
            }
        }
    }
}
