using Autofac;
using MediatR;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.DesktopApp.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        private readonly Lazy<IContainer> _container;
        private readonly Lazy<IMediator> _mediator;

        protected IContainer Container => _container.Value;
        protected IMediator Mediator => _mediator.Value;

        public ViewModelBase()
        {
            _container = new Lazy<IContainer>(() => Locator.Current.GetService<IContainer>());
            _mediator = new Lazy<IMediator>(() => Container.Resolve<IMediator>());
        }
    }
}
