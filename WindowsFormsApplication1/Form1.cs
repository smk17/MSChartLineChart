using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random random = new Random(0);
        ArrayList datalist = new ArrayList();
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(1, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            datalist.Add(random.Next(0, 100));
            chart1.Series[0].Points.AddXY(datalist.Count, datalist[datalist.Count-1]);
            //chart1.Series[0].Points.Clear();
            //for (int i = 0; i < datalist.Count; i++)
            //{
            //    chart1.Series[0].Points.AddXY(i + 1, datalist[i]);
            //}
            if (datalist.Count <= chart1.ChartAreas[0].AxisX.ScaleView.Size + 1)
                chart1.ChartAreas[0].AxisX.ScaleView.Position = 1;
            else
                chart1.ChartAreas[0].AxisX.ScaleView.Position = datalist.Count - chart1.ChartAreas[0].AxisX.ScaleView.Size - 1;
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(chart1.ChartAreas[0].AxisX.ScaleView.Size<=100)
                chart1.ChartAreas[0].AxisX.ScaleView.Size++;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].AxisX.ScaleView.Size >=6)
                chart1.ChartAreas[0].AxisX.ScaleView.Size--;
        }


        private System.Windows.Forms.TextBox CursorX;
        private System.Windows.Forms.TextBox CursorY;
        private void SetPosition(Axis axis, double position)
        {
            if (double.IsNaN(position))
                return;
            if (axis.AxisName == AxisName.X)
            {
                DateTime dateTimeX = DateTime.FromOADate(position);
                CursorX.Text = dateTimeX.ToLongDateString();
            }
            else
            {
                CursorY.Text = position.ToString();
            }
        }
        private void chart1_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            SetPosition(e.Axis, e.NewPosition);
        }

        private void realTimeTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Real_Time_Timer_From from = new Real_Time_Timer_From();
            from.Show();
        }

        private void realTimeThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Real_Timer_Thread_From tempFrom = new Real_Timer_Thread_From();
            tempFrom.Show();
        }

        private void pieFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PieForm tempFrom = new PieForm();
            tempFrom.Show();
        }
    }
}
