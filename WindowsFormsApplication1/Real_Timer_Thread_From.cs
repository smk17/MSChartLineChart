using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
namespace WindowsFormsApplication1
{
    public partial class Real_Timer_Thread_From : Form
    {
        public Real_Timer_Thread_From()
        {
            InitializeComponent();
        }
        // Chart data adding thread
        private Thread addData_thread;

        // Thread Add Data delegate
        public delegate void AddDataDelegate();

        private DateTime minValue, maxValue;
        private Random rand = new Random();
        public AddDataDelegate addData_delegate;

        private void Real_Timer_Thread_From_Load(object sender, EventArgs e)
        {
            addData_thread = new Thread(new ThreadStart(AddDataThreadLoop));
            addData_delegate = new AddDataDelegate(AddData);
            this.startTrending_Click(null, EventArgs.Empty);
        }

        private void AddDataThreadLoop()
        {
            try
            {
                while (true)
                {
                    // Invoke method must be used to interact with the chart
                    // control on the form!
                    chart1.Invoke(addData_delegate);

                    // Thread is inactive for 200ms
                    Thread.Sleep(200);
                }
            }
            catch
            {
                // Thread is aborted
            }
        }
        public void AddData()
        {
            DateTime timeStamp = DateTime.Now;

            foreach (Series ptSeries in chart1.Series)
            {
                AddNewPoint(timeStamp, ptSeries);
            }
        }
        public void AddNewPoint(DateTime timeStamp,Series ptSeries)
        {
            
            // Add new data point to its series.
            ptSeries.Points.AddXY(timeStamp.ToOADate(),rand.Next(10, 20));

            // remove all points from the source series older than 20 seconds.
            double removeBefore = timeStamp.AddSeconds((double)(20) * (-1)).ToOADate();

            //remove oldest values to maintain a constant number of data points
            while (ptSeries.Points[0].XValue < removeBefore)
            {
                ptSeries.Points.RemoveAt(0);
            }

            chart1.ChartAreas[0].AxisX.Minimum = ptSeries.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddSeconds(30).ToOADate();

            chart1.Invalidate();
        }

        private void startTrending_Click(object sender, EventArgs e)
        {
            // Disable all controls on the form
            startTrending.Enabled = false;
            // Disable all controls on the form
            stopTrending.Enabled = true;

            // Predefine the viewing area of the chart
            minValue = DateTime.Now;
            maxValue = minValue.AddSeconds(30);
            chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();

            // Reset number of series in the chart.
            chart1.Series.Clear();
            Series newSeries = new Series("Series1");
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.BorderWidth = 1;
            newSeries.Color = Color.FromArgb(224, 64, 10);
            newSeries.ShadowOffset = 1;
            newSeries.XValueType = ChartValueType.DateTime;
            chart1.Series.Add(newSeries);

            // start worker threads.
            if (addData_thread.IsAlive == true)
            {
                addData_thread.Resume();
            }
            else
            {
                addData_thread.Start();
            }
        }

        private void stopTrending_Click(object sender, EventArgs e)
        {
            // Suspend thread
            if (addData_thread.IsAlive == true)
            {
                addData_thread.Suspend();
            }

            // Enable all controls on the form
            startTrending.Enabled = true;

            // Disable the Stop button
            stopTrending.Enabled = false;
            
        }

        bool flagStart = true;
        bool flagEnd = true;
        double start_position = 0;
        double end_position = 0;
        private void chart1_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            SetPosition(e.Axis, e.NewPosition);

            flagEnd = true;
            SetPosition(e.Axis, e.NewPosition, ref flagEnd, 1);
            flagStart = true;
        }
        private void chart1_CursorPositionChanging(object sender, CursorEventArgs e)
        {
            SetPosition(e.Axis, e.NewPosition, ref flagStart, 0);
        }
        private void SetPosition(Axis axis, double position, ref bool flag, int index)
        {
            if (double.IsNaN(position))
                return;
            if ((!flag && index == 0) || (flag == true && index == 1))
            {
                chart1.ChartAreas[0].AxisX.StripLines[0].BorderColor = Color.Blue;
                end_position = position;
                if (start_position == end_position)
                {
                    chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = 0;
                    chart1.ChartAreas[0].AxisX.StripLines[0].StripWidth = 0;
                    return;
                }
                if (end_position - start_position > 0)
                {
                    chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = start_position;
                    chart1.ChartAreas[0].AxisX.StripLines[0].StripWidth = end_position - start_position;
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset = end_position;
                    chart1.ChartAreas[0].AxisX.StripLines[0].StripWidth = start_position - end_position;
                }
                return;
            }
            flag = false;
            start_position = position;
            if (axis.AxisName == AxisName.X)
            {
                chart1.ChartAreas[0].AxisX.StripLines[0].IntervalOffset =0;
                chart1.ChartAreas[0].AxisX.StripLines[0].StripWidth = 0;  
            }
        }
        private void SetPosition(Axis axis, double position)
        {
            if (double.IsNaN(position))
                return;
       
            if (axis.AxisName == AxisName.X)
            {
                // Convert Double to DateTime.
                DateTime dateTimeX = DateTime.FromOADate(position);
                // Set X cursor position to edit Control
                //Console.WriteLine("X="+dateTimeX.ToShortTimeString());
                Console.WriteLine("X=" + dateTimeX.ToLongTimeString());
                label2.Text = dateTimeX.ToLongTimeString();
            }
            else
            {
                // Set Y cursor position to edit Control
               Console.WriteLine( "Y="+position.ToString());
            }
        }
    }
}
