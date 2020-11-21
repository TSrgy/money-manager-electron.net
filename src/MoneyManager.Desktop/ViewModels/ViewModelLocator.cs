using System;

using GalaSoft.MvvmLight.Ioc;

using MoneyManager.Desktop.Services;
using MoneyManager.Desktop.Views;

namespace MoneyManager.Desktop.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<ChartsViewModel, ChartsPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public SettingsViewModel SettingsViewModel => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public ChartsViewModel ChartsViewModel => SimpleIoc.Default.GetInstance<ChartsViewModel>();

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
