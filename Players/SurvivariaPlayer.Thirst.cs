﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetThirstEffects()
        {
            ThirstLossRate = 1;
            MaximumThirst = 100;
        }

        public int ThirstLossRate { get; set; }
        public float CurrentThirst { get; set; }
        public float MaximumThirst { get; set; }
    }
}
