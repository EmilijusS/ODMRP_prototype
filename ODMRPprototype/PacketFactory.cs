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
            return null;
        }

        static JoinRequestPacket CloneJoinRequestPacket(JoinRequestPacket packet)
        {
            return null;
        }

        static JoinRequestPacket CloneJoinReplyPacket(JoinReplyPacket packet)
        {
            return null;
        }
    }
}
