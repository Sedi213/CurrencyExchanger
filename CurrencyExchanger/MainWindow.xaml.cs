using CurrencyExchanger.MVVM;
using CurrencyExchanger.UserController;
using System.Windows;


namespace CurrencyExchanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            initTabBar();
        }

        private void initTabBar()
        {
            MainTab.Content = new TabMain();
            MoreInfoTab.Content = new InfoTab();
            ConventorTab.Content = new CurrencyConvertor();
        }
    }
}
