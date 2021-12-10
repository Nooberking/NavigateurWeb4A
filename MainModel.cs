using Microsoft.Web.WebView2.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace navigateurWeb4A
{
    public class VisitedUrl
    {
        public readonly string PINNED = "épinglé";
        public readonly string NOTPINNED = "épingler";


        public override string ToString()
        {
            return Url;
        }
        public string Url { get; set; }
        public int Position { get; set; }
        public string ButtonContent { get; set; }

        public bool NotPinned { get; set; } = true;

        public VisitedUrl (string Url)
        {
            this.Url = Url;
            this.ButtonContent = NOTPINNED; 

        }
        
    }

    public class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string HOMEPAGE = "https://www.google.fr"; // ici, la page d'accueil 

        public ObservableCollection<VisitedUrl> VisitedUrls { get; set; }

        public WebView2 WebView{ get; } // définition du contrôle WebView2

        public string CurrentUrl { get; set; }  //ici, l'url de la page

        public int PlaceNavigation { get; set; }
        public bool IsPrecedent { get; set; }   

        public bool PrecedentClicked { get; set; }

        public MainModel()
        {
            VisitedUrls = new ObservableCollection<VisitedUrl>();
            WebView = new WebView2();
            CurrentUrl = HOMEPAGE;

        }

    }
}
