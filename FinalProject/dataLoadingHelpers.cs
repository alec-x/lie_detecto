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
        void loadVideoData()
        {
            string[] coords, frames, xy;
            string temp, contents;
            int sampleNum = 0;
            int frameNum = 0;
            int coordNum = 0;

            foreach (var file in Directory.EnumerateFiles("trainingData\\", "*.txt"))
            {
                contents = File.ReadAllText(file);
                frames = contents.Split(';').Skip(1).ToArray();
                foreach (var frame in frames)
                {
                    temp = frame.Replace('\n'.ToString(), "");
                    coords = temp.Split('\r').Skip(1).ToArray().Reverse().Skip(1).Reverse().ToArray();

                    foreach (var coord in coords)
                    {
                        xy = coord.Split(',');
                        allData[sampleNum, frameNum, coordNum, 0] = Convert.ToDouble(xy[0]);
                        allData[sampleNum, frameNum, coordNum, 1] = Convert.ToDouble(xy[1]);
                        coordNum++;

                    }
                    coordNum = 0;
                    frameNum++;
                }
                frameNum = 0;
                sampleNum++;

            }
        }

        void createDataTable()
        {

        }
    }
}
