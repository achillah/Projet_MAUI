using System.IO;
using System.Text.Json;

namespace MyReference.ViewModel;


[QueryProperty(nameof(JoueurUpd), "Joueur")]
public partial class ModifierJouerViewModel : BaseViewModel
{
    [ObservableProperty]
     Joueur joueurUpd;


    public ModifierJouerViewModel()
    {

    }

    /*[RelayCommand]
    async void ModifierJoueur()
    {

        
            if(joueur.ID == JoueurUpd.ID) 
            {
                JoueurUpd.Nom = joueur.Nom;
                JoueurUpd.Prenom = joueur.Prenom;
                JoueurUpd.Age = joueur.Age;
                JoueurUpd.Poste = joueur.Poste;
                JoueurUpd.Image = joueur.Image;
            }
        }

        await Shell.Current.DisplayAlert("Modification éffectué!", "Vous pouvez retournez en arrière.", "OK");
    }*/

    
    /*[RelayCommand]
    async void ModifierJoueur()
{
    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerDonnees", "csvjson.json");

    // Récupère le contenu JSON existant du fichier
    string jsonContent = File.ReadAllText(filePath);

    // Désérialise le contenu JSON en une liste
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var joueurs = JsonSerializer.Deserialize<List<Joueur>>(jsonContent, options);

        foreach (Joueur joueur in Globals.MyJoueurList)
        {
            // Recherche le joueur à modifier
            Joueur joueurAModifier = joueurs.FirstOrDefault(joueur => joueur.ID == JoueurUpd.ID);
            if(joueur.ID == JoueurUpd.ID) 
            {
                if ((string.IsNullOrEmpty(joueur.ID)) || (string.IsNullOrWhiteSpace(joueur.ID))
                    || (string.IsNullOrEmpty(joueur.Nom)) || (string.IsNullOrWhiteSpace(joueur.Nom))
                    || (string.IsNullOrEmpty(joueur.Prenom)) || (string.IsNullOrWhiteSpace(joueur.Prenom))
                    || (string.IsNullOrEmpty(joueur.Age.ToString())) || (string.IsNullOrWhiteSpace(joueur.Age.ToString()))
                    || (string.IsNullOrEmpty(joueur.Poste)) || (string.IsNullOrWhiteSpace(joueur.Poste))
                    || (string.IsNullOrEmpty(joueur.Image)) || (string.IsNullOrWhiteSpace(joueur.Image)))
                {

                    await Shell.Current.DisplayAlert("Modification erreur!", "Veuillez entrer des vraies valeurs.", "OK");
                }
                else { 
                    // Met à jour les propriétés du joueur avec les nouvelles valeurs
                    joueur.Nom = JoueurUpd.Nom;
                    joueur.Prenom = JoueurUpd.Prenom;
                    joueur.Age = JoueurUpd.Age;
                    joueur.Poste = JoueurUpd.Poste;
                    joueur.Image = JoueurUpd.Image;

                   
                }

            }
 
        }

        // Sérialise la liste mise à jour en JSON
        string updatedJsonContent = JsonSerializer.Serialize(joueurs, options);

        // Écrit le contenu JSON sérialisé dans le fichier
        File.WriteAllText(filePath, updatedJsonContent);

        await Shell.Current.DisplayAlert("Modification effectuée!", "Vous pouvez retourner en arrière.", "OK");

    }*/

[RelayCommand]
async void ModifierJoueur()
{
    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerDonnees", "csvjson.json");

    // Récupère le contenu JSON existant du fichier
    string jsonContent = File.ReadAllText(filePath);

    // Désérialise le contenu JSON en une liste
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var joueurs = JsonSerializer.Deserialize<List<Joueur>>(jsonContent, options);

    // Recherche le joueur à modifier
    Joueur joueurAModifier = joueurs.FirstOrDefault(joueur => joueur.ID == JoueurUpd.ID);

        if (joueurAModifier != null)
        {
            // Vérifie que les nouvelles valeurs ne sont pas vides ou ne contiennent que des espaces
            if (!string.IsNullOrEmpty(JoueurUpd.Nom.Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Prenom.Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Age.ToString().Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Poste.Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Image.Trim()))
            {
                // Met à jour les propriétés du joueur avec les nouvelles valeurs
                joueurAModifier.Nom = JoueurUpd.Nom;
                joueurAModifier.Prenom = JoueurUpd.Prenom;
                joueurAModifier.Age = JoueurUpd.Age;
                joueurAModifier.Poste = JoueurUpd.Poste;
                joueurAModifier.Image = JoueurUpd.Image;

                // Sérialise la liste mise à jour en JSON
                string updatedJsonContent = JsonSerializer.Serialize(joueurs, options);

                // Écrit le contenu JSON sérialisé dans le fichier
                File.WriteAllText(filePath, updatedJsonContent);

                await Shell.Current.DisplayAlert("Modification effectuée", "Vous pouvez revenir en arrière.", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Erreur de modification", "Veuillez entrer de vraies valeurs", "OK");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Erreur de modification", "Le joueur n'a pas été trouvé.", "OK");
        }
    }

}


