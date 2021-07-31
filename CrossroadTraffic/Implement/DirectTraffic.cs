using CrossroadTraffic.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CrossroadTraffic.Config.TrafficLights;

namespace CrossroadTraffic.Implement
{
    public class DirectTraffic : IDirectTraffic
    {
        public void DirectTrafficByGreenLight(TrafficLightsEnum greenLight, TrafficParams initParams, ref TrafficParams trafficParamsAfter)
        {
            uint totalCarsInQueue, timeLeft;
            Queue<int> queueCars;
            trafficParamsAfter = initParams;
            switch (greenLight)
            {
                case TrafficLightsEnum.NORTH_SOUTH://X1
                    //car from north to south
                    totalCarsInQueue = initParams.X1 / initParams.S1;
                    timeLeft = initParams.X1 % initParams.S1;
                    if (totalCarsInQueue <= 0)
                    {
                        throw new Exception("The average time for cars to cross the crossroads must be less than the total time the light turns green.");
                    }
                    queueCars = new Queue<int>();
                    for (int i = 0; i < totalCarsInQueue; i++)
                    {
                        queueCars.Enqueue(i);
                        if (trafficParamsAfter.A1 > 0)
                        {
                            trafficParamsAfter.A1--;
                        }
                        if (trafficParamsAfter.A2 > 0)
                        {
                            trafficParamsAfter.A2--;
                        }
                    }
                    //first in first out
                    Console.WriteLine("From N to S & opposite");
                    RunCarQueue(queueCars, initParams.S1, timeLeft);
                    Console.WriteLine($"---------------A1 has {trafficParamsAfter.A1} cars left...");
                    Console.WriteLine($"---------------A2 has {trafficParamsAfter.A2} cars left...");

                    break;
                case TrafficLightsEnum.WEST_EAST://X2
                    //car from north to west
                    totalCarsInQueue = initParams.X2 / initParams.S1;
                    timeLeft = initParams.X1 % initParams.S1;
                    if (totalCarsInQueue <= 0)
                    {
                        throw new Exception("The average time for cars to cross the crossroads must be less than the total time the light turns green.");
                    }
                    queueCars = new Queue<int>();
                    for (int i = 0; i < totalCarsInQueue; i++)
                    {
                        queueCars.Enqueue(i);
                        if (trafficParamsAfter.A3 > 0)
                        {
                            trafficParamsAfter.A3--;
                        }
                        if (trafficParamsAfter.A4 > 0)
                        {
                            trafficParamsAfter.A4--;
                        }
                    }
                    //first in first out
                    Console.WriteLine("From W to E & opposite");
                    RunCarQueue(queueCars, initParams.S1, timeLeft);
                    Console.WriteLine($"---------------A3 has {trafficParamsAfter.A3} cars left...");
                    Console.WriteLine($"---------------A4 has {trafficParamsAfter.A4} cars left...");

                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Running car queue, calculation based on the average time (S1) of the car passing the crossroads
        /// </summary>
        /// <param name="queue">Total cars in queue based on the average time</param>
        /// <param name="S1">Average time of the car passing the crossroads</param>
        /// <param name="timeLeft">Residual time (due to insufficient time for the last car to pass the green light)</param>
        private void RunCarQueue(Queue<int> queue, uint S1, uint timeLeft)
        {
            while (queue.Count > 0)
            {
                Console.WriteLine($"Waiting {S1} seconds for the car can pass the crossroad...");
                Thread.Sleep((int)S1 * 1000);
                queue.Dequeue();
            }
            Thread.Sleep((int)timeLeft * 1000);
        }
    }
}
