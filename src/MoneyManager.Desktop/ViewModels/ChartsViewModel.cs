using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

using MoneyManager.Desktop.Core.Models;
using MoneyManager.Desktop.Core.Services;

namespace MoneyManager.Desktop.ViewModels
{
    public class ChartsViewModel : ViewModelBase
    {
        public ObservableCollection<DataPoint> Source { get; } = new ObservableCollection<DataPoint>();

        public ChartsViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await SampleDataService.GetChartDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
