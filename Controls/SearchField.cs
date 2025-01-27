using Kudomion.FirebaseManager;
using Kudomion.Model;
using Kudomion.ViewModel;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion.Controls
{
    public class SearchField : SearchHandler
    {
        //FirebaseHelper firebase;

        public IList<UserModel> Users { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Users.Where(user => user.name.ToLower()
                .Contains(newValue.ToLower())).ToList();
            }


        }

        protected override async void OnItemSelected(object item)
        {
            
            base.OnItemSelected(item);

            try
            {
                //Get The Name of Selected Item (onClick)
                var getIt = (UserModel)item;
                var getName = getIt.name;
                Console.WriteLine("Selected Item is: " + getName);


                //Navigate to Selected User Page.
                await Shell.Current.Navigation.PushAsync(new UserProfile(getName));
            }

            catch(Exception ex)
            {
               Debug.WriteLine("An unexpected error just occured! " + ex.Message);
            }
        }
    }
}
