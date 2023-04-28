using MyQualityApp.Services;
using System.Collections;

namespace MyReference.ViewModel;

public partial class MainViewModel : ObservableObject
{
    //DeviceOrientationServices MyDeviceOrientationService;
    public ObservableCollection<Joueur> MyJoueurs { get; set; } = new();

    public MainViewModel()
    {
        //Items = new ObservableCollection<string>();
        //Queue Serialbuffer = new();
    }

    public Joueur joueur;


    [ObservableProperty]
    string monTexte = "Go To Recherche Page";

    /*[ObservableProperty]
    string text;

    [ObservableProperty]
    ObservableCollection<string> items;*/

  


   /* [RelayCommand]
    public async Task GoToDetailPage(string data)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            {"Databc", data }
        });
    }*/

    [RelayCommand]
    public async Task GoToRecherchePage(string data)
    {
        await Shell.Current.GoToAsync(nameof(RechercheJoueur), true, new Dictionary<string, object>
        {
            {"Databc", data }
        });
    }

    [RelayCommand]
    async Task GoToJoueurs(Joueur joueur)
    {
        if (joueur is null)
            return;

        await Shell.Current.GoToAsync(nameof(JoueurPage), true, new Dictionary<string, object>
        {

            {"Joueur", joueur }

        });
    }

    [RelayCommand]
    public async Task GoToAddJoueurPage()
    {
        await Shell.Current.GoToAsync(nameof(AjouterJoueur), true);
    }

    

    public void RefreshList()
    {
        MyJoueurs.Clear();

        foreach (Joueur joueur in Globals.MyJoueurList)
        {
            MyJoueurs.Add(joueur);
        }
    }

    [RelayCommand]
    async Task JoueursFromJSON()
    {
        //if (IsBusy) return;

        JoueurService MyService = new();

        try
        {
            //   IsBusy = true;
            Globals.MyJoueurList = await MyService.GetJoueurs();
        }
        catch (Exception ex)
        {
            //Debug.WriteLine($"Unable to get Students: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        //finally { IsBusy = false; }

        RefreshList();
    }
}