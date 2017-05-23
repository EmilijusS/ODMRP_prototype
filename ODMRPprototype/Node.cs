using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Node
    {
        Queue<Packet> Packets;

        public void IncomingData(Packet packet)
        {
            Packets.Enqueue(packet);
        }
    }
}
