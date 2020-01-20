using Pokemon_api.Assets.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokemon_api
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
//slimme sweetspons 
    public sealed partial class HomePage : Page, INotifyPropertyChanged
    {

        public Show show { get; set; } = new Show();

        public event PropertyChangedEventHandler PropertyChanged;

        private List<Result> _result = new List<Result>();

        public List<Result> Results
        {
            get { return _result; }
            set { _result = value; NotifyPropertyChanged(); }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Result _currentpokemon = new Result();
        //private object Show;

        public HomePage()
        {
            this.InitializeComponent();
            GetResults();
        }


        private async void GetResults()
        {
            Results = await PokeAPIWrapper.GetResults();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(PokeStats), show);
        }
    }


    public class Show
    {
        private string _currentpokemon;

        public string CurrentPokemon
        {
            get { return _currentpokemon; }
            set { _currentpokemon = value; }
        }
    }
}
