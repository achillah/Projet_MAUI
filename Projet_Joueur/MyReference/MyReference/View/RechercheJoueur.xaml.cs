namespace MyReference.View;

public partial class RechercheJoueur : ContentPage
{
	public RechercheJoueur(RechercheViewModel rechercheViewModel)
	{
		InitializeComponent();
		BindingContext= rechercheViewModel;
	}
}