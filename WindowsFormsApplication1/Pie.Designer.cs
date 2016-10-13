namespace WindowsFormsApplication1
{
    partial class Pie
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Turquoise;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart1.BackSecondaryColor = System.Drawing.Color.Silver;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.Yellow;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 54.99999F;
            chartArea1.InnerPlotPosition.Width = 52.16121F;
            chartArea1.InnerPlotPosition.X = 23.91939F;
            chartArea1.InnerPlotPosition.Y = 22.50001F;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowOffset = 1;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(25, 13);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.CustomProperties = "PieLineColor=Red, PieDrawingStyle=SoftEdge, CollectedLegendText=others, Collected" +
                "Color=Red, CollectedLabel=other, PieLabelStyle=Outside";
            series1.EmptyPointStyle.CustomProperties = "Exploded=True";
            series1.EmptyPointStyle.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.LegendToolTip = "Pcaket number of #LABEL  is #VAL.";
            series1.Name = "Series1";
            dataPoint1.AxisLabel = "";
            dataPoint1.CustomProperties = "PieLineColor=Red, PieLabelStyle=Outside";
            dataPoint1.IsValueShownAsLabel = true;
            dataPoint1.IsVisibleInLegend = true;
            dataPoint1.Label = "HTTP";
            dataPoint1.LabelAngle = 0;
            dataPoint1.LabelBackColor = System.Drawing.Color.Transparent;
            dataPoint1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            dataPoint1.LabelForeColor = System.Drawing.Color.Black;
            dataPoint1.LegendText = "HTTP";
            dataPoint1.MarkerBorderColor = System.Drawing.Color.Transparent;
            dataPoint1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.None;
            dataPoint2.AxisLabel = "SMTP";
            dataPoint2.Label = "SMTP";
            dataPoint2.LegendText = "SMTP";
            dataPoint3.AxisLabel = "POP3";
            dataPoint3.Label = "POP3";
            dataPoint3.LegendText = "POP3";
            dataPoint4.AxisLabel = "FTP";
            dataPoint4.IsVisibleInLegend = true;
            dataPoint4.Label = "FTP";
            dataPoint4.LegendText = "FTP";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.ShadowOffset = 1;
            series1.ToolTip = "Percent: #PERCENT";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(452, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "Title1";
            title1.Text = "应用层协议";
            title1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Stacked;
            this.chart1.Titles.Add(title1);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // Pie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart1);
            this.Name = "Pie";
            this.Size = new System.Drawing.Size(565, 392);
            this.Load += new System.EventHandler(this.Pie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
