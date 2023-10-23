using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace soc.Model
{
    public class Mylog : INotifyPropertyChanged
    {
        private int _id;
        private string _message;
        private DateTime _time;

        public Mylog(int id, string msg, DateTime time)
        {
            _id=id;
            _message=msg;
            _time=time;
        }

        public int Id
        {
            get => _id;
            set
            { 
                _id = value;
                PropertyChangedEventHandler();
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                PropertyChangedEventHandler();
            } 
        }

        public DateTime Time
        {
            get => _time; 
            set 
            { 
                _time = value;
                PropertyChangedEventHandler();
            }
        }
        private void PropertyChangedEventHandler([CallerMemberName] string? propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
