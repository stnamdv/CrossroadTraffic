using CrossroadTraffic.Config;
using static CrossroadTraffic.Config.TrafficLights;

namespace CrossroadTraffic.Implement
{
    public interface IDirectTraffic
    {
        /// <summary>
        /// Direct traffic when traffic lights are green
        /// </summary>
        /// <param name="greenLight">The traffic lights are green</param>
        /// <param name="initParams">Declared param about total cars from N, S, W, E, time duration of traffic light,...</param>
        /// <param name="trafficParamsAfter">Handle total cars remaining after it crosses the crossroads</param>
        public void DirectTrafficByGreenLight(TrafficLightsEnum greenLight, TrafficParams initParams, ref TrafficParams trafficParamsAfter);
    }
}