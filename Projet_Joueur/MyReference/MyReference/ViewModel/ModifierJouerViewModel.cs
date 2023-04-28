namespace MyReference.ViewModel;


[QueryProperty(nameof(JoueurUpd), "Joueur")]
public partial class ModifierJouerViewModel : ObservableObject
{
    [ObservableProperty]
     Joueur joueurUpd;


    public ModifierJouerViewModel()
    {

    }

    [RelayCommand]
    async void Modifier()
    {

        foreach (Joueur joueur in Globals.MyJoueurList)
        {
            if(joueur.ID == joueurUpd.ID) 
            {
                joueurUpd.Nom = joueur.Nom;
                joueurUpd.Prenom = joueur.Prenom;
                joueurUpd.Age = joueur.Age;
                joueurUpd.Poste = joueur.Poste;
                joueurUpd.Image = joueur.Image;
            }
        }

        await Shell.Current.DisplayAlert("Modification éffectué!", "Vous pouvez retournez en arrière.", "OK");
    }
}