using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class TableEntry
    {
        public const int StartExpiration = 20;
        public int MulticastGroup { get; set; }
        public int NextHop { get; set; }
        public int Expiration { get; set; }
        public bool ForwardingGroup
        {
            get
            {
                return Expiration > 0;
            }
        }

        public TableEntry(int multicastGroup, int nextHop)
        {
            MulticastGroup = multicastGroup;
            NextHop = nextHop;
        }

        public void Update()
        {
            if (Expiration > 0)
                --Expiration;
        }

        public void ResetExpiration()
        {
            Expiration = StartExpiration;
        }
    }
}
