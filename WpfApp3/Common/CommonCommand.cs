using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest.Common
{
    public static class CommonCommand
    {
        public static RoutedCommand Add { get; } = new RoutedCommand(nameof(Add), typeof(CommonCommand), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control, "Ctrl+A") });
    }
}
