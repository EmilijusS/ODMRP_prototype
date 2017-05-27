using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Receiver : Node
    {
        string Data;
        public int SubscribedGroup { get; }

        public Receiver(Coordinates coordinates, List<Node> nodesInRange, int multicastGroup) : base(coordinates, nodesInRange)
        {
            SubscribedGroup = multicastGroup;
        }

        protected override void ProcessDataPacket(DataPacket packet)
        {
            if (packet.Destination == SubscribedGroup)
                Data += packet.Data;
        }

        protected override void ProcessJoinRequestPacket(JoinRequestPacket packet)
        {
            if(packet.MulticastGroup == SubscribedGroup)
            {
                JoinReplyPacket newPacket = new JoinReplyPacket(Address * 10000 + SequenceNumber++, SubscribedGroup, packet.Source, packet.PreviousHop, Address);
                SendPacket(newPacket);
            }
        }

        protected override void ProcessJoinReplyPacket(JoinReplyPacket packet)
        {
            return;
        }
    }
}
