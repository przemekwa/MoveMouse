using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.ComponentModel;

namespace MoveMouse
{
    class MoveMouse2 : INotifyPropertyChanged, ITimer
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        bool przeskok = true;
        string _Stan = "Wyłączony";
        public short czasDo { get; set; }
        public string Stan {

            get
            {
                return _Stan;
            }


            set
            {
                _Stan = value;
                NotifyPropertyChanged("Stan");
            }
        }

        DispatcherTimer t;          


        public MoveMouse2()
        {
            t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 1);
            t.Tick += new EventHandler(t_Tick);
        }

        void t_Tick(object sender, EventArgs e)
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
            Stan = "Włączony";
        }

        public void Stop()
        {
            t.Stop();
            Stan = "Wyłączony";
        }



        protected virtual void NotifyPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
