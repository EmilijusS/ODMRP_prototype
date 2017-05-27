using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Node
    {
        public const int VisibilityRange = 20;
        static int NodeNumbering = 1;
        protected int Address;
        Queue<Packet> Packets;
        public Coordinates Coordinates { get; private set; }
        public List<Node> NodesInRange { get; }
        Queue<int> PreviousPackets;
        List<TableEntry> RoutingTable;
        protected int SequenceNumber;

        public Node(Coordinates coordinates)
        {
            Coordinates = coordinates;

            NodesInRange = new List<Node>();
            Address = NodeNumbering++;
            Packets = new Queue<Packet>();
            PreviousPackets = new Queue<int>();
            RoutingTable = new List<TableEntry>();
            SequenceNumber = 0;
        }

        public void IncomingData(Packet packet)
        {
            Packets.Enqueue(packet);
        }

        protected List<Packet> SendPacket(Packet packet)
        {
            List<Packet> sentPackets = new List<Packet>();

            foreach(var n in NodesInRange)
            {
                Packet newPacket = PacketFactory.Clone(packet);
                newPacket.Target = n;
                newPacket.InitialCoordinates = Coordinates;
                newPacket.InitialTimeToTarget = (GetDistance(Coordinates, n.Coordinates) / Packet.Speed) + 1;
                sentPackets.Add(newPacket);
            }

            return sentPackets;
        }

        int GetDistance(Coordinates first, Coordinates second)
        {
            return (int)Math.Sqrt(Math.Pow((first.X - second.X), 2) + Math.Pow((first.Y - second.Y), 2));
        }

        public virtual List<Packet> Update()
        {
            List<Packet> sentPackets = new List<Packet>();

            foreach (var e in RoutingTable)
            {
                e.Update();
            }

            foreach(var p in Packets)
            {
                if(!PreviousPackets.Contains(p.SequenceNumber))
                {
                    List<Packet> newSentPackets = null;
                    PreviousPackets.Enqueue(p.SequenceNumber);

                    if (p is DataPacket)
                        newSentPackets = ProcessDataPacket((DataPacket)p);
                    else if (p is JoinRequestPacket)
                        newSentPackets = ProcessJoinRequestPacket((JoinRequestPacket)p);
                    else if (p is JoinReplyPacket)
                        newSentPackets = ProcessJoinReplyPacket((JoinReplyPacket)p);

                    if (newSentPackets != null)
                        sentPackets.AddRange(newSentPackets);
                }              
            }

            Packets.Clear();

            while(PreviousPackets.Count > 1000)
            {
                PreviousPackets.Dequeue();
            }

            return sentPackets;
        }

        protected virtual List<Packet> ProcessDataPacket(DataPacket packet)
        {
            if ((bool)RoutingTable.Find(x => x.MulticastGroup == packet.Destination)?.ForwardingGroup)
            {
                return SendPacket(packet);
            }
            else
                return null;            
        }

        protected virtual List<Packet> ProcessJoinRequestPacket(JoinRequestPacket packet)
        {
            var entry = RoutingTable.Find(x => x.MulticastGroup == packet.MulticastGroup);

            if (entry == null)
                RoutingTable.Add(new TableEntry(packet.MulticastGroup, packet.PreviousHop));
            else
                entry.NextHop = packet.PreviousHop;

            ++packet.HopCount;
            packet.PreviousHop = Address;

            if (--packet.TimeToLive > 0)
                return SendPacket(packet);
            else
                return null;
        }

        protected virtual List<Packet> ProcessJoinReplyPacket(JoinReplyPacket packet)
        {
            if(packet.NextHop == Address)
            {
                RoutingTable.Find(x => x.MulticastGroup == packet.MulticastGroup).ResetExpiration();
                packet.PreviousHop = Address;
                packet.NextHop = RoutingTable.Find(x => x.MulticastGroup == packet.MulticastGroup).NextHop;
                return SendPacket(packet);
            }
            else
            {
                return null;
            }
        }
    }
}
