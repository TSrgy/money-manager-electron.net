using Autofac;
using MediatR;
using MoneyManager.Application.Assets.Commands.CreateAsset;
using ReactiveUI;
using Splat;

namespace MoneyManager.DesktopApp.ViewModels.Assets
{
    public class AssetCreationWindowViewModel : ViewModelBase
    {
        private IMediator _mediator;

        private string _name;
        public string Name { get => _name; set => this.RaiseAndSetIfChanged(ref _name, value); }
        public AssetCreationWindowViewModel(IMediator mediator)
        {
            _name = string.Empty;
            var container = Locator.Current.GetService<IContainer>();
            _mediator = mediator ?? container.Resolve<IMediator>();
            Save = ReactiveCommand.CreateFromTask(() =>
            {
                return _mediator.Send(new CreateAssetCommand()
                {
                    Name = _name
                });
            });
        }

        public ReactiveCommand<System.Reactive.Unit, long> Save { get; private set; }
    }
}
