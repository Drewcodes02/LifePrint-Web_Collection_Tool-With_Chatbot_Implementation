﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LifePrint
{
    public partial class Wealth
    {
        public Wealth()
        {
            Results = new HashSet<Results>();
        }

        public int WealthId { get; set; }
        public int? W1WsCwpScore { get; set; }
        public int? W2WsCwpScore { get; set; }
        public int? W3WsCwpScore { get; set; }
        public int? W4WsCwpScore { get; set; }
        public int? W5CwlScore { get; set; }
        public int? W6CwlScore { get; set; }
        public int? W7CwlScore { get; set; }
        public int? W8FwoCwpScore { get; set; }
        public int? W9FwoCwpScore { get; set; }
        public int? W10FwoCwpScore { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}