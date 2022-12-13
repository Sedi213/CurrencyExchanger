using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coin.MVVM.Model;

namespace Coin.API
{
    static class CurrencyAPI
    {
        private static WebClient wc = new WebClient();
        public static ObservableCollection<Currency> GetApi(string get)
        {
            string json;

            json = wc.DownloadString(get);
            json = json.Remove(json.Length - 27, 27).Remove(0, 8);//Prepared for deserialize
            return JsonSerializer.Deserialize<ObservableCollection<Currency>>(json);

        }
    }
}
