using System;
using System.Collections.Generic;
using System.Text;
using HCP.ClinicalServices.IF;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HCP.ClinicalServices.DO;
using HCP.ClinicalServices.DL.Entities;

namespace HCP.ClinicalServices.DL.Repository
{
   public class DoctorServiceRateRepository:IDoctorServiceRateRepository
    {
        #region Doctor Service Rate
        public async Task<List<DO_DoctorServiceRate>> GetDoctorServiceRateByBKeyServiceIdCurrCodeRateType(int businessKey, int serviceId,int doctorId, string currencycode, int ratetype)
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {
                    var defaultDate = DateTime.Now.Date;
                    var result =db.GtEspasm .Where(x=>x.ParameterId == 5 && x.ActiveStatus)
                        .Join(db.GtEssrms,
                        l => l.ServiceId,
                        s => s.ServiceId,
                        (l, s) => new { l, s })
                        .GroupJoin(db.GtEscdst.Where(w => w.BusinessKey == businessKey && w.ServiceId==serviceId && w.DoctorId== doctorId && w.CurrencyCode == currencycode && w.RateType == ratetype),
                        lscn => lscn.s.ServiceId,
                        r => r.ServiceId,
                       (lscn, r) => new { lscn, r = r.DefaultIfEmpty().Where(w => w.ServiceId == lscn.s.ServiceId).FirstOrDefault() })
                                 .Select(x => new DO_DoctorServiceRate
                                 {
                                     ServiceId = x.lscn.s.ServiceId,
                                     ServiceDesc = x.lscn.s.ServiceDesc,
                                     DoctorId = doctorId,
                                     DoctorDesc = db.GtEsdocd.Where(doc => doc.DoctorId == doctorId).FirstOrDefault().DoctorName,
                                     CurrencyCode = x.r != null ? x.r.CurrencyCode : "",
                                     Tariff = x.r != null ? x.r.Tariff : 0,
                                     EffectiveDate = x.r != null ? x.r.EffectiveDate : defaultDate,
                                     ActiveStatus = x.r != null ? x.r.ActiveStatus : true,
                                     RateType= x.r != null ? x.r.RateType : 0,

                                 }
                        ).ToListAsync();
                    return await result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateDoctorServiceRate(List<DO_DoctorServiceRate> obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var d_servicerate in obj)
                        {
                            var ServiceExist = db.GtEscdst.Where(w => w.ServiceId == d_servicerate.ServiceId && w.BusinessKey == d_servicerate.BusinessKey && w.DoctorId == d_servicerate.DoctorId && w.CurrencyCode == d_servicerate.CurrencyCode && w.RateType == d_servicerate.RateType && w.EffectiveTill == null).FirstOrDefault();
                            if (ServiceExist != null)
                            {
                                if (d_servicerate.EffectiveDate != ServiceExist.EffectiveDate)
                                {
                                    if (d_servicerate.EffectiveDate < ServiceExist.EffectiveDate)
                                    {
                                        return new DO_ReturnParameter() { Status = false, Message = "New effective date can't be less than the current effective date" };
                                    }
                                    ServiceExist.EffectiveTill = d_servicerate.EffectiveDate.AddDays(-1);
                                    ServiceExist.ModifiedBy = d_servicerate.UserID;
                                    ServiceExist.ModifiedOn = DateTime.Now;
                                    ServiceExist.ModifiedTerminal = d_servicerate.TerminalID;
                                    ServiceExist.ActiveStatus = false;

                                    var docrate = new GtEscdst
                                    {
                                        BusinessKey = d_servicerate.BusinessKey,
                                        ServiceId = d_servicerate.ServiceId,
                                        DoctorId = d_servicerate.DoctorId,
                                        RateType = d_servicerate.RateType,
                                        CurrencyCode = d_servicerate.CurrencyCode,
                                        EffectiveDate = d_servicerate.EffectiveDate,
                                        Tariff = d_servicerate.Tariff,
                                        ActiveStatus = d_servicerate.ActiveStatus,
                                        FormId = d_servicerate.FormID,
                                        CreatedBy = d_servicerate.UserID,
                                        CreatedOn = DateTime.Now,
                                        CreatedTerminal = d_servicerate.TerminalID
                                    };
                                    db.GtEscdst.Add(docrate);


                                }
                                else
                                {
                                    ServiceExist.Tariff = d_servicerate.Tariff;
                                    ServiceExist.ActiveStatus = d_servicerate.ActiveStatus;
                                    ServiceExist.ModifiedBy = d_servicerate.UserID;
                                    ServiceExist.ModifiedOn = DateTime.Now;
                                    ServiceExist.ModifiedTerminal = d_servicerate.TerminalID;
                                }

                            }
                            else
                            {
                                if (d_servicerate.Tariff != 0)
                                {
                                    var doc_rate = new GtEscdst
                                    {
                                        BusinessKey = d_servicerate.BusinessKey,
                                        ServiceId = d_servicerate.ServiceId,
                                        DoctorId = d_servicerate.DoctorId,
                                        RateType = d_servicerate.RateType,
                                        CurrencyCode = d_servicerate.CurrencyCode,
                                        EffectiveDate = d_servicerate.EffectiveDate,
                                        Tariff = d_servicerate.Tariff,
                                        ActiveStatus = d_servicerate.ActiveStatus,
                                        FormId = d_servicerate.FormID,
                                        CreatedBy = d_servicerate.UserID,
                                        CreatedOn = DateTime.Now,
                                        CreatedTerminal = d_servicerate.TerminalID
                                    };
                                    db.GtEscdst.Add(doc_rate);
                                }

                            }
                        }
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter { Status = true };


                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        return new DO_ReturnParameter() { Status = false, Message = ex.Message };
                    }
                }
            }
        }

        public async Task<List<DO_DoctorMaster>> GetActiveDoctos()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEsdocd
                        .Where(w => w.ActiveStatus)
                        .Select(d => new DO_DoctorMaster
                        {
                            DoctorId = d.DoctorId,
                            DoctorName = d.DoctorName
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Specialty Service Rate

        public async Task<List<DO_SpecialityServiceRate>> GetSpecialtyServiceRateByBKeyServiceIdCurrCodeRateType(int businessKey, int serviceId, int specialtyId, string currencycode, int ratetype)
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {
                    var defaultDate = DateTime.Now.Date;
                    var result = db.GtEspasm.Where(x => x.ParameterId == 5 && x.ActiveStatus)
                        .Join(db.GtEssrms,
                        l => l.ServiceId,
                        s => s.ServiceId,
                        (l, s) => new { l, s })
                        .GroupJoin(db.GtEscsst.Where(w => w.BusinessKey == businessKey && w.ServiceId == serviceId && w.SpecialtyId == specialtyId && w.CurrencyCode == currencycode && w.RateType == ratetype),
                        lscn => lscn.s.ServiceId,
                        r => r.ServiceId,
                        (lscn, r) => new { lscn, r = r.DefaultIfEmpty().Where(w => w.ServiceId == lscn.s.ServiceId).FirstOrDefault() })
                                 .Select(x => new DO_SpecialityServiceRate
                                 {
                                     ServiceId = x.lscn.s.ServiceId,
                                     ServiceDesc = x.lscn.s.ServiceDesc,
                                     SpecialtyId = specialtyId,
                                     SpecialtyDesc = db.GtEsspcd.Where(spe => spe.SpecialtyId == specialtyId).FirstOrDefault().SpecialtyDesc,
                                     CurrencyCode = x.r != null ? x.r.CurrencyCode : "",
                                     Tariff = x.r != null ? x.r.Tariff : 0,
                                     EffectiveDate = x.r != null ? x.r.EffectiveDate : defaultDate,
                                     ActiveStatus = x.r != null ? x.r.ActiveStatus : true,
                                     RateType = x.r != null ? x.r.RateType : 0,


                                 }
                        ).ToListAsync();
                    return await result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateSpecialityServiceRate(List<DO_SpecialityServiceRate> obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var s_servicerate in obj)
                        {
                            var ServiceExist = db.GtEscsst.Where(w => w.ServiceId == s_servicerate.ServiceId && w.BusinessKey == s_servicerate.BusinessKey && w.SpecialtyId == s_servicerate.SpecialtyId && w.CurrencyCode == s_servicerate.CurrencyCode && w.RateType == s_servicerate.RateType && w.EffectiveTill == null).FirstOrDefault();
                            if (ServiceExist != null)
                            {
                                if (s_servicerate.EffectiveDate != ServiceExist.EffectiveDate)
                                {
                                    if (s_servicerate.EffectiveDate < ServiceExist.EffectiveDate)
                                    {
                                        return new DO_ReturnParameter() { Status = false, Message = "New effective date can't be less than the current effective date" };
                                    }
                                    ServiceExist.EffectiveTill = s_servicerate.EffectiveDate.AddDays(-1);
                                    ServiceExist.ModifiedBy = s_servicerate.UserID;
                                    ServiceExist.ModifiedOn = DateTime.Now;
                                    ServiceExist.ModifiedTerminal = s_servicerate.TerminalID;
                                    ServiceExist.ActiveStatus = false;

                                    var docrate = new GtEscsst
                                    {
                                        BusinessKey = s_servicerate.BusinessKey,
                                        ServiceId = s_servicerate.ServiceId,
                                        SpecialtyId = s_servicerate.SpecialtyId,
                                        RateType = s_servicerate.RateType,
                                        CurrencyCode = s_servicerate.CurrencyCode,
                                        EffectiveDate = s_servicerate.EffectiveDate,
                                        Tariff = s_servicerate.Tariff,
                                        ActiveStatus = s_servicerate.ActiveStatus,
                                        FormId = s_servicerate.FormID,
                                        CreatedBy = s_servicerate.UserID,
                                        CreatedOn = DateTime.Now,
                                        CreatedTerminal = s_servicerate.TerminalID
                                    };
                                    db.GtEscsst.Add(docrate);


                                }
                                else
                                {
                                    ServiceExist.Tariff = s_servicerate.Tariff;
                                    ServiceExist.ActiveStatus = s_servicerate.ActiveStatus;
                                    ServiceExist.ModifiedBy = s_servicerate.UserID;
                                    ServiceExist.ModifiedOn = DateTime.Now;
                                    ServiceExist.ModifiedTerminal = s_servicerate.TerminalID;
                                }

                            }
                            else
                            {
                                if (s_servicerate.Tariff != 0)
                                {
                                    var spe_rate = new GtEscsst
                                    {
                                        BusinessKey = s_servicerate.BusinessKey,
                                        ServiceId = s_servicerate.ServiceId,
                                        SpecialtyId = s_servicerate.SpecialtyId,
                                        RateType = s_servicerate.RateType,
                                        CurrencyCode = s_servicerate.CurrencyCode,
                                        EffectiveDate = s_servicerate.EffectiveDate,
                                        Tariff = s_servicerate.Tariff,
                                        ActiveStatus = s_servicerate.ActiveStatus,
                                        FormId = s_servicerate.FormID,
                                        CreatedBy = s_servicerate.UserID,
                                        CreatedOn = DateTime.Now,
                                        CreatedTerminal = s_servicerate.TerminalID
                                    };
                                    db.GtEscsst.Add(spe_rate);
                                }

                            }
                        }
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter { Status = true };


                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        return new DO_ReturnParameter() { Status = false, Message = ex.Message };
                    }
                }
            }
        }

        public async Task<List<DO_SpecialtyCodes>> GetActiveSpecialites()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEsspcd
                        .Where(w => w.ActiveStatus)
                        .Select(s => new DO_SpecialtyCodes
                        {
                            SpecialtyID = s.SpecialtyId,
                            SpecialtyDesc = s.SpecialtyDesc
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
