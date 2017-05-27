using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class PacketFactory
    {
        public static Packet Clone(Packet packet)
        {
            if (packet is DataPacket)
                return CloneDataPacket((DataPacket)packet);

            if (packet is JoinRequestPacket)
                return CloneJoinRequestPacket((JoinRequestPacket)packet);

            if (packet is JoinReplyPacket)
                return CloneJoinReplyPacket((JoinReplyPacket)packet);

            throw new ArgumentException();
        }

        static DataPacket CloneDataPacket(DataPacket packet)
        {
            return new DataPacket(packet.SequenceNumber, packet.Destination, packet.Sender, packet.Data);
        }

        static JoinRequestPacket CloneJoinRequestPacket(JoinRequestPacket packet)
        {
            return new JoinRequestPacket(packet.SequenceNumber, packet.MulticastGroup, packet.Source, packet.PreviousHop, packet.TimeToLive, packet.HopCount);
        }

        static JoinReplyPacket CloneJoinReplyPacket(JoinReplyPacket packet)
        {
            return new JoinReplyPacket(packet.SequenceNumber, packet.MulticastGroup, packet.Source, packet.NextHop, packet.PreviousHop);
        }
    }
}
