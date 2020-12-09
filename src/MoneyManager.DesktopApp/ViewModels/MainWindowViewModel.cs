using MoneyManager.DesktopApp.ViewModels.Assets;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;

namespace MoneyManager.DesktopApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        public AssetsViewModel AssetsViewModel { get; }
        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router => new RoutingState();
        public string Greeting => "Welcome to Avalonia!";

        // The command that navigates a user to first view model.
        //public ReactiveCommand<Unit, IRoutableViewModel> GoToAssets { get; }

        public ObservableCollection<TreeNode> TreeItems { get; }

        public ObservableCollection<TreeNode> SelectedTreeItems { get; }

        public MainWindowViewModel()
        {
            AssetsViewModel = new AssetsViewModel();
            var root = new TreeNode("root")
            {
                Children =
                {
                    new TreeNode("Assets")
                }
            };
            TreeItems = root.Children;
            SelectedTreeItems = new ObservableCollection<TreeNode>();
            // Manage the routing state. Use the Router.Navigate.Execute
            // command to navigate to different view models. 
            //
            // Note, that the Navigate.Execute method accepts an instance 
            // of a view model, this allows you to pass parameters to 
            // your view models, or to reuse existing view models.
            //
            //GoToAssets = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new AssetsViewModel(this)));
        }

        public class TreeNode
        {
            private ObservableCollection<TreeNode> _children;

            public string Header { get; private set; }

            public ObservableCollection<TreeNode> Children => _children;

            public TreeNode(string header)
            {
                Header = header;
                _children = new ObservableCollection<TreeNode>();
            }
            public override string ToString() => Header;
        }
    }
}
