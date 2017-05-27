using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Source : Node
    {
        const int JoinRequestInterval = 30;
        const int DataInterval = 10;
        const int JoinRequestTimeToLive = 20;
        static int MulticastGroupNumbering = 1000;
        int JoinRequestTimer;
        int DataTimer;
        int Data = 0;
        public int MulticastGroup { get; }

        public Source(Coordinates coordinates) : base(coordinates)
        {
            MulticastGroup = MulticastGroupNumbering++;
            JoinRequestTimer = 1;
            DataTimer = DataInterval;
        }

        public override List<Packet> Update()
        {
            base.Update();

            if(--JoinRequestTimer == 0)
            {
                JoinRequestTimer = JoinRequestInterval;
                return SendPacket(new JoinRequestPacket(Address * 10000 + SequenceNumber++, MulticastGroup, Address, Address, JoinRequestTimeToLive));   
            }
            else if(--DataTimer == 0)
            {
                DataTimer = DataInterval;
                return SendPacket(new DataPacket(Address * 10000 + SequenceNumber++, MulticastGroup, Address, Convert.ToString(Data++ % 10)));    
            }

            return new List<Packet>();
        }

        protected override List<Packet> ProcessDataPacket(DataPacket packet)
        {
            return null;
        }

        protected override List<Packet> ProcessJoinRequestPacket(JoinRequestPacket packet)
        {
            return null;
        }

        protected override List<Packet> ProcessJoinReplyPacket(JoinReplyPacket packet)
        {
            return null;
        }
    }
}
