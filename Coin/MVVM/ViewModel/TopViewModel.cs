using Coin.API;
using Coin.MVVM.Model;
using Coin.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coin.MVVM.ViewModel
{
    internal class TopViewModel :BaseViewModel
    {
        public TopViewModel()
        {
            Currencies= CurrencyAPI.GetApi("https://api.coincap.io/v2/assets?limit=7");
        }
        public ObservableCollection<Currency> Currencies { get; set; } = new ObservableCollection<Currency>();
        
    }
}
