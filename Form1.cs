using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace _11._2_winforms
{
    public struct Aeroflot
    {
        public string destination;
        public string flightNumber;
        public string aircraftType;

        public override string ToString()
        {
            return $"{destination} - {flightNumber} - {aircraftType}";
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBoxPlanes.DataSource = aircraftTypeList;
            object commandPlane = listBoxPlanes.SelectedItem;
            File.WriteAllText(filePath, string.Empty);
            GenerateFlights();
            Files(filePath, flightNumbersList);
            FileRead(filePath);
        }
        string filePath = @"D:\Университет\Лабораторные\Основы программирования\Лабораторная 11\данные.txt";
        List<string> destinationsList = new List<string> { "Moscow (SVO)", "St. Petersburg (LED)", "Tomsk (TOF)", "Detroit(DTW)", "Saratov(RTW)", "Ufa (UFA)", "Ukhta (UCT)", "Khabarovsk (KHV)", "Magadan (GDX)", "Barnaul (BAX)" };
        List<string> aircraftTypeList = new List<string> { "Airbus, A320", "Boeing, 737", "Sukhoi, Superjet 100", "Bombardier, CRJ700", "Embraer, E175" };
        List<Aeroflot> flightNumbersList = new List<Aeroflot>();
        private void GenerateFlights()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                string tempFlightNumber = (rand.Next(100, 1000)).ToString("D3");
                string tempDestination = destinationsList[rand.Next(0, destinationsList.Count)];
                string tempAircraftType = aircraftTypeList[rand.Next(0, aircraftTypeList.Count)];
                Aeroflot aeroflot = new Aeroflot { destination = tempDestination, flightNumber = tempFlightNumber, aircraftType = tempAircraftType };
                flightNumbersList.Add(aeroflot);
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string commandPlane = (string)listBoxPlanes.SelectedItem;

            Search(commandPlane, flightNumbersList);

        }
        private void Search(string commandPlane, List<Aeroflot> aeroflotList)
        {
            IOrderedEnumerable<Aeroflot>? sortedList = aeroflotList.Where(a => a.aircraftType == commandPlane).OrderBy(a => a.destination);
            List<Aeroflot> listResult = new List<Aeroflot>();
            if (sortedList.Any())
            {
                listResult = sortedList.ToList();
                listBox1.DataSource = listResult;
                listBox1.DisplayMember = "{destination} - {flightNumber} - {aircraftType}";
                
            }
            else
            {
                MessageBox.Show($"{commandPlane} не совершает рейсов");
            }
        }
        private void Files(string filePath, List<Aeroflot> aeroflotList)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (Aeroflot aeroflot in aeroflotList)
                {
                    writer.WriteLine($"Destination: {aeroflot.destination}, Flight Number: {aeroflot.flightNumber}, Aircraft Type: {aeroflot.aircraftType}");
                }
            }
        }
        private void FileRead(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                listBox2.Items.Add(line);
            }
        }

    }
}