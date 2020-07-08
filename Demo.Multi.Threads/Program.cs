using System.Collections.ObjectModel;

namespace Demo.Multi.Threads
{
    public class Program
    {
        public ObservableCollection<Hilo> ListaHilos { get; set; }

        public Program()
        {
            this.ListaHilos = new ObservableCollection<Hilo>();
            this.ListaHilos.Add(new Hilo(1));
            this.ListaHilos.Add(new Hilo(2));
            this.ListaHilos.Add(new Hilo(5));
        }
    }
}