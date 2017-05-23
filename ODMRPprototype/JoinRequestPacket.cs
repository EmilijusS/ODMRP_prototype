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
        int TimeToLive;
        int HopCount;
        IPAddress MulticastGroup;
        int SequenceNumber;
        IPAddress Source;
        IPAddress PreviousHop;
    }
}
