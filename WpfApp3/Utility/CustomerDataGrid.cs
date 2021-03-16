using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmTest.Utility
{
    public class CustomerDataGrid : DataGrid
    {
        public CustomerDataGrid()
        {
            this.SelectionChanged += CustomerDataGrid_SelectionChanged;
        }

        private void CustomerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetValue(SelectedListProperty, base.SelectedItem);
        }

        public static readonly DependencyProperty SelectedListProperty = DependencyProperty.Register(
            "SelectedList", typeof(IEnumerable), typeof(CustomerDataGrid), new PropertyMetadata(null));

        public IList SelectedList
        {
            get { return (IList)GetValue(SelectedListProperty); }
            set { }
        }
    }
}
