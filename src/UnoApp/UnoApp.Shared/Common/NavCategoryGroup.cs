using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace UnoApp.Common
{
    [Windows.UI.Xaml.Data.Bindable]
    public sealed class NavCategory : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private string _glyph;

        public string Name => _name;

        public string Glyph => _glyph;

        internal NavCategory(string name, string glyph)
        {
            _name = name;
            _glyph = glyph;
        }


    }

    [Windows.UI.Xaml.Data.Bindable]
    public sealed class NavCategoryGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string p = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

        private ObservableCollection<NavCategory> _categories;
        public ObservableCollection<NavCategory> Categories { get => _categories; private set { _categories = value; RaisePropertyChanged(nameof(Categories)); } }

        private string _name;

        public string Name { get => _name; private set { _name = value; RaisePropertyChanged(nameof(Name)); } }

        internal NavCategoryGroup(string name, IEnumerable<NavCategory> navCategories)
        {
            _name = name;
            _categories = new ObservableCollection<NavCategory>(navCategories);
        }

        public static ObservableCollection<NavCategoryGroup> CreateMenuOptions()
        {
            var menuOptions = new ObservableCollection<NavCategoryGroup>();
            menuOptions.Add(new NavCategoryGroup("main", defaultCategories()));
            return menuOptions;
        }

        private static IEnumerable<NavCategory> defaultCategories()
        {
            yield return new NavCategory("Bank Accounts", "\uE8EF");
        }
    }
}
