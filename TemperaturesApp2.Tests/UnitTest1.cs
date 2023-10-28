namespace TemperaturesApp2.Tests
{
    public class Tests
    {
        [Test]
        public void TestAverageTemperature()
        {
            var temperatures = new TemperatureInMemory();
            temperatures.AddTemperature("dzisiaj", 10, 5); //data, godzina, temperatura
            temperatures.AddTemperature("dzisiaj", 15, 15);
            temperatures.AddTemperature("wczoraj", 10, 10);
            temperatures.AddTemperature("dzisiaj", 15, 15);
            temperatures.AddTemperature("dzisiaj", 15, 5);
            var statistics = temperatures.GetStatistics();
            Assert.AreEqual(10, statistics.Average);
        }
        public void TestAverageTemperatureForDay()
        {
            var temperatures = new TemperatureInMemory();
            temperatures.AddTemperature("dzisiaj", 10, 10);
            temperatures.AddTemperature("dzisiaj", 15, 20);
            var statistics = temperatures.GetStatistics("dzisiaj");
            Assert.AreEqual(15, statistics.Average);
        }
        public void TestMaxTemperature()
        {
            var temperatures = new TemperatureInMemory();
            temperatures.AddTemperature("wczoraj", 6, -10);
            temperatures.AddTemperature("dzisiaj", 10, 10);
            temperatures.AddTemperature("dzisiaj", 15, 25);
            var statistics = temperatures.GetStatistics();
            Assert.AreEqual(25, statistics.Max);
        }
        public void TestMaxTemperatureForDay()
        {
            var temperatures = new TemperatureInMemory();
            temperatures.AddTemperature("wczoraj", 6, -10);
            temperatures.AddTemperature("dzisiaj", 10, 10);
            temperatures.AddTemperature("dzisiaj", 15, 30);
            var statistics = temperatures.GetStatistics("dzisiaj");
            Assert.AreEqual(30, statistics.Max);
        }
        public void TestMinTemperature()
        {
            var temperatures = new TemperatureInMemory();
            temperatures.AddTemperature("wczoraj", 4, -15);
            temperatures.AddTemperature("wczoraj", 6, -10);
            temperatures.AddTemperature("dzisiaj", 10, 10);
            temperatures.AddTemperature("dzisiaj", 15, 25);
            var statistics = temperatures.GetStatistics();
            Assert.AreEqual(-15, statistics.Max);
        }
        public void TestMinTemperatureForDay()
        {
            var temperatures = new TemperatureInMemory();
            temperatures.AddTemperature("wczoraj", 4, -25);
            temperatures.AddTemperature("wczoraj", 6, -10);
            temperatures.AddTemperature("dzisiaj", 10, 10);
            temperatures.AddTemperature("dzisiaj", 15, 25);
            var statistics = temperatures.GetStatistics("wczoraj");
            Assert.AreEqual(-25, statistics.Max);
        }
    }
}