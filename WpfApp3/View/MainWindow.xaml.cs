using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MvvmTest.Common;

namespace MvvmTest.View
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isRun = true;
        private readonly CancellationTokenSource tokenSource;
        private readonly CancellationToken token;

        public MainWindow()
        {
            InitializeComponent();
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            var timeTask = new Task(() => {

                while (_isRun)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    Thread.Sleep(200);
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        timeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
                    }));
                }

            }, token);
            timeTask.Start();

            CommandBindings.Add(new CommandBinding(CommonCommand.Add, ((s, e) =>
                {
                    MessageBox.Show("Add");
                }), ((s, e) =>
                {
                    e.CanExecute = true;
                })
            ));
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            tokenSource.Cancel();
            _isRun = false;
        }
    }
}
