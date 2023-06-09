﻿namespace MyReference.ViewModel;

[QueryProperty("Joueur", "Joueur")]
public partial class JoueurViewModel : BaseViewModel
{
    [ObservableProperty]
    Joueur joueur;



    [RelayCommand]
    public async Task AllerModifierJoueurPage(Joueur joueur)
    {
        //await Shell.Current.DisplayAlert("Successfully Created!", "You can go back.", "OK");
        await Shell.Current.GoToAsync(nameof(ModifierJoueurPage), true, new Dictionary<string, object>
        {

            {"Joueur", joueur }

        });
    }

    /*[RelayCommand]
    async void SupprimerJoueur(Joueur joueur)
    {
        if (Globals.MyJoueurList.Contains(joueur))
        {
            Globals.MyJoueurList.Remove(joueur);
        }
        await Shell.Current.DisplayAlert("Suppression éffectué", "Vous pouvez revenir en arrière.", "OK");
    }*/

[RelayCommand]
async void SupprimerJoueur(Joueur joueur)
{
    if (Globals.MyJoueurList.Contains(joueur))
    {
        Globals.MyJoueurList.Remove(joueur);

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerDonnees", "csvjson.json");

        // Récupère le contenu JSON existant du fichier
        string jsonContent = File.ReadAllText(filePath);

        // Désérialise le contenu JSON en une liste
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var joueurs = JsonSerializer.Deserialize<List<Joueur>>(jsonContent, options);

        // Supprime le joueur de la liste désérialisée
        joueurs.RemoveAll(j => j.ID == joueur.ID);

        // Sérialise la liste mise à jour en JSON
        string updatedJsonContent = JsonSerializer.Serialize(joueurs, options);

        // Écrit le contenu JSON sérialisé dans le fichier
        File.WriteAllText(filePath, updatedJsonContent);
    }

    await Shell.Current.DisplayAlert("Suppression effectuée", "Vous pouvez revenir en arrière.", "OK");
}

}
