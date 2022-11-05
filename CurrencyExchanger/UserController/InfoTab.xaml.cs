using CurrencyExchanger.MVVM;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;


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
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = e.Uri.AbsoluteUri;
                process.Start();
            }
            e.Handled = true;
        }
    }
}
