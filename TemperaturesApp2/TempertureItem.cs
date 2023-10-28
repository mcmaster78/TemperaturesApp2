namespace TemperaturesApp2
{
    public class TemperatureItem
    {
        public string Date { get; private set; }
        public int Hour { get; private set; }
        public float Temperature { get; private set; }
        public TemperatureItem(string date, int hour, float temperature)
        {
            this.Date = date;
            this.Hour = hour;
            this.Temperature = temperature;
        }
        public void FillFromLine(string line)
        {
            var sub_line = "";
            var param_number = 0;
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ')
                {
                    if (param_number == 0)
                    {
                        this.Date = sub_line;
                    }
                    if (param_number == 1)
                    {
                        this.Hour = int.Parse(sub_line);
                    }
                    sub_line = "";
                    param_number++;
                }
                sub_line += line[i];
            }
            if (param_number == 2)
            {
                this.Temperature = float.Parse(sub_line);
            }

        }

        public string AsString()
        {
            var result = "";
            result += Date;
            result += " ";
            result += Hour.ToString();
            result += " ";
            result += Temperature.ToString();

            return result;
        }
    }
}