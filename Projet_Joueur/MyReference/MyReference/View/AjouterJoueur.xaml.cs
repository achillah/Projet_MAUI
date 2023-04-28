namespace MyReference.View;

public partial class AjouterJoueur : ContentPage
{
	public AjouterJoueur(AjouterJoueurViewModel addJoueurViewModel)
	{
		InitializeComponent();
		BindingContext = addJoueurViewModel;
	}
}