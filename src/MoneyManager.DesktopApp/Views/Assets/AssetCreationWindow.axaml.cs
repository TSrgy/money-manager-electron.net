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
        public DatePicker DatePicker => this.FindControl<DatePicker>("DatePicker");
        public NumericUpDown ValueNumericUpDown => this.FindControl<NumericUpDown>("ValueNumericUpDown");
        public TextBox NotesTextBox => this.FindControl<TextBox>("NotesTextBox");
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
                ViewModel.Save.Subscribe(x => Close(x));

                this.BindCommand(ViewModel,
                   vm => vm.Save,
                   v => v.SaveButton);

                this.Bind(ViewModel,
                  vm => vm.Name,
                  v => v.NameTextBox.Text);

                this.Bind(ViewModel,
                    vm => vm.Date,
                    v => v.DatePicker.SelectedDate);

                this.Bind(ViewModel,
                    vm => vm.Value,
                    v => v.ValueNumericUpDown.Value,
                    value => Convert.ToDouble(value),
                    value => Convert.ToDecimal(value));

                this.Bind(ViewModel,
                    vm => vm.Notes,
                    v => v.NotesTextBox.Text);
            });
           



            AvaloniaXamlLoader.Load(this);

        }
    }
}
