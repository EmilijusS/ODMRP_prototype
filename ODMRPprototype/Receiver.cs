using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Receiver : Node
    {
        public string Data { get; private set; }
        public int SubscribedGroup { get; }

        public Receiver(Coordinates coordinates, int multicastGroup) : base(coordinates)
        {
            SubscribedGroup = multicastGroup;
        }

        protected override List<Packet> ProcessDataPacket(DataPacket packet)
        {
            if (packet.Destination == SubscribedGroup)
                Data += packet.Data;

            return null;
        }

        protected override List<Packet> ProcessJoinRequestPacket(JoinRequestPacket packet)
        {
            if (packet.MulticastGroup == SubscribedGroup)
            {
                JoinReplyPacket newPacket = new JoinReplyPacket(Address * 10000 + SequenceNumber++, SubscribedGroup, packet.Source, packet.PreviousHop, Address);
                return SendPacket(newPacket);
            }
            else
                return null;
        }

        protected override List<Packet> ProcessJoinReplyPacket(JoinReplyPacket packet)
        {
            return null;
        }
    }
}
