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

        await Shell.Current.DisplayAlert("Modification �ffectu�!", "Vous pouvez retournez en arri�re.", "OK");
    }*/

    
    /*[RelayCommand]
    async void ModifierJoueur()
{
    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerDonnees", "csvjson.json");

    // R�cup�re le contenu JSON existant du fichier
    string jsonContent = File.ReadAllText(filePath);

    // D�s�rialise le contenu JSON en une liste
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var joueurs = JsonSerializer.Deserialize<List<Joueur>>(jsonContent, options);

        foreach (Joueur joueur in Globals.MyJoueurList)
        {
            // Recherche le joueur � modifier
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
                    // Met � jour les propri�t�s du joueur avec les nouvelles valeurs
                    joueur.Nom = JoueurUpd.Nom;
                    joueur.Prenom = JoueurUpd.Prenom;
                    joueur.Age = JoueurUpd.Age;
                    joueur.Poste = JoueurUpd.Poste;
                    joueur.Image = JoueurUpd.Image;

                   
                }

            }
 
        }

        // S�rialise la liste mise � jour en JSON
        string updatedJsonContent = JsonSerializer.Serialize(joueurs, options);

        // �crit le contenu JSON s�rialis� dans le fichier
        File.WriteAllText(filePath, updatedJsonContent);

        await Shell.Current.DisplayAlert("Modification effectu�e!", "Vous pouvez retourner en arri�re.", "OK");

    }*/

[RelayCommand]
async void ModifierJoueur()
{
    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerDonnees", "csvjson.json");

    // R�cup�re le contenu JSON existant du fichier
    string jsonContent = File.ReadAllText(filePath);

    // D�s�rialise le contenu JSON en une liste
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var joueurs = JsonSerializer.Deserialize<List<Joueur>>(jsonContent, options);

    // Recherche le joueur � modifier
    Joueur joueurAModifier = joueurs.FirstOrDefault(joueur => joueur.ID == JoueurUpd.ID);

        if (joueurAModifier != null)
        {
            // V�rifie que les nouvelles valeurs ne sont pas vides ou ne contiennent que des espaces
            if (!string.IsNullOrEmpty(JoueurUpd.Nom.Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Prenom.Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Age.ToString().Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Poste.Trim()) &&
                !string.IsNullOrEmpty(JoueurUpd.Image.Trim()))
            {
                // Met � jour les propri�t�s du joueur avec les nouvelles valeurs
                joueurAModifier.Nom = JoueurUpd.Nom;
                joueurAModifier.Prenom = JoueurUpd.Prenom;
                joueurAModifier.Age = JoueurUpd.Age;
                joueurAModifier.Poste = JoueurUpd.Poste;
                joueurAModifier.Image = JoueurUpd.Image;

                // S�rialise la liste mise � jour en JSON
                string updatedJsonContent = JsonSerializer.Serialize(joueurs, options);

                // �crit le contenu JSON s�rialis� dans le fichier
                File.WriteAllText(filePath, updatedJsonContent);

                await Shell.Current.DisplayAlert("Modification effectu�e", "Vous pouvez revenir en arri�re.", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Erreur de modification", "Veuillez entrer de vraies valeurs", "OK");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Erreur de modification", "Le joueur n'a pas �t� trouv�.", "OK");
        }
    }

}


