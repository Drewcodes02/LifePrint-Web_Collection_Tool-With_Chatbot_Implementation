﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LifePrint
{
    public partial class Being
    {
        public Being()
        {
            Results = new HashSet<Results>();
        }

        public int BeingId { get; set; }
        public int? B1SlScore { get; set; }
        public int? B2SlScore { get; set; }
        public int? B3SlScore { get; set; }
        public int? B4EafeScore { get; set; }
        public int? B5AsdScore { get; set; }
        public int? B6TrScore { get; set; }
        public int? B7EafeScore { get; set; }
        public int? B8AsdScore { get; set; }
        public int? B9SaseScore { get; set; }
        public int? B10IrScore { get; set; }
        public int? B11SaseScore { get; set; }
        public int? B12AsdScore { get; set; }
        public int? B13AsdScore { get; set; }
        public int? B14AsdScore { get; set; }
        public int? B15IrScore { get; set; }
        public int? B16TrScore { get; set; }
        public int? B17SaseScore { get; set; }
        public int? B18TrScore { get; set; }
        public int? B19PcScore { get; set; }
        public int? B20SaScore { get; set; }
        public int? B21PcScore { get; set; }
        public int? B22SaScore { get; set; }
        public int? B23PcScore { get; set; }
        public int? B24SaScore { get; set; }
        public int? B25PcScore { get; set; }
        public int? B26SaScore { get; set; }
        public int? B27PcScore { get; set; }
        public int? B28SaScore { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}