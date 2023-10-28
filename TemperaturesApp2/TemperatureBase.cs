using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TemperaturesApp2
{
    public abstract class TemperatureBase : ITemperature
    {
        public delegate void TemperatureAddedDelegate(object sender, EventArgs args);
        public event TemperatureAddedDelegate TemperatureAdded;
        public TemperatureBase()
        {
            TemperatureAdded += WriteMessageTemperatureAdded;
        }
        public abstract void AddTemperature(string date, int hour, float temperature);
        public abstract Statistics GetStatistics();

        public abstract Statistics GetStatistics(string date);
        public void WriteMessageTemperatureAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Dodano nowe dane.");
        }
        public void ExecuteEventTemperatureAdded()
        {
            TemperatureAdded(this, new EventArgs());
        }

    }
}
