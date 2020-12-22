using Windows.UI.Xaml.Controls;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnoApp.Common;
using UnoApp.ViewModels;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private UnoApp.ViewModels.ApplicationViewModel _model;
        public UnoApp.ViewModels.ApplicationViewModel Model => _model;
        public MainPage()
        {
            this.InitializeComponent();
            _model = new ApplicationViewModel();
            _model.PropertyChanged += OnAppPropertyChanged;
        }

        void OnAppPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (propertyName == nameof(ApplicationViewModel.CategoryName))
            {
                //AnnounceCategoryName();
            }
        }

        public List<object> UIElementsForCategories => CreateUIElementsForCategories(Model.Categories);

        public List<object> CreateUIElementsForCategories(ObservableCollection<NavCategoryGroup> categories)
        {
            var menuCategories = new List<object>();

            foreach (var group in categories)
            {
                menuCategories.Add(CreateNavViewHeaderFromGroup(group));

                foreach (var category in group.Categories)
                {
                    menuCategories.Add(CreateNavViewItemFromCategory(category));
                }
            }

            return menuCategories;
        }

        NavigationViewItemHeader CreateNavViewHeaderFromGroup(NavCategoryGroup group)
        {
            var header = new NavigationViewItemHeader();
            header.DataContext = group;

            header.Content = group.Name;

            return header;
        }

        NavigationViewItem CreateNavViewItemFromCategory(NavCategory category)
        {
            var item = new NavigationViewItem();
            item.DataContext = category;

            var icon = new FontIcon();
            //icon.FontFamily = (Windows.UI.Xaml.Media.FontFamily)(App.Current.Resources["CalculatorFontFamily"]);
            icon.Glyph = category.Glyph;
            item.Icon = icon;

            item.Content = category.Name;
            //item.AccessKey = category.AccessKey;
            item.Style = (Windows.UI.Xaml.Style)(Resources["NavViewItemStyle"]);

            return item;
        }


    }
}
