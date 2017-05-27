using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Source : Node
    {
        const int JoinRequestInterval = 10;
        const int DataInterval = 3;
        const int JoinRequestTimeToLive = 20;
        int JoinRequestTimer;
        int DataTimer;
        int Data = 0;
        int MulticastGroup;

        public override void Update()
        {
            base.Update();

            if(--JoinRequestTimer == 0)
            {
                SendPacket(new JoinRequestPacket(Address * 10000 + SequenceNumber++, MulticastGroup, Address, Address, JoinRequestTimeToLive));
                JoinRequestTimer = JoinRequestInterval;
            }
            else if(--DataTimer == 0)
            {
                SendPacket(new DataPacket(Address * 10000 + SequenceNumber++, MulticastGroup, Address, Convert.ToString(Data++ % 10)));
                DataTimer = DataInterval;
            }
        }

        protected override void ProcessDataPacket(DataPacket packet)
        {
            return;
        }

        protected override void ProcessJoinRequestPacket(JoinRequestPacket packet)
        {
            return;
        }

        protected override void ProcessJoinReplyPacket(JoinReplyPacket packet)
        {
            return;
        }
    }
}
