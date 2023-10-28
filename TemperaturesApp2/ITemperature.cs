namespace TemperaturesApp2
{
    public interface ITemperature
    {
        delegate void TemperatureAddedDelegate(object sender, EventArgs args);
        void AddTemperature(string date, int hour, float temperature);
        Statistics GetStatistics();
        Statistics GetStatistics(string date);
        void WriteMessageTemperatureAdded(object sender, EventArgs args);
        void ExecuteEventTemperatureAdded();
    }
}
