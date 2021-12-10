using Microsoft.Web.WebView2.Core;
using System;

namespace navigateurWeb4A
{


    public class MainViewModel

    {
        public MainModel Model { get; set; } = new MainModel();

        public MainViewModel()
        {
            NavigateUrl(Model.HOMEPAGE);
            Model.WebView.SourceChanged += RefreshUrl;  // On ajoute la méthode qui permet d'actualiser la liste des pages visitées dans l'évènement qui s'enclenche lorsque la source d'une page change
        }
        public void RefreshUrl(object sender, CoreWebView2SourceChangedEventArgs args)
        {
            //Méthode permettant d'actualiser la liste des pages visitées ainsi que l'actuel Url. 
            if (Model.PrecedentClicked)
            {
                // cas où le bouton précédent a été cliqué, on remonte dans l'historique
                Model.PrecedentClicked = false;
                Model.PlaceNavigation--;
                Model.VisitedUrls.RemoveAt(Model.VisitedUrls.Count - 1);
                Model.OnChange(nameof(Model.VisitedUrls));
            }
            else 
            {
                Model.PlaceNavigation++;
                Model.VisitedUrls.Add(new VisitedUrl(Model.WebView.Source.AbsoluteUri));
            }
            Model.VisitedUrls[Model.VisitedUrls.Count - 1].Position = Model.PlaceNavigation; //permet de synchroniser la position enregistrée par l'url courant dans l'historique
            Model.CurrentUrl = Model.WebView.Source.AbsoluteUri;
            Model.OnChange(nameof(Model.CurrentUrl));
            Model.IsPrecedent = Model.PlaceNavigation > 1;
            Model.OnChange(nameof(Model.IsPrecedent));
        }
        public void ToPin (int position)
        {
            //Permet d'épingler une url selon sa position initiale et donc de modifier sa position
            VisitedUrl target = Model.VisitedUrls[position];
            if (target.NotPinned)
            {
                target.NotPinned = false;
                target.ButtonContent = target.PINNED;
                Model.VisitedUrls.RemoveAt(position); 
                Model.VisitedUrls.Insert(0, target);
            } 
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
