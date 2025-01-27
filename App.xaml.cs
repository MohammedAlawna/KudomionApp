using Kudomion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudomion;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override async void OnStart()
    {
		//await Shell.Current.GoToAsync("//DecksList");

        base.OnStart();
    }

}
