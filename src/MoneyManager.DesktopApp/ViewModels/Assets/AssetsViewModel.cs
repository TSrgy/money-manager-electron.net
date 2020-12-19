using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MoneyManager.Application.Assets.Queries;
using MoneyManager.DesktopApp.Views.Assets;
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MoneyManager.DesktopApp.ViewModels.Assets
{
    public class AssetsViewModel : ViewModelBase, IActivatableViewModel
    {
        private DataGridCollectionView _items;
        public DataGridCollectionView Items { get => _items; set => this.RaiseAndSetIfChanged(ref _items, value); }
        public ReactiveCommand<Unit, long> OpenCreateAssetDialog { get; }

        public ViewModelActivator Activator => new ViewModelActivator();

        public AssetsViewModel()
        {
            FillItems();
            OpenCreateAssetDialog = ReactiveCommand.CreateFromTask(async () =>
            {
                var window = new AssetCreationWindow();
                return await window.ShowDialog<long>(GetWindow());
            });

            OpenCreateAssetDialog
                .Where(id => id > 0)
                .Subscribe(id =>
                {
                    FillItems();
                });
            //Items = new DataGridCollectionView();
        }

        private void FillItems()
        {
            var assets = Mediator.Send(new GetAssetsQuery()).Result;
            Items = new DataGridCollectionView(assets.Assets);
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
