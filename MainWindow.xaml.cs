using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace navigateurWeb4A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public class MainViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged; 
            
        private readonly string HOMEPAGE = "https://www.google.fr"; // ici, la page d'accueil 

        private ObservableCollection<string> _visitedUrls = new ObservableCollection<string>(); // ici la liste des pages visitées
        public ObservableCollection<string> VisitedUrls
        {
            get { return _visitedUrls; }
        }

        WebView2 _webView = new WebView2();// définition du contrôle WebView2
        public WebView2 WebView
        {
            get { return _webView; }
        }


        private string _currentUrl ; //ici, l'url de la page  
        public string CurrentUrl
        {
            get { return _currentUrl; }
            set { _currentUrl = value; }
        }

        public MainViewModel()
        {  
            _webView.NavigationStarting += AddUrl; // On ajoute la méthode qui permet d'actualiser la liste des pages visitées dans l'évènement qui s'enclenche lorsqu'une page est chargée 
            _webView.Source =new Uri(HOMEPAGE); // on Indique au contrôle WebView2 que la page de départ est la page d'accueil
     
        }

        public void AddUrl (object sender ,CoreWebView2NavigationStartingEventArgs args)
        {
            if (CurrentUrl != args.Uri)
            {
                CurrentUrl = args.Uri;
                _visitedUrls.Add(CurrentUrl);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentUrl))); // permet d'indiquer que l'url à afficher a été modifié
            }
        }

         
        public void WebView_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        {
            throw new NotImplementedException();
        }


        public void NavigateUrl(string url) // permet de charger une page dans le contrôle WebView2 à partir d'une url
        {
            if(_webView != null && _webView.CoreWebView2 !!= null)
            {
                _webView.CoreWebView2.Navigate(url);
            }
        }
    }

    public partial class MainWindow : Window
    {
        MainViewModel _vm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm; 
            dp.Children.Add(_vm.WebView);
        }
        
       

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
           _vm.NavigateUrl(_vm.CurrentUrl);
        }
    }
    
}
