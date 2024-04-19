
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;


namespace _11ю2
{
    namespace MarshApplication
    {
        public partial class MainForm : Form
        {
            private MARSH[] _marshArray;

            public MainForm()
            {
                InitializeComponent();
            }

            private void generateAndSaveButton_Click(object sender, EventArgs e)
            {
                // Генерация и сохранение данных в файл
                _marshArray = GenerateMarshArray(10);
                SaveMarshArrayToFile(_marshArray, "marshdata.txt");

                MessageBox.Show("Данные сгенерированы и сохранены в файл marshdata.txt.", "Готово");
            }

            private void loadAndDisplayButton_Click(object sender, EventArgs e)
            {
                // Загрузка данных из файла и вывод на экран
                _marshArray = ReadMarshArrayFromFile("marshdata.txt");
                DisplayMarshArray(_marshArray);
            }

            private void findRouteButton_Click(object sender, EventArgs e)
            {
                // Вывод информации о маршруте по введенному номеру
                if (int.TryParse(routeNumberTextBox.Text, out int routeNumber))
                {
                    MARSH routeInfo = FindMarshByRouteNumber(_marshArray, routeNumber);
                    if (routeInfo != null)
                    {
                        MessageBox.Show($"Начальный пункт: {routeInfo.StartPoint}\nКонечный пункт: {routeInfo.EndPoint}", $"Информация о маршруте {routeNumber}");
                    }
                    
                    {
                        MessageBox.Show($"Маршрут с номером {routeNumber} не найден.", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный формат номера маршрута.", "Ошибка");
                }
            }

            private MARSH[] GenerateMarshArray(int count)
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

            private void SaveMarshArrayToFile(MARSH[] marshArray, string filename)
            {
                using (StreamWriter writer = new StreamWriter(filename, false, Encoding.Default))
                {
                    foreach (MARSH marsh in marshArray)
                    {
                        writer.WriteLine($"{marsh.StartPoint},{marsh.EndPoint},{marsh.RouteNumber}");
                    }
                }
            }

            private MARSH[] ReadMarshArrayFromFile(string filename)
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

            private void DisplayMarshArray(MARSH[] marshArray)
            {
                StringBuilder sb = new StringBuilder();
                foreach (MARSH marsh in marshArray)
                {
                    sb.AppendLine($"Начальный пункт: {marsh.StartPoint}, " +
                                  $"Конечный пункт: {marsh.EndPoint}, " +
                                  $"Номер маршрута: {marsh.RouteNumber}");
                }
                MessageBox.Show(sb.ToString(), "Данные из файла");
            }

            private MARSH FindMarshByRouteNumber(MARSH[] marshArray, int routeNumber)
            {
                return marshArray.FirstOrDefault(x => x.RouteNumber == routeNumber);
            }
        }

        public class MARSH
        {
            public string StartPoint { get; set; }
            public string EndPoint { get; set; }
            public int RouteNumber { get; set; }
        }
    }
}