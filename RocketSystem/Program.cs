using System;
using RocketSystemLibrary.Controller;
using RocketSystemLibrary.Models;

namespace RocketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World To Rocket Landing Control System!");

            var controller = new RocketLandingController();
            var rocketOneRequest = controller.CreateNewRequest(5 , 5);
            var rocketTwoRequest = controller.CreateNewRequest(5 , 5);
            var rocketThreeRequest = controller.CreateNewRequest(13 , 15);
            var coordination = new Coordination(6, 6);
            var rocketFourRequest = controller.ProcessRequestForLanding(coordination);
            Console.WriteLine($"Result Of  Request One {rocketOneRequest}");
            Console.WriteLine($"Result Of  Request Two {rocketTwoRequest}");
            Console.WriteLine($"Result Of  Request Four {rocketThreeRequest}");
            Console.WriteLine($"Result Of Using Coordination With Request Four {rocketFourRequest}");
        }
    }
}