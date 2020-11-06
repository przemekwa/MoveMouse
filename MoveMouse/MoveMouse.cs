using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.ComponentModel;

namespace MoveMouse
{
    public class MoveMouse : INotifyPropertyChanged, ITimer
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        bool przeskok = true;
        public short czasDo { get; set; }
        
        string _currentState = "Disable";

        public string CurrentState {

            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
                NotifyPropertyChanged(nameof(CurrentState));
            }
        }

        DispatcherTimer t;          


        public MoveMouse()
        {
            t = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };

            t.Tick += new EventHandler(TickFunction);
        }

        void TickFunction(object sender, EventArgs e)
        {
            if (czasDo > short.Parse(DateTime.Now.ToString("HH")))
            {

                if (przeskok)
                {
                    SetCursorPos(300, 300);
                    przeskok = false;
                }
                else
                {
                    SetCursorPos(350, 350);
                    przeskok = true;
                }
            }
            else
            {
                this.Stop();
            }
        }

        public void Start()
        {
            t.Start();
            CurrentState = "Włączony";
        }

        public void Stop()
        {
            t.Stop();
            CurrentState = "Wyłączony";
        }



        protected virtual void NotifyPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
