using KudomionApp.MVVM.Views;

namespace Kudomion;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Register Route for Private Chat in Navigation App Shell:
		Routing.RegisterRoute("PrivateChat", typeof(PrivateChat));
	}
}
