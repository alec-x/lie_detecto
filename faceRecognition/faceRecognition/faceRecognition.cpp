#include <opencv2/opencv.hpp>
#include <opencv2/face.hpp>

using namespace std;
using namespace cv;
using namespace cv::face;

int main(int argc,char** argv)
{
	// Load Face Detector
	CascadeClassifier faceDetector("haarcascade_frontalface_alt2.xml");

	// Create an instance of Facemark
	Ptr<Facemark> facemark = FacemarkLBF::create();

	// Load landmark detector
	facemark->loadModel("lbfmodel.yaml");
    return 0;
}