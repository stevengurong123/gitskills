using MvvmTest.Common;
using MvvmTest.Model;
using MvvmTest.MVVM;
using System;
using System.Collections.ObjectModel;
using CommonServiceLocator;

namespace MvvmTest.ViewModel
{
    public class TotalCostViewModel : ViewModelExtense, ITotalCostViewModel
    {
        public TotalCostViewModel()
        {
            InitTree();
        }

        public ObservableCollection<IHierarchyConfigTreeNode> TotalCostTree { get; set; } = new ObservableCollection<IHierarchyConfigTreeNode>();

        private void InitTree()
        {
            var totalCost = XmlFormatHelper<TotalCost>.Read_T("test.xml");


            var root = new HierarchyConfigTreeNode { Name = totalCost.Year, IconPath = @"../Resources/Images/year.png", NodeType = Enum.NodeTypeEnum.Year };

            foreach (var month in totalCost.MonthList)
            {
                var currentMonth = new HierarchyConfigTreeNode { Name = month.Month.ToString(), IconPath = @"../Resources/Images/month.png", NodeType = Enum.NodeTypeEnum.Month,MyMonthCost = month };
                root.CreateTreeWithChildren(currentMonth);
            }
            TotalCostTree.Add(root);
        }
    }
}
