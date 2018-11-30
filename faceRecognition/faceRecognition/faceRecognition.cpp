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
	unsigned int duration = 0;
	// Read a frame
	auto start = steady_clock::now();

	while (cam.read(frame) && sample <= 50)
	{

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
			outfile << sample << endl;
			for (int i = 0; i < landmarks.size(); i++)
			{
				outfile << landmarks[i];
			}

			outfile << endl << "endsample" << endl;
			outfile << endl;
			sample++;
		}

		auto end = steady_clock::now();
		duration = duration_cast<chrono::milliseconds>(end - start).count();
	}
	return 0;
}