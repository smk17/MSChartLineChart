using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class PieForm : Form
    {
        public PieForm()
        {
            InitializeComponent();
        }
        Random random = new Random(1);
        int []data=new int[]{0,0,0,0};
        private delegate void addDataDele(int []data);
        private addDataDele addData_delegate;
        Thread addDate_thread;
        private void PieForm_Load(object sender, EventArgs e)
        {
           // ParameterizedThreadStart temp=new ParameterizedThreadStart(addDate);
            ThreadStart temp=new ThreadStart(addDate);
            addDate_thread=new Thread(temp);
            //addData_delegate = new addDataDele(addDate);
            addDate_thread.Start();
        }
        private void addDate()
        {
            while (true)
            {
                for (int i = 0; i < data.Length; i++)
                    data[i] = random.Next(0, 20);
                pie1.drawPie(data);
                Thread.Sleep(500);
            }
        }

        private void PieForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            addDate_thread.Abort();
        }
    }
}
