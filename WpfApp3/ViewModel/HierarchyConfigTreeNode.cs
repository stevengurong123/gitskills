
using MvvmTest.Enum;
using MvvmTest.Model;
using MvvmTest.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MvvmTest.ViewModel
{
    public class HierarchyConfigTreeNode : ViewModelExtense, IHierarchyConfigTreeNode
    {
        private IHierarchyConfigTreeNode _parent;
        private string _name;
        private string _iconPath;
        private bool _isSelected;
        private IHierarchyConfigTreeNode _selectedTreeItem;

        public HierarchyConfigTreeNode()
        {
            Children = new ObservableCollection<IHierarchyConfigTreeNode>();
            AddCommand = new RelayCommand(ExecuteAddCommand);
        }

        private void ExecuteAddCommand(object nodetype)
        {
            var x = (NodeTypeEnum)nodetype;
        }

        public IHierarchyConfigTreeNode Parent
        {
            get { return _parent; }
            set { Set(ref _parent, value); }
        }
        public ObservableCollection<IHierarchyConfigTreeNode> Children
        {
            get; set;
        }

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        public string IconPath
        {
            get { return _iconPath; }
            set { Set(ref _iconPath, value); }
        }

        public NodeTypeEnum NodeType { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;

                if (_isSelected)
                {
                    SelectedTreeItem = this;
                    OnNodeSelectedChanged();
                    //Messenger.Default.Send(new NotificationMessage("SelectedChanged"));
                    //Messenger.Default.Send(new NotificationMessage<IHierarchyConfigTreeNode>(SelectedTreeItem, "IsSelected"));
                    //Messenger.Default.Send<IHierarchyConfigTreeNode>(SelectedTreeItem);
                }
                else
                    SelectedTreeItem = null;
            }
        }

        public MonthCost MyMonthCost { get; set; }

        public IHierarchyConfigTreeNode SelectedTreeItem
        {
            get { return this._selectedTreeItem; }
            set { Set(ref this._selectedTreeItem, value); }
        }

        public Visibility Menu_Add_Visibility { get { return this.NodeType == NodeTypeEnum.Year ? Visibility.Visible : Visibility.Collapsed; } }

        public Visibility Menu_Delete_Visibility { get { return this.NodeType != NodeTypeEnum.Year ? Visibility.Visible : Visibility.Collapsed; } }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public event Action OnNodeSelectedChanged = delegate { };

        public void CreateTreeWithChildren(IHierarchyConfigTreeNode children)
        {
            children.Parent = this;
            this.Children.Add(children);
        }

        public void DeleteTreeNodeWithChildren(IHierarchyConfigTreeNode children)
        {
            children.Parent = null;
            this.Children.Remove(children);
        }
    }
}
