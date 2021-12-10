using Microsoft.Web.WebView2.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace navigateurWeb4A
{
    public class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string HOMEPAGE = "https://www.google.fr"; // ici, la page d'accueil 

        public ObservableCollection<string> VisitedUrls { get; set; }

        public WebView2 WebView{ get; } // définition du contrôle WebView2

        public string CurrentUrl { get; set; }  //ici, l'url de la page

        public int PlaceNavigation { get; set; }
        public bool IsPrecedent { get; set; }   

        public bool PrecedentClicked { get; set; }

        public MainModel()
        {
            VisitedUrls = new ObservableCollection<string>();
            WebView = new WebView2();
            CurrentUrl = HOMEPAGE;

        }

    }
}
