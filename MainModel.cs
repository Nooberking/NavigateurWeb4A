using Microsoft.Web.WebView2.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace navigateurWeb4A
{
    public class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string HOMEPAGE = "https://www.google.fr"; // ici, la page d'accueil 

        public ObservableCollection<string> VisitedUrls { get; set; } //Ici, l'historique des urls visités 

        public WebView2 WebView{ get; } // définition du contrôle WebView2

        public string CurrentUrl { get; set; }  //ici, l'url de la page

        public int PlaceNavigation { get; set; } //Servira à connaitre la position de l'url actuel dans l'historique
        public bool IsPrecedent { get; set; }   //Si l'url saisie vient de l'historique 

        public bool PrecedentClicked { get; set; }//si le bouton Précédent a été cliqué

        public MainModel()// constructeur par défaut : ajout de l'objet WebView2 + initialisation à la page d'accueil
        {
            VisitedUrls = new ObservableCollection<string>();
            WebView = new WebView2();
            CurrentUrl = HOMEPAGE;

        }
        public void OnChange(string property)
        {
            //Méthode permettant d'actualiser l'affichage d'une propriété binded dans la fenêtre
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
