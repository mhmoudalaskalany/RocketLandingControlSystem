using System;
using RocketSystemLibrary.Controller;

namespace RocketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World To Rocket Landing Control System!");

            var request = new RocketLandingController();

            var rocketOneRequest = request.CreateNewRequest(5 , 5);
            var rocketTwoRequest = request.CreateNewRequest(5 , 5);
            var rocketThreeRequest = request.CreateNewRequest(13 , 15);
            Console.WriteLine(rocketOneRequest);
            Console.WriteLine(rocketTwoRequest);
            Console.WriteLine(rocketThreeRequest);
        }
    }
}