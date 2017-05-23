using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Edge
    {
        int Weight;
        Queue<Pair<Packet, int>> Packets;
        Node Destination;

        public Edge(int weight, Node destination)
        {
            this.Weight = weight;
            this.Destination = destination;
        }

        public void Send(Packet packet)
        {
            Packets.Enqueue(new Pair<Packet, int>(packet, Weight));
        }

        public void Update()
        {
            foreach(var p in Packets.ToList())
            {
                if(--p.Second == 0)
                {
                    Destination.IncomingData(Packets.Dequeue().First);
                }
            }
        }
    }
}
