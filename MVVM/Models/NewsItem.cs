using Kudomion.FirebaseManager;
using Kudomion.Model;


/* Unmerged change from project 'Kudomion (net8.0-android)'
Before:
using System;
After:
using Kudomion.MVVM;
using Kudomion.MVVM.Models;
using Kudomion.MVVM.Models;
using Kudomion.MVVM.Models.NewsContainer;
using System;
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.MVVM.Models
{
    public class NewsItem
    {
        public string Psrc { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        
        public List<Reactions> ListOfReactions { get; set; }
        public int NoLoveReactions { get; set; }
        public int NoLaughReactions { get; set; }

        private bool lovedPost;
        public bool LovedPost
        {
            get
            {
                List<string> LoveReactants = new List<string>();
                foreach(var l in ListOfReactions)
                {
                    if(l.typeOfReaction == "LOVE")
                    {
                        LoveReactants.Add(l.userThatReacted.name);
                    }
                }
                bool DidUserLovePost = LoveReactants.Contains(MainPage.currentLoggedInUser);
                return DidUserLovePost;
            }

            set
            {
                lovedPost = value;
            }
        }
        private bool laughedAtPost;
        public bool LaughedAtPost {
            get
            {
                List<string> LaughReactants = new List<string>();
                foreach (var r in ListOfReactions)
                {
                    if (r.typeOfReaction == "LAUGH")
                    {
                        LaughReactants.Add(r.userThatReacted.name);
                    }
                }
                bool DidUserLaughAtPost = LaughReactants.Contains(MainPage.currentLoggedInUser);
                return DidUserLaughAtPost;
            }
            set
            {
                laughedAtPost = value;
            }
        }

        private string laughBtnReactedColor;
        public string LaughBtnReactedColor { 
            get
            {
                if(laughedAtPost == true)
                {
                    return "RoyalBlue";
                }
                else
                {
                    return "#1c1c1c";
                }
            }
            set
            {
                laughBtnReactedColor = value;
            }
        }

        private string loveBtnReactedColor;
        public string LoveBtnReactedColor { 
            get
            {
                if (LovedPost)
                {
                    return "RoyalBlue";
                }
                else
                {
                    return "#1c1c1c";
                }
            }
            set
            {
                loveBtnReactedColor = value;
            }
        }

        public NewsItem()
        {
        }
    }

}
