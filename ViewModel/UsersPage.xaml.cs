using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kudomion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
        }

     /*   protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                  myCollectionView.ItemsSource = App.MyDatabase.ReadUsers();
              //  myCollectionView.ItemsSource = await App.MyDatabase.LoginValidate("add", "111");

            }
            catch
            { }
        }*/
    }
}