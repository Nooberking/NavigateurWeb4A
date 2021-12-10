using System.Windows;

namespace navigateurWeb4A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 




    public partial class MainWindow : Window
    {
        MainViewModel _vm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm; 
            dp.Children.Add(_vm.Model.WebView);
        }
        
       

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
           _vm.NavigateUrl(_vm.Model.CurrentUrl);
           
          
        }

        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            _vm.NavigateUrl(_vm.Model.VisitedUrls[_vm.Model.VisitedUrls.Count - 2],true);
        }
    }
    
}
