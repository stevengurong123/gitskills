using System.Windows;
using CommonServiceLocator;
using System.Windows;
using MvvmTest.MVVM;
using System.Windows.Input;
using MvvmTest.Common;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace MvvmTest.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelExtense
    {
        private bool myState;
        private string _timeText;

        public MainViewModel()
        {
            Student = new Student { Name = "Tom" };
            ChangeName = new RelayCommand(ExecuteChangeName);
            TotalCostViewModel = ServiceLocator.Current.GetInstance<ITotalCostViewModel>();
            Start = new RelayCommand(ExecuteStart);
            Stop = new RelayCommand(ExecuteStop);
        }

        private void ExecuteStop(object obj)
        {

        }

        private async void ExecuteStart(object obj)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Application.Current?.Dispatcher.Invoke(new Action(() =>
                    {
                        TimeText = DateTime.Now.ToString("HH:mm:ss");
                    }));
                    //Thread.Sleep(1);
                }

                //for (int i = 0; i < 100; i++)
                //{
                //  //Dispatcher.BeginInvoke(new Action(() =>
                //  //{

                //  //    textBlock.Text = DateTime.Now.ToString("HH:mm:ss");
                //  //     Thread.Sleep(1000);
                //  //}));
                //    Dispatcher.BeginInvoke((Action)delegate ()
                //    {
                //        textBlock.Text = DateTime.Now.ToString("HH:mm:ss");

                //    });
                //    Thread.Sleep(1000);
                //}
            });
        }

        public ICommand ChangeName { get; private set; }
        public ICommand Start { get; private set; }
        public ICommand Stop { get; private set; }

        public Student Student
        {
            get; set;
        }
        public string TimeText
        {
            get => _timeText;
            set
            {
                _timeText = value;
                RaisePropertyChanged();
            }
        }
        public ITotalCostViewModel TotalCostViewModel
        {
            get;set;
        }
        public bool MyState
        {
            get => myState;
            set
            {
                myState = value;
                RaisePropertyChanged();
            }
        }
        private void ExecuteChangeName(object obj)
        {
            Student.Name = "Tom";
            MyState = true;
        }
    }
}