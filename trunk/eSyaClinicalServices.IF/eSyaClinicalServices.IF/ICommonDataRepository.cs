﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCP.ClinicalServices.DO;

namespace HCP.ClinicalServices.IF
{
    public interface ICommonDataRepository
    {
        Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType);
        Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeTypeList(List<int> l_codeType);
        Task<List<DO_BusinessLocation>> GetBusinessKey();
        Task<List<DO_CountryCodes>> GetISDCodes();
        Task<List<DO_CurrencyCode>> GetCurrencyCodes();
    }
}
