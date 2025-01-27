using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.MVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MultiplePageContainer : ContentPage
	{
		public MultiplePageContainer(string viewKey)
		{
			InitializeComponent();
			HandleDifferentViews(viewKey);
		}

		void HandleDifferentViews(string view_key)
		{
			if(view_key == "CLASSROOM_VISIBLE")
			{
				ClassroomView.IsVisible = true;
				AnimeView.IsVisible = false;
				GamesView.IsVisible = false;
			}
			if(view_key == "YGOANIME_VISIBLE")
			{
				AnimeView.IsVisible = true;
				ClassroomView.IsVisible = false;
				GamesView.IsVisible = false;
			}
			if(view_key == "GAMESVIEW_VISIBLE")
			{
				GamesView.IsVisible = true;
				ClassroomView.IsVisible = false;
				AnimeView.IsVisible = false;
			}
		}

        //WebView Function Handler:
        async void OpenWebView(string url)
        {
            //string dbUri = "https://www.duelingbook.com"
;          await Navigation.PushAsync(new ConsumableWebView(url));
        }

		//EdoPro Buttons Handler:
		private async void OnEdoProDownloadClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://discord.gg/dtQm932fDB");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "EDOPRO Download", "OK!");
        }

        private async void OnEdoProGuideClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t4197-topic");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "EDOPRO Guide", "OK!");
        }

        //Master Duel Buttons Handler:
        private async void OnMasterDuelDownloadClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://play.google.com/store/apps/details?id=jp.konami.masterduel&hl=en_GB");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "MAster Duel Download", "OK!");
        }

        private async void OnMasterDuelGuideClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://www.youtube.com/watch?v=d-kNrzEEW4g&t=6s");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "MAster Duel Guide.", "OK!");
        }

        //YGO Omega Button Handler:
        private async void OnYGOOmegaDownloadClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://omega.duelistsunite.org/");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
            //Testing Line: 
            //await DisplayAlert("Test!", "YGO Omega Download", "OK!");
        }

        private async void OnYGOOmegaGuideClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t4278-topic");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "YGO Omega Guide", "OK!");
        }


        //MDPro3 Buttons Handler:
        private async void OnMDProDownloadClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://discord.gg/3aDGzqcM8J");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
            //Testing Line: 
            //await DisplayAlert("Test!", "MDPRO Download", "OK!");
        }

        private async void OnMDProGuideClicked(object sender, EventArgs e)
		{
            try
            {
                //TODO
                await DisplayAlert("Note","MDPRO3 guide will be added in later releases.", "OK!");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "MDPRO Guide", "OK!");
        }

        //Duel Links Buttons Hnadler: 
        private async void OnDuelLinksDownloadClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://play.google.com/store/apps/details?id=jp.konami.duellinks&hl=en_GB&pli=1");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "Duel Links Download", "OK!");
        }

        private async void OnDuelLinksGuideClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t4167-topic");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "Duel Links Guide", "OK!");
        }

		//Dueling Book Buttons Handler: 
		private async void OnDuelingBookDownloadClicked(object sender, EventArgs e)
		{
            try
            {
                OpenWebView("https://www.duelingbook.com");

              /*  string dbUri = "https://www.duelingbook.com"
;               await Navigation.PushAsync(new ConsumableWebView(dbUri));
                Uri dbUri = new Uri("https://www.duelingbook.com");
                await Browser.OpenAsync(dbUri);*/
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }

            //Testing Line: 
            //await DisplayAlert("Test!", "DuelingBook Download", "OK!");
        }
		private async void OnDuelingBookGuideClicked(object sender, EventArgs e)
		{
			try
			{
                OpenWebView("https://yukajoi.yoo7.com/t102-topic");
			}
			catch(Exception ex)
			{
				await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
			}            
			//Testing Line: 
           // await DisplayAlert("Test!", "DuelingBook Guide.", "OK!");
        }

        private async void OnYubelViewClicked(object sender, EventArgs e)
        {
            try
            {
                //TODO:: Pop-Up prompt embedded with DeckBuildViewImage.
                OpenWebView("https://ibb.co/drzVZ3X");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnYubelComboClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://www.youtube.com/watch?v=ecqpsq7I3_A&t=1s&pp=ygUTa3Vkb21pb24g2YrZiNio2YrZhA%3D%3D");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnTenpaiComboClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://www.youtube.com/watch?v=MQFa20zgDfw&t=3s");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnTenpaiViewClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://ibb.co/y6yV54H");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnDragonLinkComboClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://www.youtube.com/watch?v=ygABpoxmgtc");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnDragonLinkViewClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://ibb.co/TBr68FL");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnFireKingComboClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://www.youtube.com/watch?v=Y2khxseopI0");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnFireKingViewClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://ibb.co/sHThHK3");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnYGOReportClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://www.fb.com/groups/yukajo");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnYGODMClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t3133-topic");
            }
            catch(Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnYGOGXClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t2724-topic");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnYGO5DsClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t3133-topic");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnYGOZexalClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t4524-topic");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

        private async void OnYGOMoviesClicked(object sender, EventArgs e)
        {
            try
            {
                OpenWebView("https://yukajoi.yoo7.com/t4273-topic");
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps!", "There was an error in your proces. Please try again later or contact the developer.", "OK!");
            }
        }

    }
}