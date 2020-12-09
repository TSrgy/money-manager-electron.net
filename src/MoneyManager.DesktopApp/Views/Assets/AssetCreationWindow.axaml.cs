using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MoneyManager.DesktopApp.ViewModels.Assets;
using ReactiveUI;
using System;

namespace MoneyManager.DesktopApp.Views.Assets
{
    public class AssetCreationWindow : ReactiveWindow<AssetCreationWindowViewModel>
    {
        public Button SaveButton => this.FindControl<Button>("SaveButton");

        public TextBox NameTextBox => this.FindControl<TextBox>("NameTextBox");
        public AssetCreationWindow()
        {
            ViewModel = new AssetCreationWindowViewModel(null);
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                ViewModel.Save.Subscribe(x => this.Close());

                this.BindCommand(ViewModel,
                   vm => vm.Save,
                   v => v.SaveButton);

                this.Bind(ViewModel,
                  vm => vm.Name,
                  v => v.NameTextBox.Text);
            });
           



            AvaloniaXamlLoader.Load(this);

        }
    }
}
