namespace MyReference.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    
    public MainViewModel()
    {
        /////on cree les dataset, datatable en appelant le constructeur
        UserDonneesTables MyUserTables = new();

        //Globals.UserSet.Tables["Users"].Columns["UserName"] = "blabla";

    }

    [RelayCommand]
    async Task ChargerJson_AllerHomePage()
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

        await Shell.Current.GoToAsync(nameof(HomePage), true);
    }
}