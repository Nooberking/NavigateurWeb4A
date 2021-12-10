using Microsoft.Web.WebView2.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace navigateurWeb4A
{
    public class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChange(string property)
        {
            //Méthode permettant d'actualiser l'affichage d'une propriété binded dans la fenêtre
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public string HOMEPAGE = "https://www.google.fr"; // ici, la page d'accueil 

        public ObservableCollection<string> VisitedUrls { get; } //Ici, l'historique des urls visités 

        public WebView2 WebView{ get; } // définition du contrôle WebView2

        public string CurrentUrl { get; set; }  //ici, l'url de la page

        public MainModel()// constructeur par défaut : ajout de l'objet WebView2 + initialisation à la page d'accueil
        {
            VisitedUrls = new ObservableCollection<string>();
            WebView = new WebView2();
            CurrentUrl = HOMEPAGE;

        }

    }
}
