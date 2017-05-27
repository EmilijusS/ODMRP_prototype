﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    public struct Coordinates
    {
        public int X { get; }
        public int Y { get; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
