﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LifePrint
{
    public partial class Health
    {
        public Health()
        {
            Results = new HashSet<Results>();
        }

        public int HealthId { get; set; }
        public int? H1GhHvsfScore { get; set; }
        public int? H2GhScore { get; set; }
        public int? H3GhScore { get; set; }
        public int? H4GhScore { get; set; }
        public int? H5GhScore { get; set; }
        public int? H6EfScore { get; set; }
        public int? H7EwScore { get; set; }
        public int? H8EwScore { get; set; }
        public int? H9EwScore { get; set; }
        public int? H10EfScore { get; set; }
        public int? H11EwScore { get; set; }
        public int? H12EfScore { get; set; }
        public int? H13EwScore { get; set; }
        public int? H14EfScore { get; set; }
        public int? H15GhScore { get; set; }
        public int? H16GhScore { get; set; }
        public int? H17GhScore { get; set; }
        public int? H18GhScore { get; set; }
        public int? HGhTotScore { get; set; }
        public int? HHvsfTotScore { get; set; }
        public int? HEfTotScore { get; set; }
        public int? HEwTotScore { get; set; }
        public double? HPercent2dpScore { get; set; }
        public double? HGhPercent2dpScore { get; set; }
        public double? HHvsfPercent2dpScore { get; set; }
        public double? HEfPercent2dpScore { get; set; }
        public double? HEwPercent2dpScore { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}