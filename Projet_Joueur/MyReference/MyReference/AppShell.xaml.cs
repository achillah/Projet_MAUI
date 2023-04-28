namespace MyReference;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(JoueurPage), typeof(JoueurPage));
        Routing.RegisterRoute(nameof(AjouterJoueur), typeof(AjouterJoueur));
        Routing.RegisterRoute(nameof(ModifierJoueur), typeof(ModifierJoueur));
        Routing.RegisterRoute(nameof(RechercheJoueur), typeof(RechercheJoueur));

    }
}
