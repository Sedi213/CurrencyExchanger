using CurrencyExchanger.MVVM;
using System;
using System.Collections.Generic;
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

namespace CurrencyExchanger.UserController
{
    /// <summary>
    /// Interaction logic for InfoTab.xaml
    /// </summary>
    public partial class InfoTab : UserControl
    {
        private MainViewModel Model;
        public InfoTab()
        {
            InitializeComponent();
            Model = new MainViewModel();
            DataContext = Model;
           
        }

    }
}
