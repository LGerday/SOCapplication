using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using soc.Core;
using soc.Services;
using soc.View;

namespace soc.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand NavigationToServerCommand { get; set; }
        public RelayCommand NavigationToAddServerCommand { get; set; }
        public RelayCommand NavigationToSettingsCommand { get; set; }
        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigationToServerCommand = new RelayCommand(o => true, o => { Navigation.NavigateTo<ServerViewModel>(); });
            NavigationToAddServerCommand = new RelayCommand(o => true, o => { Navigation.NavigateTo<AddServerViewModel>(); });
            NavigationToSettingsCommand =
                new RelayCommand(o => true, o => { Navigation.NavigateTo<SettingsViewModel>(); });

            Navigation.NavigateTo<ServerViewModel>();
        }


    }
}
