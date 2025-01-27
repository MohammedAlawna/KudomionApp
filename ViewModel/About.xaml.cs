using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void DiscordClicked(object sender, EventArgs e)
        {
            string discord = "https://discord.gg/TMQkVvtzZt";
            Browser.OpenAsync(discord);
        }

        private void YoutubeClicked(object sender, EventArgs e)
        {
            string youtubeLink = "https://www.youtube.com/@kudomion.";
            Browser.OpenAsync(youtubeLink);
        }

        private void FacebookClicked(object sender, EventArgs e)
        {
            string fb = "https://www.facebook.com/groups/yukajo";
            Browser.OpenAsync(fb);
            
        }

        private void BlogClicked(object sender, EventArgs e)
        {
            string blogUrl = "https://www.yukajo.org";
            Browser.OpenAsync(blogUrl);
        }

        private void YKJPtmClicked(object sender, EventArgs e)
        {
            string YKJPtmUrl = "http://www.yukajoi.yoo7.com";
            Browser.OpenAsync(YKJPtmUrl);
        }

        private void YKJOmaClicked(object sender, EventArgs e)
        {
            string YKJOmaUrl = "http://www.yukajo.yoo7.com";
            Browser.OpenAsync(YKJOmaUrl);
        }

    }
}