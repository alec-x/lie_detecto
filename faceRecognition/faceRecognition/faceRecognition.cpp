#include <opencv2/opencv.hpp>
#include <opencv2/face.hpp>
#include <fstream>
#include <chrono>
//#include "drawLandmarks.hpp"

using namespace std;
using namespace cv;
using namespace cv::face;
using namespace chrono;

int main(int argc, char** argv)
{
	// output file
	remove("test.txt");
	ofstream outfile;
	outfile.open("test.txt", fstream::app);
	// Load Face Detector
	CascadeClassifier faceDetector("haarcascade_frontalface_alt2.xml");

	// Create an instance of Facemark
	Ptr<Facemark> facemark = FacemarkLBF::create();

	// Load landmark detector
	facemark->loadModel("lbfmodel.yaml");

	// Set up webcam for video capture
	VideoCapture cam(0);

	// Variable to store a video frame and its grayscale 
	Mat frame, gray;

	int sample = 1;
	// Read a frame
	auto cycle_start = steady_clock::now();
	long long unsigned int delay = 0;
	auto start = steady_clock::now();
	while (cam.read(frame) && sample <= 50)
	{
		cycle_start = steady_clock::now();
		// Find face
		vector<Rect> faces;
		// Convert frame to grayscale because
		// faceDetector requires grayscale image.
		cvtColor(frame, gray, COLOR_BGR2GRAY);

		// Detect faces
		faceDetector.detectMultiScale(gray, faces);

		// Variable for landmarks. 
		// Landmarks for one face is a vector of points
		// There can be more than one face in the image. Hence, we 
		// use a vector of vector of points. 
		vector< vector<Point2f> > landmarks;

		// Run landmark detector
		bool success = facemark->fit(frame, faces, landmarks);
		
		if (success)
		{
			try
			{
				outfile << sample << endl;
				for (int i = 17; i < landmarks[0].size(); i++)
				{
					outfile << landmarks[0][i].x << ", " << landmarks[0][i].y << endl;
				}

				sample++;
			}
			catch (const std::exception&)
			{
				cout << "error, no face detected" << endl;
			}

		}

		delay = duration_cast<chrono::milliseconds>(steady_clock::now() - cycle_start).count();

		while (delay < 200) {
			// tries to guarantee 5 samples/ sec
			delay = duration_cast<chrono::milliseconds>(steady_clock::now() - cycle_start).count();
		}
		delay = 0;
	}
	// rough benchmarking, data acquisition takes between 10.8 - 11.4 seconds
	return 0;
}