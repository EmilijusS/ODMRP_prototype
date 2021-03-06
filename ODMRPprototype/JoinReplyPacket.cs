﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    public class JoinReplyPacket : Packet
    {
        public int MulticastGroup { get;}
        public int Source { get;}
        public int NextHop { get; set; }
        public int PreviousHop { get; set; }

        public JoinReplyPacket(int sequenceNumber, int multicastGroup, int source, int nextHop, int previousHop) : base(sequenceNumber)
        {
            MulticastGroup = multicastGroup;
            Source = source;
            NextHop = nextHop;
            PreviousHop = previousHop;
        }
    }
}
