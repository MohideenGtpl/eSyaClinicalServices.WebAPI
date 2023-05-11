﻿using System;
using System.Collections.Generic;

namespace HCP.ClinicalServices.DL.Entities
{
    public partial class GtEsdodx
    {
        public int DoctorId { get; set; }
        public string DoxyMeUrl { get; set; }
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