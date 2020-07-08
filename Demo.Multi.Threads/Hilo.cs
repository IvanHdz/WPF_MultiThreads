using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Demo.Multi.Threads
{
    public class Hilo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //private readonly DispatcherTimer dt;
        private Thread demo;
        private readonly double ticks = 0;
        private double tiempo = 0;

        public Hilo(double segundosRefresh)
        {
            ticks = 1000 * segundosRefresh;
            demo = new Thread(new ParameterizedThreadStart(s => this.DemoThread()));
            demo.Start();
        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Tiempo
        {
            get
            {
                return tiempo;
            }
            set
            {
                if (tiempo != value)
                {
                    tiempo = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void DemoThread()
        {
            while (true)
            {
                Tiempo += 1;

                if (Tiempo == 10)
                {
                    Tiempo = 0;
                    Thread.Sleep(5000);
                }
                else
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(ticks));
                }
            }
        }
    }
}