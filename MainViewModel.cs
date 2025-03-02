﻿using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           if(Model.CurrentUrl != Model.WebView.Source.AbsoluteUri)
            {   
                Model.CurrentUrl = Model.WebView.Source.AbsoluteUri;
                Model.VisitedUrls.Add(Model.CurrentUrl);
                PropertyChanged(Model, new PropertyChangedEventArgs(nameof(Model.CurrentUrl))); 
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
