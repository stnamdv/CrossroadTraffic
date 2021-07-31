using System;
using System.Collections.Generic;
using System.Text;

namespace CrossroadTraffic.Config
{
    public class TrafficParams
    {
        public uint S1 { get; set; }//Leaving the crossroad takes each car S1 seconds 
        public uint X1 { get; set; }//The North and South lights show the green color
        public uint X2 { get; set; }//The West and East lights show the green color
        public uint A1 { get; set; }//total cars from north side
        public uint A2 { get; set; }//total cars from south side
        public uint A3 { get; set; }//total cars from west side
        public uint A4 { get; set; }//total cars from east side
    }
}
