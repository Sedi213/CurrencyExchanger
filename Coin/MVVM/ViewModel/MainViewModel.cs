using Coin.MVVM.Model;
using Coin.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coin.MVVM.ViewModel
{
    internal class MainViewModel :BaseViewModel
    {
        public RelayCommand TopVMComand { get; set; }
        public RelayCommand SearchVMComand { get; set; }
        public RelayCommand ConvertorVMComand { get; set; }

        public TopViewModel TopVM { get; set; }
        public SearchViewModel SearchVM { get; set; }
        public ConvertorViewModel ConventorVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public MainViewModel()
        {
            TopVM= new TopViewModel();
            SearchVM= new SearchViewModel();
            ConventorVM= new ConvertorViewModel();
            
            CurrentView = TopVM;

            TopVMComand = new RelayCommand(obj =>
            {
                CurrentView = TopVM;
            });
           SearchVMComand = new RelayCommand(obj =>
            {
                CurrentView = SearchVM;
            });
            ConvertorVMComand = new RelayCommand(obj =>
            {
                CurrentView = ConventorVM;
            });

        }



       

    }
}
