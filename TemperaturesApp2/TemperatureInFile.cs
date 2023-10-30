//format danych trzymanych w pliku (rozdzielane spacją): data godzina temperatura

namespace TemperaturesApp2
{
    public class TemperatureInFile : TemperatureBase
    {

        private const string fileName = "temperatutures.txt";
        public override void AddTemperature(string date, int hour, float temperature)
        {
            if (hour < 0 || hour > 23)
            {
                throw new Exception("f Wprowadzono nieprawidłową godzinę, dopuszczalne: 0-23.");
            }

            if (temperature < -273.4f)
            {
                throw new Exception("f Nie istnieje temperatura poniżej -273.4stC");
            }

            var temperatureItem = new TemperatureItem(date, hour, temperature);
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(temperatureItem.AsString());
                ExecuteEventTemperatureAdded();
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            var temp_item = new TemperatureItem("no_date", -1, -273.5f);
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        temp_item.FillFromLine(line);
                        result.AddTemperature(temp_item);
                        Console.WriteLine(temp_item.Date);
                        Console.WriteLine(temp_item.Hour);
                        Console.WriteLine(temp_item.Temperature);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }
        public override Statistics GetStatistics(string date)
        {
            var result = new Statistics();
            var temp_item = new TemperatureItem("no_date", -1, -273.5f);
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        temp_item.FillFromLine(line);
                        if (temp_item.Date == date)
                        {
                            result.AddTemperature(temp_item);
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }
    }
}
