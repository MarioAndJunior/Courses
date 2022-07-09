// main.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "FractalCreator.h"
#include "RGB.h"

using namespace FractalImage;

int main()
{
    int const WIDTH = 800;
    int const HEIGHT = 600;
    const char* FILE_NAME = "image.bmp";

    FractalCreator creator(WIDTH, HEIGHT);

    cout << "Generating image..." << endl;

    creator.addRange(0.0, RGB(0, 0, 255));
    creator.addRange(0.05, RGB(255, 99, 71));
    creator.addRange(0.08, RGB(255, 215, 0));
    creator.addRange(1.0, RGB(255, 255, 255));
    //creator.addZoom(Zoom(295, 202, 0.1));
    //creator.addZoom(Zoom(312, 304, 0.1));

    creator.run(FILE_NAME);


    cout << "Finished! Check the " << FILE_NAME << " file" << endl;
    int number = getchar();

    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file


//int const WIDTH = 800;
//int const HEIGHT = 600;
//const char* FILE_NAME = "image.bmp";
//
//FractalCreator(WIDTH, HEIGHT);
//
//Bitmap bitmap(WIDTH, HEIGHT);
//
//ZoomList zoomList(WIDTH, HEIGHT);
//
//zoomList.add(Zoom(WIDTH / 2, HEIGHT / 2, 4.0 / WIDTH));
//zoomList.add(Zoom(295, HEIGHT - 202, 0.1));
//zoomList.add(Zoom(312, HEIGHT - 304, 0.1));
//
//unique_ptr<int[]> histogram = make_unique<int[]>(Mandelbrot::MAX_ITERATIONS);
//unique_ptr<int[]> fractal = make_unique<int[]>(WIDTH * HEIGHT);
//
//cout << "Generating image..." << endl;
//
////bitmap.setPixel(WIDTH/2, HEIGHT/2, 255, 255, 255);
//for (int y = 0; y < HEIGHT; y++)
//{
//    for (int x = 0; x < WIDTH; x++)
//    {
//        //double xFractal = (x - WIDTH / 2.0 - 200) * 2.0 / HEIGHT;
//        //double yFractal = (y - HEIGHT / 2.0) * 2.0 / HEIGHT;
//
//        pair<double, double> coords = zoomList.doZoom(x, y);
//
//        int iterations = Mandelbrot::getIterations(coords.first, coords.second);
//
//        fractal[y * WIDTH + x] = iterations;
//
//        if (iterations != Mandelbrot::MAX_ITERATIONS)
//        {
//            histogram[iterations]++;
//        }
//    }
//}
//
//int total{ 0 };
//for (int i = 0; i < Mandelbrot::MAX_ITERATIONS; i++)
//{
//    total += histogram[i];
//}
//
//for (int y = 0; y < HEIGHT; y++)
//{
//    for (int x = 0; x < WIDTH; x++)
//    {
//        uint8_t red{ 0 };
//        uint8_t green{ 0 };
//        uint8_t blue{ 0 };
//
//        int iterations = fractal[y * WIDTH + x];
//
//        if (iterations != Mandelbrot::MAX_ITERATIONS)
//        {
//            double hue{ 0.0 };
//            for (int i = 0; i <= iterations; i++)
//            {
//                hue += ((double)histogram[i]) / total;
//            }
//
//            //green = pow(255, hue);
//            green = hue * 255;
//
//            bitmap.setPixel(x, y, red, green, blue);
//        }
//    }
//}
//
//cout << endl;
//
//int count = 0;
//for (int i = 0; i < Mandelbrot::MAX_ITERATIONS; i++)
//{
//    cout << histogram[i] << " " << flush;
//    count += histogram[i];
//}
//
//cout << count << "; " << WIDTH * HEIGHT << endl;
//
//bitmap.write(FILE_NAME);
//
//cout << "Finished! Check the " << FILE_NAME << " file" << endl;
//int number = getchar();
//
//return 0;