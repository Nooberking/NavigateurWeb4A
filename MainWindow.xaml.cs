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
    }
    
}
