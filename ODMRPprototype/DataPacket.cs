using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class DataPacket : Packet
    {
        public int Destination { get; set; }
        public int Sender { get; set; }
        public string Data { get; }

        public DataPacket(int sequenceNumber, int destination, int sender, string data) : base(sequenceNumber)
        {
            Destination = destination;
            Sender = sender;
            Data = data;
        }
    }
}
