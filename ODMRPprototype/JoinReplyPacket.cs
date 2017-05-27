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
        public int MulticastGroup { get;}
        public int Source { get;}
        public int NextHop { get; set; }

        public JoinReplyPacket(int sequenceNumber, int multicastGroup, int source, int nextHop) : base(sequenceNumber)
        {
            MulticastGroup = multicastGroup;
            Source = source;
            NextHop = nextHop;
        }
    }
}
