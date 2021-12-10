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
            Model.WebView.SourceChanged += RefreshUrl; // On ajoute la méthode qui permet d'actualiser la liste des pages visitées dans l'évènement qui s'enclenche lorsque la source d'une page change
        }

       

        public void RefreshUrl(object sender, CoreWebView2SourceChangedEventArgs args)
            //Méthode permettant d'actualiser la liste des pages visitées ainsi que l'actuel Url.
        {
           if(Model.CurrentUrl != Model.WebView.Source.AbsoluteUri)
            {   
                Model.CurrentUrl = Model.WebView.Source.AbsoluteUri;
                Model.VisitedUrls.Add(Model.CurrentUrl);
                Model.OnChange(nameof(Model.CurrentUrl)); 
            }
        }


        public void NavigateUrl(string url) // permet de charger une page dans le contrôle WebView2 à partir d'une url
        {
            if (Model.WebView != null)
            {
                Model.CurrentUrl = url;
                Model.WebView.Source = new Uri(url);
            }
        }
    }
}
