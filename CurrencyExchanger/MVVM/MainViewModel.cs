
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;


namespace CurrencyExchanger.MVVM
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Currency> Currencies { get; set; } 

        private Currency selectedCurrency;
        public Currency SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnPropertyChanged("SelectedCurrency");
            }
        }

        

        public MainViewModel()
        {
            Currencies = new ObservableCollection<Currency>();
            GetApi("https://api.coincap.io/v2/assets?limit=7"); 
        }

        public void GetApi(string get)
        {
            string json;
            using (WebClient wc = new WebClient())
                json = wc.DownloadString(get); 
            json = json.Remove(json.Length - 27, 27).Remove(0, 8);//Prepared for deserialize
            var temp = JsonSerializer.Deserialize<ObservableCollection<Currency>>(json);
            foreach (var item in temp)
                Currencies.Add(item);
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
                      GetApi("https://api.coincap.io/v2/assets?limit=7&search="+search);
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
