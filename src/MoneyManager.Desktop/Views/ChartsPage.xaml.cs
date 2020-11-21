using System;

using MoneyManager.Desktop.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MoneyManager.Desktop.Views
{
    public sealed partial class ChartsPage : Page
    {
        private ChartsViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ChartsViewModel; }
        }

        // TODO WTS: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public ChartsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
