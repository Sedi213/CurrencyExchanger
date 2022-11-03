﻿
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
        public void RenderTop()
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://api.coincap.io/v2/assets?limit=7");
            }
            json = json.Remove(json.Length - 27, 27).Remove(0, 8);//Prepared for deserialize
            Currencies = JsonSerializer.Deserialize<ObservableCollection<Currency>>(json);
        }
        public void Search1(string search)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://api.coincap.io/v2/assets?limit=7&search="+search);
            }
            json = json.Remove(json.Length - 27, 27).Remove(0, 8);//Prepared for deserialize
            Currencies = JsonSerializer.Deserialize<ObservableCollection<Currency>>(json);
        }

        public void Search(string search)
        {
            Currencies.Clear();
            Task.Factory.StartNew(() =>
            {
                string json;
                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString("https://api.coincap.io/v2/assets?limit=7&search=" + search);
                }
                json = json.Remove(json.Length - 27, 27).Remove(0, 8);//Prepared for deserialize
                return JsonSerializer.Deserialize<ObservableCollection<Currency>>(json);
            }).ContinueWith(task =>
            {
                //add the results to the source collection
                foreach (var result in task.Result)
                    Currencies.Add(result);

            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
