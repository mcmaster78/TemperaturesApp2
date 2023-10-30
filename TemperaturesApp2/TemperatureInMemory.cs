namespace TemperaturesApp2
{
    public class TemperatureInMemory : TemperatureBase
    {

        List<TemperatureItem> TemperaturesList = new List<TemperatureItem>();
        public override void AddTemperature(string date, int hour, float temperature)
        {
            if (hour < 0 || hour > 23)
            {
                throw new Exception("m Wprowadzono nieprawidłową godzinę, dopuszczalne: 0-23.");
            }

            if (temperature < -273.4f)
            {
                throw new Exception("m Nie istnieje temperatura poniżej -273.4stC");
            }

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
