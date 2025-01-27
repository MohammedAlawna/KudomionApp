using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.MVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsumableWebView : ContentPage
    {
        public ConsumableWebView(string targetUri)
        {
            InitializeComponent();
            LoadDesiredWebView(targetUri);
        }

        void LoadDesiredWebView(string target_uri)
        {
            try
            {
                webUri.Source = target_uri;
            } 
            catch(Exception ex)
            {
                DisplayAlert("Error", "There was a problem processing the web view. Please contact developer.", "OK!");
            }

        }
    }
}