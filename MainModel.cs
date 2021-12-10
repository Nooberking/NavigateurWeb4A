using Microsoft.Web.WebView2.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace navigateurWeb4A
{
    public class VisitedUrl
        // Pour les Urls dans l'historique de navigation
    {
        public readonly string PINNED = "épinglé";
        public readonly string NOTPINNED = "épingler";

        public string Url { get; set; } //nom de l'url
        public int Position { get; set; } //Position de l'url dans l'historique
        public string ButtonContent { get; set; } // Pour afficher dans le bouton si l'url a été épinglée
        public bool NotPinned { get; set; } = true; //Permet de désactiver le bouton si l'url a été épinglée
        public VisitedUrl (string Url)
        {
            this.Url = Url;
            this.ButtonContent = NOTPINNED; 
        }
        public override string ToString() // Pour que lorqu'on clique sur l'url dans l'historique, il s'affiche correctement dans la barre de recherche.
        {
            return Url;
        }

    }

    public class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string HOMEPAGE = "https://www.google.fr"; // ici, la page d'accueil 

        public ObservableCollection<VisitedUrl> VisitedUrls { get; set; }//Ici, l'historique des urls visités 


        public WebView2 WebView{ get; } // définition du contrôle WebView2

        public string CurrentUrl { get; set; }  //ici, l'url de la page

        public int PlaceNavigation { get; set; }//Servira à connaitre la position de l'url actuel dans l'historique
        public bool IsPrecedent { get; set; }   //Si il y a des urls dans l'historique pour passer au précédents

        public bool PrecedentClicked { get; set; }//si le bouton Précédent a été cliqué

        public MainModel()// constructeur par défaut : ajout de l'objet WebView2 + initialisation à la page d'accueil
        {
            VisitedUrls = new ObservableCollection<VisitedUrl>();
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
