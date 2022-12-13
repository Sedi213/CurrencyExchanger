using Coin.API;
using Coin.MVVM.Model;
using Coin.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.MVVM.ViewModel
{
    internal class ConvertorViewModel : BaseViewModel
    {
        public ObservableCollection<Currency> Currencies { get; set; }
        public string result = "1";   
        public string Result { get { return result; } set
            {
                result= value;
                OnPropertyChanged(nameof(Result));
            } }

        public ConvertorViewModel()
        {
            Currencies = CurrencyAPI.GetApi("https://api.coincap.io/v2/assets");
        }
        private RelayCommand convertCmd;
        public RelayCommand ConvertCmd 
        {
                get
            {
                    return convertCmd ??
                      (convertCmd = new RelayCommand(obj =>
                      {
                      
                         Result=(Double.Parse( Currencies[Int32.Parse("1")].Price) / Double.Parse(Currencies[Int32.Parse("2")].Price)) .ToString();

                      }));
                }
            }
        }
    
}
