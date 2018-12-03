using System;
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
        void CallFaceRecognition(string arg)
        {
            var process = new Process();
            process.StartInfo.FileName = "faceRecognition.exe";
            process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = arg;

            process.Start();

            process.WaitForExit();
            process.Close();
        }

        void ExtractHeartData(string arg)
        {
            stopWatch.Stop();
            stopWatch.Reset();
            stopWatch.Start();
            while (stopWatch.ElapsedMilliseconds < 4000) ;
            connectSerial();
            while (stopWatch.ElapsedMilliseconds < 11000) ;
            serialPort.Close();
            writeHeartOutput(arg);

        }

        void connectSerial()
        {
            try
            {
                string serialName = System.IO.Ports.SerialPort.GetPortNames().First();
                serialPort.BaudRate = 4800;
                serialPort.PortName = serialName;
                serialPort.Open();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Could not connect to COM port");
                Console.WriteLine(exception.Message);
            }
        }

        void ReadSerial()
        {
            int newByte;
            

            try
               {
                while (serialPort.BytesToRead != 0)
                {
                    newByte = serialPort.ReadByte();
                    dataBuffer.Enqueue(newByte);
                }
            }
            catch(Exception e)
                {

                }
            
        }

        void writeHeartOutput(string arg)
        {
            string seconds = Convert.ToString(DateTimeOffset.Now.ToUnixTimeSeconds());
            string fileName = "\\heartvector.txt";
            string dirPath = "";
            int i = 0;
            string currLine = "";
            if(arg == "l")
            {
                dirPath = System.IO.Directory.GetCurrentDirectory() + "\\trainingDataHeart";
                System.IO.Directory.CreateDirectory(dirPath);
                fileName = "\\heartlearning" + seconds + ".txt";
            }
            else {
                dirPath = Directory.GetCurrentDirectory();
            }
            

            int firstByte = 0;
            int heartByte1 = 0;
            int heartByte2 = 0;
            int heartInt = 0;
            List<int> heartSignals = new List<int>();
         

            // dequeue each pair of bytes into an int
            while(dataBuffer.Count >= 2)
            {
                // make sure we start with header byte
                while (firstByte != 255 && dataBuffer.Count >=1)
                {
                    dataBuffer.TryDequeue(out firstByte);
                }

                if(dataBuffer.Count >= 2)
                {
                    dataBuffer.TryDequeue(out heartByte1);
                    dataBuffer.TryDequeue(out heartByte2);
                }

                
                heartInt = (heartByte1 << 8) + heartByte2;
                heartSignals.Add(heartInt);
                firstByte = 0;
            }
            
            // throw away the rest of the buffer
            while(dataBuffer.IsEmpty == false)
            {
                dataBuffer.TryDequeue(out heartByte1);
            }

            // use C# streamwriter to write to text file
            using (System.IO.StreamWriter heartfile =
                   new System.IO.StreamWriter(dirPath + fileName))
            {
                heartfile.WriteLine("time,heartValue");
                foreach (var dataPoint in heartSignals)
                {
                    currLine = Convert.ToString(i) + ", " + Convert.ToString(dataPoint);
                    heartfile.WriteLine(currLine);
                    i++;
                }
            }


        }

        void lieDetection()
        {
            string pythonPath = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64\python.exe";
            string lieDetectorPath = "DetectLies.py";
            ProcessStartInfo detectorStartInfo = new ProcessStartInfo(pythonPath);
            detectorStartInfo.UseShellExecute = false;
            detectorStartInfo.RedirectStandardOutput = true;
            detectorStartInfo.Arguments = lieDetectorPath;
            detectorStartInfo.CreateNoWindow = true;

            Process detectionProcess = new Process();
            detectionProcess.StartInfo = detectorStartInfo;
            detectionProcess.Start();

            StreamReader resultReader = detectionProcess.StandardOutput;
            faceResult = resultReader.ReadLine();
            heartResult = resultReader.ReadLine();

            detectionProcess.WaitForExit();
            detectionProcess.Close();
        }

        void plotHeart()
        {
            UInt32 timeVar = 0;
            UInt32 valVar = 0;
            int lines = 0;
            using (var heartFile = new StreamReader("heartvector.txt"))
            {
                // get rid of headers
                heartFile.ReadLine();
                while (!heartFile.EndOfStream && lines < 1000)
                {
                    string[] splits = heartFile.ReadLine().Split(',');
                    
                    timeVar = Convert.ToUInt32(splits[0]);
                    valVar  = Convert.ToUInt32(splits[1]);

                    if(valVar >= 1000)
                    {
                        valVar = 0;
                    }
                    heartTime.Add(timeVar);
                    heartValue.Add(valVar);
                    lines++;
                }
            }

            chart1.Series[0].Points.DataBindXY(heartTime, heartValue);

        }
    }
}
