using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchanger.Api
{
    internal class Currency : INotifyPropertyChanged
    {
        private string id;
        [JsonPropertyName("id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        private string name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string price;

        [JsonPropertyName("priceUsd")]
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string explorer { get; set; }
        public string volumeUsd24Hr { get; set; }
        public string vwap24Hr { get; set; }
        public string changePercent24Hr { get; set; }
        public string supply { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
