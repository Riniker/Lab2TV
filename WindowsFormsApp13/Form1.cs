using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        int n = 0;
        double step = 0.5;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        public double RevF(double y)
        {
            return Math.Round(Math.Tan(-3.14/2+y*3.14)/ step) * step;
        }

        public double[] GetArray(int n)
        {
            double[] rands = new double[n];
            for (int i = 0; i < n; i++)
                rands[i] = rnd.NextDouble();
            return rands;
        }
 

        private void StartButton_Click(object sender, EventArgs e)
        {

            chart1.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            n = Convert.ToInt32(NNumericUpDown1.Value);
            double[] rands = new double[n];
            rands = GetArray(n);

            SortedDictionary<double, int> map = new SortedDictionary<double, int>();
            for (double i = -3; i <= 3; i += step)
                map.Add(i, 0);

            double[] xArray = new double[n];
            for (int i = 0; i < n; i++)
            {
                xArray[i] = RevF(rands[i]);
                if (xArray[i] >= -3 && xArray[i] <= 3)
                    map[xArray[i]]++;
            }

            
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = rands[i];
                dataGridView1.Rows[i].Cells[1].Value = xArray[i];
            }
            for (double i = -3; i <= 3; i += step)
            {
                chart1.Series[0].Points.AddXY(i, map[i]);
            }

        }


    }
}
