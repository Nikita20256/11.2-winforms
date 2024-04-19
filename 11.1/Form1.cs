using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._1
{
    interface Iformuls
    {
        void sumWithLoop(int n);
        void sumWithFormula(int n);
    }
    public partial class Form1 : Form, Iformuls
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        public void sumWithLoop(int n)
        {
            
            int sumWithLoop = 0;
            for (int i = 1; i <= n; i++)
            {
                sumWithLoop += 3 * i - 2;
            }
            textBox1.Text = sumWithLoop.ToString();
        }
        public void sumWithFormula(int n)
        {
            int sumWithFormula = n * (3 * n - 1) / 2;
            textBox2.Text = sumWithFormula.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;
            sumWithLoop(n);
            sumWithFormula(n);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            numericUpDown1.Value = hScrollBar1.Value;
        }
    }
}
