using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MoneyManager.DesktopApp.Views.Assets;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;

namespace MoneyManager.DesktopApp.ViewModels.Assets
{
    public class AssetsViewModel : ViewModelBase, IActivatableViewModel
    {
        public DataGridCollectionView Items { get; }
        public ReactiveCommand<Unit, Unit> OpenCreateAssetDialog { get; }

        public ViewModelActivator Activator => new ViewModelActivator();

        public AssetsViewModel()
        {
            Items = null;
            OpenCreateAssetDialog = ReactiveCommand.Create(() =>
            {
                var window = new AssetCreationWindow();
                window.ShowDialog<long>(GetWindow());
            });
            //Items = new DataGridCollectionView();
        }

        private Window GetWindow()
        {
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
                return desktopLifetime.MainWindow;
            }
            return null;
        }
    }
}
