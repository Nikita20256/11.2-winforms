namespace _11._2
{
    public partial class Form1 : Form
    {
        class Marsh
        {
            public string StartDestination { get; set; }
            public string EndDestination { get; set; }
            public int RouteNumber { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Marsh[] marshArray = new Marsh[10];
            for (int i = 0; i < marshArray.Length; i++)
            {
                string start = "Start" + (i + 1);
                string end = "End" + (i + 1);
                marshArray[i] = new Marsh { StartDestination = start, EndDestination = end, RouteNumber = i + 1 };
            }

            using (StreamWriter file = new StreamWriter("data.txt"))
            {
                foreach (var marsh in marshArray)
                {
                    file.WriteLine($"{marsh.StartDestination},{marsh.EndDestination},{marsh.RouteNumber}");
                }
            }



        }

        private void GenerateAndSaveButton_Click(object sender, EventArgs e)
        {
            // Генерация из 10 элементов типа Marsh
            Marsh[] marshArray = new Marsh[10];
            for (int i = 0; i < 10; i++)
            {
                marshArray[i] = new Marsh
                {
                    StartDestination = "Start" + i,
                    EndDestination = "End" + i,
                    RouteNumber = i
                };



            }
        }
    }
}