using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting.Utilities;

namespace WindowsFormsApplication1
{
    public partial class Pie : UserControl
    {
        public Pie()
        {
            InitializeComponent();
           
        }
        private delegate void addDataDele(int[] data);
       // private addDataDele addData_delegate;
        public void drawPie(int []data)
        {
            try
            {
                addDataDele addData_delegate = delegate(int[] Data)
                {
                    for (int i = 0; i < Data.Length; i++)
                        chart1.Series[0].Points[0].YValues[0] = (double)Data[i];
                    //chart1.Series[0].Points.AddXY(i + 1, data[i]);
                    chart1.Invalidate();
                };
                //addData_delegate = new addDataDele(addData);
                this.Invoke(addData_delegate, data);
            }
            catch(Exception e)
            {}
        }
        //private void addData(int[] data)
        //{
            
        //    for (int i = 0; i < data.Length; i++)
        //        chart1.Series[0].Points[0].YValues[0] = (double)data[i];
        //    //chart1.Series[0].Points.AddXY(i + 1, data[i]);
        //    chart1.Invalidate();
        //}
      //  PieCollectedDataHelper pieHelper;
        private void Pie_Load(object sender, EventArgs e)
        {
            
            //pieHelper = new PieCollectedDataHelper(chart1);
            //pieHelper.CollectedLabel = string.Empty;
            //// Set the percentage of the total series values. This value determines 
            //// if the data point value is a "small" value and should be shown as collected.
            //pieHelper.CollectedPercentage = 30;

            //// Indicates if small segments should be shown as one "collected" segment in 
            //// the original series.
            //pieHelper.ShowCollectedDataAsOneSlice = false;

            //// Size ratio between the original and supplemental chart areas.
            //// Value of 1.0f indicates that same area size will be used.
            //pieHelper.SupplementedAreaSizeRatio = 0.9f;

            //// Set position in relative coordinates ( 0,0 - top left corner; 100,100 - bottom right corner)
            //// where original and supplemental pie charts should be placed.
            //pieHelper.ChartAreaPosition = new RectangleF(3f, 3f, 93f, 96f);

            //// Show supplemental pie for the "Default" series
            //pieHelper.ShowSmallSegmentsAsSupplementalPie("Series1");
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            if (result.PointIndex < 0)
                return;
            // Check if data point is already exploded.
            bool exploded = (chart1.Series[0].Points[result.PointIndex].CustomProperties == "Exploded=true") ? true : false;

            // Remove all exploded attributes
            foreach (DataPoint point in chart1.Series[0].Points)
            {
                point.CustomProperties = "";
            }
            // If data point is already exploded get out.
            if (exploded)
                return;
            // If data point is selected
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // Set Attribute
                DataPoint point = chart1.Series[0].Points[result.PointIndex];
                point.CustomProperties = "Exploded = true";
            }
            // If legend item is selected
            if (result.ChartElementType == ChartElementType.LegendItem)
            {
                // Set Attribute
                DataPoint point = chart1.Series[0].Points[result.PointIndex];
                point.CustomProperties = "Exploded = true";
            }

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            foreach (DataPoint point in chart1.Series[0].Points)
            {// Reset Data Point Attributes
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }
            // If a Data Point or a Legend item is selected.
            if (result.ChartElementType == ChartElementType.DataPoint ||
                result.ChartElementType == ChartElementType.LegendItem)
            {
                this.Cursor = Cursors.Hand;
                DataPoint point = chart1.Series[0].Points[result.PointIndex];
                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.Percent25;
                point.BorderWidth = 2;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
