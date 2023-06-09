﻿using System;
using System.Collections.Generic;

namespace HCP.ClinicalServices.DL.Entities
{
    public partial class GtEsspun
    {
        public int BusinessKey { get; set; }
        public int SpecialtyId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public int NoOfUnits { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
