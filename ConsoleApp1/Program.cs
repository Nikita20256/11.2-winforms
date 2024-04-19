using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        public class MARSH
        {
            public string StartPoint { get; set; }
            public string EndPoint { get; set; }
            public int RouteNumber { get; set; }
        }

       
            static void Main()
            {
                // Генерация и занесение 10 элементов типа MARSH в файл данных
                MARSH[] marshArray = GenerateMarshArray(10);
                SaveMarshArrayToFile(marshArray, "marshdata.txt");

                // Чтение данных из файла и вывод их на экран
                MARSH[] readMarshArray = ReadMarshArrayFromFile("marshdata.txt");
                DisplayMarshArray(readMarshArray);

                // Вывод информации о маршруте, номер которого введен с клавиатуры
                Console.Write("Введите номер маршрута: ");
                int routeNumber = Convert.ToInt32(Console.ReadLine());
                MARSH routeInfo = FindMarshByRouteNumber(readMarshArray, routeNumber);
                if (routeInfo != null)
                {
                    Console.WriteLine($"Информация о маршруте {routeNumber}:\n" +
                                      $"Начальный пункт: {routeInfo.StartPoint}\n" +
                                      $"Конечный пункт: {routeInfo.EndPoint}");
                }
                else
                {
                    Console.WriteLine($"Маршрут с номером {routeNumber} не найден.");
                }
            }

            static MARSH[] GenerateMarshArray(int count)
            {
                MARSH[] array = new MARSH[count];
                for (int i = 0; i < count; i++)
                {
                    array[i] = new MARSH
                    {
                        StartPoint = "Start" + (i + 1),
                        EndPoint = "End" + (i + 1),
                        RouteNumber = i + 1
                    };
                }
                return array;
            }

            static void SaveMarshArrayToFile(MARSH[] marshArray, string filename)
            {
                using (StreamWriter writer = new StreamWriter(filename, false, Encoding.Default))
                {
                    foreach (MARSH marsh in marshArray)
                    {
                        writer.WriteLine($"{marsh.StartPoint},{marsh.EndPoint},{marsh.RouteNumber}");
                    }
                }
            }

            static MARSH[] ReadMarshArrayFromFile(string filename)
            {
                string[] lines = File.ReadAllLines(filename, Encoding.Default);
                MARSH[] marshArray = new MARSH[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    marshArray[i] = new MARSH
                    {
                        StartPoint = parts[0],
                        EndPoint = parts[1],
                        RouteNumber = int.Parse(parts[2])
                    };
                }
                return marshArray;
            }

            static void DisplayMarshArray(MARSH[] marshArray)
            {
                foreach (MARSH marsh in marshArray)
                {
                    Console.WriteLine($"Начальный пункт: {marsh.StartPoint}, " +
                                      $"Конечный пункт: {marsh.EndPoint}, " +
                                      $"Номер маршрута: {marsh.RouteNumber}");
                }
            }

            static MARSH FindMarshByRouteNumber(MARSH[] marshArray, int routeNumber)
            {
                foreach (MARSH marsh in marshArray)
                {
                    if (marsh.RouteNumber == routeNumber)
                    {
                        return marsh;
                    }
                }
                return null; // если маршрут не найден
            }
        
        
        
    }
}