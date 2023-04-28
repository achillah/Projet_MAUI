namespace MyReference.ViewModel;

public partial class AjouterJoueurViewModel : ObservableObject
{
    /*[ObservableProperty]
   public string iD;
   [ObservableProperty]
   public string nom;
   [ObservableProperty]
   public string prenom;
   [ObservableProperty]
   public int age;
   [ObservableProperty]
   public string poste;
   [ObservableProperty]
   public string image;*/


    [ObservableProperty]
    Joueur joueurNvx;
    public AjouterJoueurViewModel()
    {
        this.joueurNvx = new Joueur();
    }

    [RelayCommand]
    async void Ajouter()
    {
        Globals.MyJoueurList.Add(joueurNvx);
        //Text = string.Empty;
        await Shell.Current.DisplayAlert("Joueur ajouté", "Vous pouvez revenir en arrière.", "OK");
    }
}