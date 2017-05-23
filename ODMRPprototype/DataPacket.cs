using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class DataPacket : Packet
    {
        IPAddress Destination;
        IPAddress Sender;
        int SequenceNumber;
        string Data;
    }
}
