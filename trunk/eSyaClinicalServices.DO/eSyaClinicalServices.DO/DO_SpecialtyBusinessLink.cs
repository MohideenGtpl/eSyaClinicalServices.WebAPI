﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HCP.ClinicalServices.DO
{
    public class DO_SpecialtyBusinessLink
    {
        public int BusinessKey { get; set; }
        public int SpecialtyID { get; set; }
        public string SpecialtyDesc { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
