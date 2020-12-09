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

        public AssetsView()
        {
            InitializeComponent();
            var dg = this.FindControl<DataGrid>("assetsDataGrid");
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                this.BindCommand(ViewModel,
                    vm => vm.OpenCreateAssetDialog,
                    v => v.CreateAssetButton)
                .DisposeWith(disposables);
            });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
