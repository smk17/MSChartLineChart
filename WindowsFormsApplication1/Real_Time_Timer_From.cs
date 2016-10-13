using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace WindowsFormsApplication1
{
    public partial class Real_Time_Timer_From : Form
    {
        public Real_Time_Timer_From()
        {
            InitializeComponent();
        }
        private Random random = new Random();
        private int pointIndex = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int numberOfPointsInChart = int.Parse(comboBoxVisiblePoints.Text);
            int numberOfPointsAfterRemoval = numberOfPointsInChart - int.Parse(comboBoxPointsRemoved.Text);
            int numAddedMin = 5;
            int numAddedMax = 10;
            for (int pointNumber = 0; pointNumber < random.Next(numAddedMin, numAddedMax); pointNumber++)
            {
                chart1.Series[0].Points.AddXY(pointIndex + 1, random.Next(1000, 5000));
                ++pointIndex;
            }

            // Adjust Y & X axis scale
            chart1.ResetAutoValues();
            if (chart1.ChartAreas[0].AxisX.Maximum < pointIndex)
            {
                chart1.ChartAreas[0].AxisX.Maximum = pointIndex;
            }
            // Keep a constant number of points by removing them from the left
            while (chart1.Series[0].Points.Count > numberOfPointsInChart)
            {
                // Remove data points on the left side
                while (chart1.Series[0].Points.Count > numberOfPointsAfterRemoval)
                    chart1.Series[0].Points.RemoveAt(0);
                // Adjust X axis scale
                chart1.ChartAreas[0].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
                chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Minimum + numberOfPointsInChart;
            }
            // Redraw chart
            chart1.Invalidate();
        }

        private void comboBoxUpdateInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(comboBoxUpdateInterval.Text);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                this.timer1.Enabled = false;
                buttonStart.Text = "&Start Real Time Data";
            }
            else
            {
                this.timer1.Enabled = true;
                buttonStart.Text = "&Stop Real Time Data";
            }
        }

        private void Real_Time_Timer_From_Load(object sender, EventArgs e)
        {
            comboBoxUpdateInterval.SelectedIndex = 2;
            comboBoxVisiblePoints.SelectedIndex = 2;
            comboBoxPointsRemoved.SelectedIndex = 0;
            chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset= 0;
            chart1.ChartAreas[0].AxisX.StripLines[1].IntervalOffset = 0;
        }

        bool flagStart = true;
        bool flagEnd = true;
        double start_position = 0;
        double end_position = 0;
        private void chart1_CursorPositionChanging(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            SetPosition(e.Axis, e.NewPosition,ref flagStart,0);
            Console.WriteLine(e.NewPosition.ToString() + "start");
        }

        private void chart1_CursorPositionChanged(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            flagEnd = true;
            end_position = e.NewPosition;
            SetPosition(e.Axis, e.NewPosition,ref flagEnd,1);
            Console.WriteLine(e.NewPosition.ToString() + "end");
            flagStart = true;
        }
        private void SetPosition(Axis axis, double position, ref bool flag,int index)
        {
            if (double.IsNaN(position))
                return;
            if ((!flag&&index==0)||(flag==true&&index==1))
            {
                end_position = position;
                if (start_position == end_position)
                {
                    chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = 0;
                    chart1.ChartAreas[0].AxisX.StripLines[1].IntervalOffset = 0;
                    return;
                }
                chart1.ChartAreas[0].AxisX.StripLines[1].IntervalOffset = position;
                return;
            }
            flag = false;
            //if(index==0)
            start_position = position;
            if (axis.AxisName == AxisName.X)
            {
                chart1.ChartAreas[0].AxisX.StripLines[index].IntervalOffset = position;
                chart1.ChartAreas[0].AxisX.StripLines[1].IntervalOffset = 0;
            }
        }

    }
}
