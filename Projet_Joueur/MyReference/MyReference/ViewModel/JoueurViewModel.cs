using System.Windows.Input;

namespace MyReference.ViewModel;

[QueryProperty("Joueur", "Joueur")]
public partial class JoueurViewModel : BaseViewModel
{
    [ObservableProperty]
    Joueur joueur;



    [RelayCommand]
    public async Task AllerModifierJoueurPage(Joueur joueur)
    {
        //await Shell.Current.DisplayAlert("Successfully Created!", "You can go back.", "OK");
        await Shell.Current.GoToAsync(nameof(ModifierJoueur), true, new Dictionary<string, object>
        {

            {"Joueur", joueur }

        });
    }

    [RelayCommand]
    async void Supprimer(Joueur joueur)
    {
        if (Globals.MyJoueurList.Contains(joueur))
        {
            Globals.MyJoueurList.Remove(joueur);
        }
        await Shell.Current.DisplayAlert("Suppression éffectué", "Vous pouvez revenir en arrière.", "OK");
    }
}
