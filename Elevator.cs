using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51elevator
{
    public class Elevator
    {
        private bool[] floorReady;
        public int G = 1;
        public int S = 2;
        public int T1 = 3;
        private int T2 = 4;
        public ElevatorStatus Status = ElevatorStatus.STOPPED;

        public Elevator(int NumberOfFloors = 4)
        {
            floorReady = new bool[NumberOfFloors + 1];
            T2 = NumberOfFloors;
        }

        public void Stop(int floor)
        {
            Status = ElevatorStatus.STOPPED;
            G = floor;
            floorReady[floor] = false;
            Console.WriteLine("Stopped at floor {0}", floor);
        }

        public void Descend(int floor)
        {
            for (int i = G; i >= 1; i--)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }
        public void Ascend(int floor)
        {
            for (int i = G; i <= T2; i++)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        public void StayPut()
        {
            Console.WriteLine("That's our current floor");
        }

        public void FloorPress(int floor)
        {
            if (floor > T2)
            {
                Console.WriteLine("We only have {0} floors", T2);
                return;
            }

            floorReady[floor] = true;

            switch (Status)
            {

                case ElevatorStatus.DOWN:
                    Descend(floor);
                    break;

                case ElevatorStatus.STOPPED:
                    if (G < floor)
                        Ascend(floor);
                    else if (G == floor)
                        StayPut();
                    else
                        Descend(floor);
                    break;

                case ElevatorStatus.UP:
                    Ascend(floor);
                    break;

                default:
                    break;
            }

        }

        public enum ElevatorStatus
        {
            UP,
            STOPPED,
            DOWN
        }
    }
}
