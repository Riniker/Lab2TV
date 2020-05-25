using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        int n = 0, m = 0;
        static double q = 0, p = 0;      
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        public void GetPQ()
        {
            q = 1 - Convert.ToDouble(PNumericUpDown1.Value);
            p = Convert.ToDouble(PNumericUpDown1.Value);
        }

        public void GetChanceArray(double[] arr, double p, double q)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i > 0)
                {
                    arr[i] = p * Math.Pow(q, i) + arr[i - 1];
                }
                else arr[i] = p * Math.Pow(q, i);
            }
        }   

        private void StartButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            m = 0;
            n = Convert.ToInt32(NNumericUpDown1.Value);
            double[] rands = new double[n];
            GetPQ();
            rands = GetArray(n);
            double[] chances = new double[30];
            int[] xtry = new int[n];
            GetChanceArray(chances, p, q);
            int[] countArr = new int[30];
            for (int i = 0; i < n; i++)
            {
                int x = 1;
                if (rands[i] < q)
                {
                    while ( rands[i] < 1-chances[x])
                    {
                        x++;
                    }
                    x++;
                }
                countArr[x]++;
                xtry[i] = x;
            }
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = rands[i];
                dataGridView1.Rows[i].Cells[1].Value = xtry[i];
            }
            int j = 8;
            while (countArr[j] == 0)
            {
                j--;
            }
            for (int i = 1; i < j+1; i++)
            {
                chart1.Series[0].Points.AddXY(i,countArr[i]);
            }

        }

        public double[] GetArray(int n)
        {
            double[] rands = new double[n];
            for (int i = 0; i < n; i++)
                rands[i] = rnd.NextDouble();
            return rands;
        }
    }
}
