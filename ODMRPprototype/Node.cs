using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Node
    {
        int Address;
        public const int VisibilityRange = 20;
        Queue<Packet> Packets;
        public Coordinates Coordinates { get; private set; }
        List<Node> NodesInRange;
        Queue<int> PreviousPackets;

        public void IncomingData(Packet packet)
        {
            Packets.Enqueue(packet);
        }

        void SendPacket(Packet packet)
        {
            foreach(var n in NodesInRange)
            {
                Packet newPacket = PacketFactory.Clone(packet);
                newPacket.Target = n;
                newPacket.InitialCoordinates = Coordinates;
                newPacket.InitialTimeToTarget = (GetDistance(Coordinates, n.Coordinates) / Packet.Speed) + 1;
            }
        }

        int GetDistance(Coordinates first, Coordinates second)
        {
            return (int)Math.Sqrt(Math.Pow((first.X - second.X), 2) + Math.Pow((first.Y - second.Y), 2));
        }

        void ProcessPackets()
        {
            foreach(var p in Packets)
            {
                if(!PreviousPackets.Contains(p.SequenceNumber))
                {
                    PreviousPackets.Enqueue(p.SequenceNumber);

                    if (p is DataPacket)
                        ProcessDataPacket((DataPacket)p);
                    if (p is JoinRequestPacket)
                        ProcessJoinRequestPacket((JoinRequestPacket)p);
                    if (p is JoinReplyPacket)
                        ProcessJoinReplyPacket((JoinReplyPacket)p);
                }              
            }

            Packets.Clear();

            while(PreviousPackets.Count > 100)
            {
                PreviousPackets.Dequeue();
            }
        }

        protected virtual void ProcessDataPacket(DataPacket packet)
        {
            SendPacket(packet);
        }

        protected virtual void ProcessJoinRequestPacket(JoinRequestPacket packet)
        {
            if(--packet.TimeToLive > 0)
            {
                ++packet.HopCount;
                packet.PreviousHop = Address;
            }
        }
    }
}
