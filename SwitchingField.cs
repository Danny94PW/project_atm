﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkNode
{
    static class SwitchingField
    {
        public static void Switching(byte[] data)
        {
            Settings.networkoutput[0].Send(20001, data);
        }
    }
}
