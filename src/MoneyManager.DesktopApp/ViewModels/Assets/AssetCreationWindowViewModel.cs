using Autofac;
using MediatR;
using MoneyManager.Application.Assets.Commands.CreateAsset;
using ReactiveUI;
using Splat;
using System;

namespace MoneyManager.DesktopApp.ViewModels.Assets
{
    public class AssetCreationWindowViewModel : ViewModelBase
    {
        private string _name;
        private DateTime _date;
        private string _notes;
        private decimal _value;

        public string Name { get => _name; set => this.RaiseAndSetIfChanged(ref _name, value); }
        public DateTime Date { get => _date; set => this.RaiseAndSetIfChanged(ref _date, value); }
        public string Notes { get => _notes; set => this.RaiseAndSetIfChanged(ref _notes, value); }
        public decimal Value { get => _value; set => this.RaiseAndSetIfChanged(ref _value, value); }

        public AssetCreationWindowViewModel(IMediator mediator)
        {
            _date = DateTime.Now;
            _name = string.Empty;

            Save = ReactiveCommand.CreateFromTask(() =>
            {
                return Mediator.Send(new CreateAssetCommand()
                {
                    Name = _name,
                    Date = _date,
                    Value = _value,
                    Notes = _notes
                });
            });
        }

        public ReactiveCommand<System.Reactive.Unit, long> Save { get; private set; }
    }
}
