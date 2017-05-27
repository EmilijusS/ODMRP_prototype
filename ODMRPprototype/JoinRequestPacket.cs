using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class JoinRequestPacket : Packet
    {
        public int MulticastGroup { get; set; }
        public int Source { get; set; }
        public int PreviousHop { get; set; }
        public int TimeToLive { get; set; }
        public int HopCount { get; set; }

        public JoinRequestPacket(int sequenceNumber, int multicastGroup, int source, int previousHop, int timeToLive) : base(sequenceNumber)
        {
            MulticastGroup = multicastGroup;
            Source = source;
            PreviousHop = previousHop;
            TimeToLive = timeToLive;
            HopCount = 0;
        }
    }
}
