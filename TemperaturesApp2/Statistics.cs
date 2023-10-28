namespace TemperaturesApp2
{
    public class Statistics
    {
        public float Min { get; private set; }
        public string MinDay { get; private set; }
        public int MinHour { get; private set; }
        public float Max { get; private set; }
        public string MaxDay { get; private set; }
        public int MaxHour { get; private set; }
        public float Sum { get; private set; }
        public float Count { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public string AverageStr
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 30:
                        return "Gorąco";
                    case var average when average >= 20:
                        return "Ciepło";
                    case var average when average >= 15:
                        return "Chłodno";
                    case var average when average >= 10:
                        return "Lekko chłodno";
                    case var average when average >= 0:
                        return "Lekko zimno";
                    case var average when average >= -10:
                        return "Zimno";
                    default:
                        return "Trzaskający mróz";
                }
            }
        }
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
            this.MinDay = "";
            this.MaxDay = "";
            this.MinHour = -1;
            this.MaxHour = -1;
        }
        public void AddTemperature(TemperatureItem temperatureItem)
        {
            this.Count++;
            this.Sum += temperatureItem.Temperature;
            if (temperatureItem.Temperature < this.Min)
            {
                this.Min = temperatureItem.Temperature;
                this.MinDay = temperatureItem.Date;
                this.MinHour = temperatureItem.Hour;
            }
            if (temperatureItem.Temperature > this.Max)
            {
                this.Max = temperatureItem.Temperature;
                this.MaxDay = temperatureItem.Date;
                this.MaxHour = temperatureItem.Hour;
            }
        }

    }
}
