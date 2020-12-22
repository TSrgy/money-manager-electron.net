using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using UnoApp.Common;

namespace UnoApp.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string p = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

        private ObservableCollection<NavCategoryGroup> _categories;
        private string _categoryName;

        public ObservableCollection<NavCategoryGroup> Categories
        {
            get => _categories;
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    RaisePropertyChanged(nameof(Categories));
                }
            }
        }

        public string CategoryName { get => _categoryName; set { _categoryName = value; RaisePropertyChanged(nameof(CategoryName)); } }

        public ApplicationViewModel()
        {
            SetMenuCategories();
        }

        void SetMenuCategories()
        {
            // Use the Categories property instead of the backing variable
            // because we want to take advantage of binding updates and
            // property setter logic.
            Categories = NavCategoryGroup.CreateMenuOptions();
        }
    }
}
