﻿using System;
using System.Diagnostics;
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
using System.Collections.Concurrent;

namespace FinalProject
{
    
    public partial class Form1 : Form
    {
        ConcurrentQueue<int> dataBuffer = new ConcurrentQueue<int>();
        Stopwatch stopWatch;
        string faceResult;
        string heartResult;

        public Form1()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            statusTrainText.Text = "Collecting Data";
            statusTrainText.Update();
            Parallel.Invoke(
                () => CallFaceRecognition("a"),
                () => ExtractHeartData("a"));
            statusTrainText.Text = "Calculating";
            statusTrainText.Update();
            lieDetection();
            faceResultText.Text = faceResult;
            heartResultText.Text = heartResult;
            statusTrainText.Text = "Done";
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ReadSerial();
        }

        private void trainHeart_Click(object sender, EventArgs e)
        {
            ExtractHeartData("l");
        }

    }
}
