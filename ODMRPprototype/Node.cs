using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Node
    {
        protected int Address;
        public const int VisibilityRange = 20;
        Queue<Packet> Packets;
        public Coordinates Coordinates { get; private set; }
        List<Node> NodesInRange;
        Queue<int> PreviousPackets;
        List<TableEntry> RoutingTable;
        protected int SequenceNumber = 0;

        public void IncomingData(Packet packet)
        {
            Packets.Enqueue(packet);
        }

        protected void SendPacket(Packet packet)
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

        public virtual void Update()
        {
            foreach(var e in RoutingTable)
            {
                e.Update();
            }

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

            while(PreviousPackets.Count > 1000)
            {
                PreviousPackets.Dequeue();
            }
        }

        protected virtual void ProcessDataPacket(DataPacket packet)
        {
            if((bool)RoutingTable.Find(x => x.MulticastGroup == packet.Destination)?.ForwardingGroup)
            {
                SendPacket(packet);
            }            
        }

        protected virtual void ProcessJoinRequestPacket(JoinRequestPacket packet)
        {
            var entry = RoutingTable.Find(x => x.MulticastGroup == packet.MulticastGroup);

            if (entry == null)
                RoutingTable.Add(new TableEntry(packet.MulticastGroup, packet.PreviousHop));
            else
                entry.NextHop = packet.PreviousHop;

            ++packet.HopCount;
            packet.PreviousHop = Address;

            if (--packet.TimeToLive > 0)
            {
                SendPacket(packet);
            }
        }

        protected virtual void ProcessJoinReplyPacket(JoinReplyPacket packet)
        {
            if(packet.NextHop == Address)
            {
                RoutingTable.Find(x => x.MulticastGroup == packet.MulticastGroup).ResetExpiration();
                packet.PreviousHop = Address;
                packet.NextHop = RoutingTable.Find(x => x.MulticastGroup == packet.MulticastGroup).NextHop;
                SendPacket(packet);
            }
        }
    }
}
