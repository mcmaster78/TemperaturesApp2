// To jest program do statystyk temperatur, który może wyświetlać najmniejszą i największą temperaturę z całej historri lub z danego dnia, dodatkowo wyświetla słownie podsumowanie średniej np.: 'Zimno'. Nie robiłem wszystkich możliwych walidacji (np.datę mozna zapisać zarówno 'RRRR-MM-DD' i np.: 'dzisiaj')
//Zuzia zalecała nie robić aplikacji z wieloma danymi zapisywanymi do pliku (tylko jedna dana liczbowa), gdyż twierdziła że to skomplikuje program i niepotrzebnie się narobię. Pisała że takie rzeczy lepiej zrobić na bazie danych. Jednak gdybym zrobił tak jak Zuzia proponowała to program byłby właściwie taki sam jak w kursie w aplikacji z ocenami pracowników. Wybrałem trochę trudniejszą wersję z wieloma danymi w pliku/pamięci. Po za tym chcialem wszystko napisać od zera aby się utrwaliło programowanie. 
using TemperaturesApp2;

var temperatures = new TemperatureInFile(); //tu zmieniamy TemperatureInFile na TemperatureInMemory jeżeli
//program ma pracować na pamięci.
string dateParam = "no-date";
int hourParam = -1;
float temperatureParam = -273.5f;


Console.WriteLine("Witamy w programie do statystyk temperatur.");
Console.WriteLine("Wprowadż dane pomiaru w formacie: RRRR-MM-DD Godzina Temperatura");
Console.WriteLine("Godzina jako liczba całkowita 0-23.");
Console.WriteLine("Wpisz '-a' aby wyświetlić statystykę ze wszystkich dni.");
Console.WriteLine("Wpisz '-d data' aby wyświetlić statystykę dla danego dnia.");
Console.WriteLine("Wpisz 'q' aby zakończyć program.");
Console.WriteLine("");
Console.WriteLine("Wprowadż dane pomiaru:");

while (true)
{
    var input = Console.ReadLine();
    if (input == "Q" || input == "q")
    {
        Console.WriteLine("Dziękujemy za skorzystanie z programu.");
        break;
    }
    if (GetParameter(input, 0) == "-d" || GetParameter(input, 0) == "-D")
    {
        try
        {
            var statisticsDay = temperatures.GetStatistics(GetParameter(input, 1));
            Console.WriteLine($"Najniższa temperatura w dniu {GetParameter(input, 1)} to {statisticsDay.Min}st.C, o godzinie {statisticsDay.MinHour}.");
            Console.WriteLine($"Najwyższa temperatura w dniu {GetParameter(input, 1)} to {statisticsDay.Max}st.C, o godzinie {statisticsDay.MaxHour}.");
            Console.WriteLine($"Średnia temperatur: {statisticsDay.Average}st.C ({statisticsDay.AverageStr}).");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        continue;
    }
    if (input == "-a" || input == "-A")
    {
        try
        {
            var statistics = temperatures.GetStatistics();
            Console.WriteLine($"Najniższa temperatura z całej historii to {statistics.Min}st.C, w dniu {statistics.MinDay} o godzinie {statistics.MinHour}.");
            Console.WriteLine($"Najwyższa temperatura z calej historii to {statistics.Max}st.C, w dniu {statistics.MaxDay} o godzinie {statistics.MaxHour}.");
            Console.WriteLine($"Średnia temperatur: {statistics.Average}st.C ({statistics.AverageStr}).");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        continue;
    }

    if (GetParameter(input, 0).Length == 0 || GetParameter(input, 1).Length == 0 || GetParameter(input, 2).Length == 0)
    {
        Console.WriteLine("Nie wprowadzono wszystkich parametrów");
    }
    else
    {
        dateParam = GetParameter(input, 0);
        if (int.TryParse(GetParameter(input, 1), out hourParam) && float.TryParse(GetParameter(input, 2), out temperatureParam))
        {
            try
            {
                temperatures.AddTemperature(dateParam, hourParam, temperatureParam);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          
        }
        else
        {
            Console.WriteLine("Parametr Godzina lub Temperatura nie jest prawidłową liczbą.");
        }

    }
    Console.WriteLine("Wprowadź kolejne dane pomiaru:");
}
Console.ReadLine();

string GetParameter(string str, int number)  //metoda zwraca podciąg o indeksie 'number' z ciagu 'str' rozdzielanego spacjami
{
    var sub_str_number = 0;
    var sub_str = "";
    for (var i = 0; i < str.Length; i++)
    {
        if (str[i] == ' ')
        {
            sub_str_number++;
            continue;
        }
        if (sub_str_number == number)
        {
            sub_str += str[i];
        }
    }
    return sub_str;
}
