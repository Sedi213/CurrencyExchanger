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
        private int selectedIndex1;

        public int SelectedIndex1
        {
            get { return selectedIndex1; }
            set { selectedIndex1 = value;
                OnPropertyChanged(nameof(SelectedIndex1));
                ConvertCmd.Execute(selectedIndex1);
            }
        }

        private int selectedIndex2;

        public int SelectedIndex2
        {
            get { return selectedIndex2; }
            set { selectedIndex2 = value;
            OnPropertyChanged(nameof(SelectedIndex2));
                ConvertCmd.Execute(selectedIndex2);
            }
        }



        public string Result { 
            get { return result; }
            set
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
                         
                         Result=(Double.Parse( Currencies[SelectedIndex1].Price) / Double.Parse(Currencies[SelectedIndex2].Price)) .ToString();

                      }));
                }
            }
        }
    
}
