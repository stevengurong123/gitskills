
using System.Collections.ObjectModel;

namespace MvvmTest.ViewModel
{
    public interface ITotalCostViewModel
    {
        ObservableCollection<IHierarchyConfigTreeNode> TotalCostTree { get; set; }
        
    }
}
