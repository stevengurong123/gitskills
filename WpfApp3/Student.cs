using MvvmTest.MVVM;

namespace MvvmTest
{
    public class Student: ViewModelExtense
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                //OnPropertyChanged<string>(ref _name,value );
                _name = value;
                RaisePropertyChanged();
            }
        }

        public override string ValidateProperty(string name)
        {
            if (name == nameof(Name))
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return "name is empty";
                }
            }
            return base.ValidateProperty(name);
        }
    }
}
