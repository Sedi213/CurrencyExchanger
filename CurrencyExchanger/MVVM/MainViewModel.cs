
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
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://api.coincap.io/v2/assets?limit=7");
            }
            json = json.Remove(json.Length - 27, 27).Remove(0, 8);//Prepared for deserialize
            Currencies = JsonSerializer.Deserialize<ObservableCollection<Currency>>(json);
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Currencies.Clear();
                      string search = obj as string;
                      string json;
                      using (WebClient wc = new WebClient())
                      {
                           json = wc.DownloadString("https://api.coincap.io/v2/assets?limit=7&search="+search);
                      }
                      json = json.Remove(json.Length - 27, 27).Remove(0, 8);//Prepared for deserialize
                      var temp = JsonSerializer.Deserialize<ObservableCollection<Currency>>(json);
                      foreach (var item in temp)
                      Currencies.Add(item);
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
