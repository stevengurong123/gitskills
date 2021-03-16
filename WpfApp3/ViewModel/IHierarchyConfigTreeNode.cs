using MvvmTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest.ViewModel
{
    public interface IHierarchyConfigTreeNode
    {
        IHierarchyConfigTreeNode Parent { get; set; }

        ObservableCollection<IHierarchyConfigTreeNode> Children { get; set; }

        string Name { get; }

        string IconPath { get; }

        bool IsSelected { get; }

        MonthCost MyMonthCost { get; set; }

        IHierarchyConfigTreeNode SelectedTreeItem { get; }

        void CreateTreeWithChildren(IHierarchyConfigTreeNode children);

        void DeleteTreeNodeWithChildren(IHierarchyConfigTreeNode children);

        event Action OnNodeSelectedChanged;

        ICommand AddCommand { get; }

        ICommand DeleteCommand { get; }

        //Device GetSelectedDevice();
    }
}
