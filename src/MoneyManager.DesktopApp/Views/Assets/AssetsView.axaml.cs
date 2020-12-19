using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MoneyManager.DesktopApp.ViewModels.Assets;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MoneyManager.DesktopApp.Views.Assets
{
    public class AssetsView : ReactiveUserControl<AssetsViewModel>
    {
        public Button CreateAssetButton => this.FindControl<Button>("createAssetButton");
        public DataGrid AssetsDataGrid => this.FindControl<DataGrid>("assetsDataGrid");

        public AssetsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel,
                    vm => vm.Items,
                    v => v.AssetsDataGrid.Items)
                .DisposeWith(disposables);

                this.BindCommand(ViewModel,
                    vm => vm.OpenCreateAssetDialog,
                    v => v.CreateAssetButton)
                .DisposeWith(disposables);
            });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
