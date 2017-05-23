using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class JoinReplyPacket : Packet
    {
        IPAddress MulticastGroup;
        int SequenceNumber;
        IPAddress Source;
        IPAddress NextHop;
    }
}
