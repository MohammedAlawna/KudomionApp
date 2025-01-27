
using System;
using System.Collections.Generic;
using System.Text;

namespace Kudomion
{
    public class Room
    {

       
        public int Id { get; set; }

        //First Player "p1" (p1: is the hoster as well).
        public string p1 { get; set; }

        public string p2 { get; set; }

        // STATUS = TRUE, means the match is done!
        public bool isDone { get; set; }

        public bool disabled { get; set; }

        public string winner { get; set; }

    }
}
