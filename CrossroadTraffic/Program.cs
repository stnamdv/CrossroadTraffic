using CrossroadTraffic.Config;
using CrossroadTraffic.Implement;
using System;
using System.Threading;
using static CrossroadTraffic.Config.TrafficLights;

namespace CrossroadTraffic
{
    class Program
    {
        //public IDirectTraffic directTraffic = new DirectTraffic();
        static void Main(string[] args)
        {
            try
            {
                IDirectTraffic directTraffic = new DirectTraffic();
                TrafficParams initParams = new TrafficParams();
                initParams.S1 = 1;//Leaving the crossroad takes each car S1 seconds 
                initParams.X1 = 4;//NS
                initParams.X2 = 8;//WE

                initParams.A1 = 12;//N
                initParams.A2 = 8;//S
                initParams.A3 = 3;//W
                initParams.A4 = 9;//E

                while (initParams.A1 > 0 || initParams.A2 > 0 || initParams.A3 > 0 || initParams.A4 > 0)
                {
                    directTraffic.DirectTrafficByGreenLight(TrafficLightsEnum.NORTH_SOUTH, initParams, ref initParams);
                    directTraffic.DirectTrafficByGreenLight(TrafficLightsEnum.WEST_EAST, initParams, ref initParams);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
