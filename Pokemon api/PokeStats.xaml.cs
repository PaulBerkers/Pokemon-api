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
    public sealed partial class PokeStats : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

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

        private List<Result> _result = new List<Result>();

        public PokeStats()
        {
            this.InitializeComponent();
        }

        public Result CurrentPokemon
        {
            get { return _currentpokemon; }
            set { _currentpokemon = value; NotifyPropertyChanged(); }
        }

        private async void GetResults()
        {
            Results = await PokeAPIWrapper.GetResults();
        }
    }
}
