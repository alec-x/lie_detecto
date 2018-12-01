using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Statistics.Filters;
using System.IO;

namespace FinalProject
{
    
    public partial class Form1 : Form
    {
        double[,,,] allData = new double [10, 50, 51, 2];
        DataTable data = new DataTable("video_input");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadVideoData();

        }   
    }
}
