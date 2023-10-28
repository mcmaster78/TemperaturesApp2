namespace TemperaturesApp2
{
    public class TemperatureInMemory : TemperatureBase
    {

        List<TemperatureItem> TemperaturesList = new List<TemperatureItem>();
        public override void AddTemperature(string date, int hour, float temperature)
        {
            var temperatureItem = new TemperatureItem(date, hour, temperature);
            TemperaturesList.Add(temperatureItem);
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            var count = 0;
            foreach (var temperature in TemperaturesList)
            {
                result.AddTemperature(temperature);
                count++;

            }
            return result;
        }
        public override Statistics GetStatistics(string date)
        {
            var result = new Statistics();
            bool date_exist = false;
            foreach (var temperature in TemperaturesList)
            {
                if (temperature.Date == date)
                {
                    date_exist = true;
                }
            }
            if (date_exist == false)
            {
                throw new Exception("Nie znaleziono danych dla podanej daty.");
            }
            foreach (var temperature in TemperaturesList)
            {
                if (temperature.Date == date)
                {
                    result.AddTemperature(temperature);
                }
            }
            return result;

        }
    }
}
