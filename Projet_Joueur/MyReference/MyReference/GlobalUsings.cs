global using MyReference.View;
global using MyReference.ViewModel;
global using MyReference.Model;
global using MyReference.Services;

global using CommunityToolkit.Mvvm.Input;
global using CommunityToolkit.Mvvm.ComponentModel;


global using System.Diagnostics;
global using System.Collections.ObjectModel;
global using System.ComponentModel;
global using System.Runtime.CompilerServices;
global using System.Text.Json;
global using System.Management;
global using System.Collections;
global using MyQualityApp.Services;
global using System.Data;



public class Globals
{

    public static List<Joueur> MyJoueurList = new();

    public static DataSet UserSet = new();

}