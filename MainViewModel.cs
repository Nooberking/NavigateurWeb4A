using Microsoft.Web.WebView2.Core;
using System;
using System.ComponentModel;

namespace navigateurWeb4A
{

    public class MainViewModel: INotifyPropertyChanged

    {
       
       

        public MainModel Model { get; set; } = new MainModel();
        
       


        public MainViewModel()
        {
            
            NavigateUrl(Model.HOMEPAGE);
            Model.WebView.SourceChanged += RefreshUrl; // On ajoute la méthode qui permet d'actualiser la liste des pages visitées dans l'évènement qui s'enclenche lorsqu'une page est chargée 
            

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RefreshUrl(object sender, CoreWebView2SourceChangedEventArgs args)
        {
            
            
            if (Model.PrecedentClicked)
            {
                Model.PrecedentClicked = false;
                Model.PlaceNavigation--;
                Model.VisitedUrls.RemoveAt(Model.VisitedUrls.Count - 1);
                PropertyChanged(Model, new PropertyChangedEventArgs(nameof(Model.VisitedUrls)));

            }
            else 
            {
                Model.PlaceNavigation++;
                
                Model.VisitedUrls.Add(Model.WebView.Source.AbsoluteUri);
            }
            Model.CurrentUrl = Model.WebView.Source.AbsoluteUri;
            PropertyChanged(Model, new PropertyChangedEventArgs(nameof(Model.CurrentUrl)));
            Model.IsPrecedent = Model.PlaceNavigation > 1;
            PropertyChanged(Model, new PropertyChangedEventArgs(nameof(Model.IsPrecedent)));
            
           

        }


        public void NavigateUrl(string url, bool precedent = false) // permet de charger une page dans le contrôle WebView2 à partir d'une url
        {
            if (Model.WebView != null)
            {
                Model.CurrentUrl = url;
                Model.PrecedentClicked = precedent;
                Model.WebView.Source = new Uri(url);
                
            }
        }
    }
}
