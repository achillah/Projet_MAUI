namespace MyReference.View;

public partial class ModifierJoueur : ContentPage
{
	public ModifierJoueur(ModifierJouerViewModel modifierJouerViewModel)
	{
		InitializeComponent();
		BindingContext = modifierJouerViewModel;
	}
}