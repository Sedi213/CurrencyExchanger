using Coin.API;
using Coin.MVVM.Model;
using Coin.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Coin.MVVM.ViewModel
{
    internal class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<Currency> Currencies { get; set; } 

        public SearchViewModel()
        {
            Currencies = CurrencyAPI.GetApi("https://api.coincap.io/v2/assets");

        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand(obj =>
                  {
                      Currencies.Clear();
                      string search = obj as string;
                      Currencies = CurrencyAPI.GetApi("https://api.coincap.io/v2/assets?search=" + search);
                      OnPropertyChanged(nameof(Currencies));
                  }));
            }
        }
    
        
    }

}
