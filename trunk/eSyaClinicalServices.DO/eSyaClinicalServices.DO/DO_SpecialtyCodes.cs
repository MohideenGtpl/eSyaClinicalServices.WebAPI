﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HCP.ClinicalServices.DO
{
    public class DO_SpecialtyCodes
    {
        public int SpecialtyID { get; set; }
        public string SpecialtyDesc { get; set; }
        public string Gender { get; set; }
        public string SpecialtyType { get; set; }
        public string AlliedServices { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
