using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MvvmTest.MVVM
{
    public class ViewModelExtense : ViewModelBase, IDataErrorInfo
    {
        private Dictionary<string, string> _propertyErrors;
        public ViewModelExtense()
        {
            _propertyErrors = new Dictionary<string, string>();
        }

        public string this[string columnName]
        {
            get
            {
                var oldErr = Error;
                var error = ValidateProperty(columnName);
                if (_propertyErrors.ContainsKey(columnName))
                {
                    _propertyErrors[columnName] = error;
                }
                else
                {
                    _propertyErrors.Add(columnName, error);
                }

                if (oldErr != Error)
                {
                    PostErrorChanged();
                }

                return error;
            }
        }

        public virtual void PostErrorChanged()
        {
            
        }

        public virtual string ValidateProperty(string name)
        {
            return string.Empty;
        }

        public string Error
        {
            get
            {
                return string.Join(";", _propertyErrors.Where(kv=>!string.IsNullOrEmpty(kv.Value)).Select(e=>e.Value));
            }
        }

        //public void OnPropertyChanged([CallerMemberName]string name = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        //public void OnPropertyChanged<T>(ref T properValue, T newValue, [CallerMemberName]string name = "")
        //{
        //    if (!object.Equals(properValue, newValue))
        //    {
        //        properValue = newValue;
        //        OnPropertyChanged(name);
        //    }
        //}
    }
}
