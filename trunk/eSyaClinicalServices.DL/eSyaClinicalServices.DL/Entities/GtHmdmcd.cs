﻿using System;
using System.Collections.Generic;

namespace HCP.ClinicalServices.DL.Entities
{
    public partial class GtHmdmcd
    {
        public GtHmdmcd()
        {
            GtHmdmlc = new HashSet<GtHmdmlc>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorShortName { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string DoctorRegnNo { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public int DoctorClass { get; set; }
        public int DoctorCategory { get; set; }
        public bool AllowConsultation { get; set; }
        public bool IsRevenueShareApplicable { get; set; }
        public bool AllowSms { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }

        public virtual ICollection<GtHmdmlc> GtHmdmlc { get; set; }
    }
}
