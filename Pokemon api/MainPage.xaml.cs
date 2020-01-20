using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Pokemon_api.Assets.Classes;
using NavigationViewExample.Classes;
using System.Collections.ObjectModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pokemon_api
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<MenuItem> _menuItems;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Result> _result = new List<Result>(); 

        public List<Result> Results
        {
            get { return _result; }
            set { _result = value; NotifyPropertyChanged(); }
        }

        public Result _currentpokemon = new Result();
        //private object Show;

        public MainPage()
        {
            this.InitializeComponent();

            _menuItems = new ObservableCollection<MenuItem>()
            {
                new MenuItem(
                    typeof(HomePage),
                    "Home",Symbol.Home),
                new MenuItem(
                    typeof(PokeStats),
                    "Stats",Symbol.SolidStar),
            };
            fRootFrame.Navigate(_menuItems[0].Page);

        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            MenuItem mi = (MenuItem)args.InvokedItemContainer.DataContext;
            fRootFrame.Navigate(mi.Page);
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (fRootFrame.CanGoBack)
            {
                fRootFrame.GoBack();
            }

        }
    }
}
