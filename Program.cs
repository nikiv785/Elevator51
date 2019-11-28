using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51elevator
{
    class Program
    {
        private const string QUIT = "q";

        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("Welcome to area 51 ");
            Console.WriteLine("Choose a floor");

            int floor; string floorInput; Elevator elevator;

            floorInput = Console.ReadLine();

            if (Int32.TryParse(floorInput, out floor))
                elevator = new Elevator(floor);
            else
            {
                Console.WriteLine("Write a number");
                Thread.Sleep(1000);
                Console.Clear();
                goto Start;
            }
            string input = string.Empty;

            while (input != QUIT)
            {
                Console.WriteLine("Please press which floor you would like to go to");

                input = Console.ReadLine();
                if (Int32.TryParse(input, out floor))
                    elevator.FloorPress(floor);
                else if (input == QUIT)
                    Console.WriteLine("GoodBye!");
                else
                    Console.WriteLine("You have pressed an incorrect floor, Please try again");

            }
        }

    }
}