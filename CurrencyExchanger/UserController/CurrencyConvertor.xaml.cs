using CurrencyExchanger.MVVM;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for CurrencyConventor.xaml
    /// </summary>
    public partial class CurrencyConvertor : UserControl
    {
        MainViewModel mainViewModel = new MainViewModel();
        public CurrencyConvertor()
        {
            InitializeComponent();
            DataContext = mainViewModel;
            mainViewModel.GetApi("https://api.coincap.io/v2/assets");
            RenderCandels();
        }

        private void RenderCandels()
        {

            var Candel = mainViewModel.GiveCandels();
            for (int i = 0; i < Candel.Length-1; i++)
            {
                Line temp = new Line();
                temp.X1 = i * 3+160;
                temp.Y1=580- Double.Parse(Candel[i].open)*5300;
                temp.X2= (i+1)*3+160;
                temp.Y2 =580- Double.Parse(Candel[i+1].open)*5300;
                temp.Stroke = Brushes.Blue;
                grid.Children.Add(temp);
            }

        }

        private void Conver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                double count = double.Parse(InputText.Text);
                double result = count * Double.Parse(mainViewModel.Currencies[ConverOn.SelectedIndex].Price) / Double.Parse(mainViewModel.Currencies[ConverTo.SelectedIndex].Price);
                OutputLabel.Content = String.Format("{0:0.0000}", result);
            }
            catch (Exception)
            {
                OutputLabel.Content = "Input invalid";
            }
        }

        private void RadioChecked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
           Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Themes/"+((RadioButton)sender).Content.ToString()+".xaml", UriKind.RelativeOrAbsolute) });
        }

        
    }
}
