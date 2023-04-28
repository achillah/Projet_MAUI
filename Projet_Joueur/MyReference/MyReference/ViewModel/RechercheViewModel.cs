

namespace MyReference.ViewModel;

[QueryProperty(nameof(MonTxt), "Databc")]
public partial class RechercheViewModel : ObservableObject
{
    DeviceOrientationServices MyDeviceOrientationService;

    [ObservableProperty]
    string monTxt;

    [ObservableProperty]
    Joueur joueurRechercher;


    public RechercheViewModel()
	{
        this.MyDeviceOrientationService = new DeviceOrientationServices();
        MyDeviceOrientationService.ConfigureScanner();

        MyDeviceOrientationService.MyQueueBuffer.Changed += SerialBuffer_Changed;
    }

    private void SerialBuffer_Changed(object sender, EventArgs e)
    {
        DeviceOrientationServices.QueueBuffer myQueue = (DeviceOrientationServices.QueueBuffer)sender;

        MonTxt = myQueue.Dequeue().ToString(); //ActiveTarget = nom du label a changer!!!!

        foreach (Joueur joueur in Globals.MyJoueurList)
        {
            if (MonTxt == joueur.ID)
            {
                JoueurRechercher = joueur;
            }
        }

    }

    [RelayCommand]
    public async Task GoToAddJoueurPage()
    {
        await Shell.Current.GoToAsync(nameof(AjouterJoueur), true);
    }

    
}