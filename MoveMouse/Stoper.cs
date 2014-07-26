using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.ComponentModel;

namespace MoveMouse
{
    class Stoper : INotifyPropertyChanged, ITimer
    {
        public TimeSpan _czas = new TimeSpan(0, 0, 0);
        public event PropertyChangedEventHandler PropertyChanged;

        public short czasDo { get; set; }

        public string Czas { 
            get
            {

                return _czas.ToString();
            }

            set
        {
            _czas = TimeSpan.Parse(value);
            NotifyPropertyChanged("Czas");

        }
        }


        DispatcherTimer t;
        
        public Stoper()
        {
            t = new DispatcherTimer();
            t.Interval = new TimeSpan(0,0,1);
            t.Tick += new EventHandler(t_Tick);
        }

        void t_Tick(object sender, EventArgs e)
        {
            
            if (czasDo > short.Parse(DateTime.Now.ToString("hh")))
            {
                Czas = TimeSpan.Parse(Czas).Add(new TimeSpan(0, 0, 1)).ToString();
            }
            else
            {
                this.Stop();
            }
            
        }

        public void Start()
        {
           
            t.Start();
        }

        public void Stop()
        {
            Czas = new TimeSpan(0, 0, 0).ToString();

            t.Stop();
            
        }

        

        protected virtual void NotifyPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }



        public event EventHandler Disposed;

        
    }
}
