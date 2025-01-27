using Kudomion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.MVVM.Models.Rooms
{
    public class LimitedDuel
    {
        public UserModel p1;
        public UserModel p2;
        //the countdown timer property should be here.
        /*The following isDonw when isTure, this
        specificLimitedDuel will be deleted from dB.*/
        bool isDone = false;

        LimitedDuel()
        {
            //Invoke Timer:
            //Timer Set from MS to Days using TimeSpan:
            var oneDayTimer = new System.Timers.Timer(
                TimeSpan.FromHours(24).TotalMilliseconds);
            //The oneDayTimer should be linked with room:
            //When it's up and hits the desired goal, dest:
            //Will be testing it at the mainPage:

            //When 24hrs passed delete obj:

        }
    }
}
