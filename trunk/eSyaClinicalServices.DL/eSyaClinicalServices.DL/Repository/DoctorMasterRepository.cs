using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HCP.ClinicalServices.IF;
using HCP.ClinicalServices.DO;
using HCP.ClinicalServices.DL.Entities;

namespace HCP.ClinicalServices.DL.Repository
{
    public class DoctorMasterRepository : IDoctorMasterRepository
    {
        #region Doctor Master
        public async Task<DO_ReturnParameter> InsertIntoDoctorMaster(DO_DoctorMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                       
                        var isDoctorExist = db.GtEsdocd.Where(x => x.DoctorShortName.ToUpper().Trim().Replace(" ", "") == obj.DoctorShortName.ToUpper().Trim().Replace(" ", "")).Count();

                        if (isDoctorExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Short Name already Exists" };
                        }
                        var isregtnoExist = db.GtEsdocd.Where(x => x.DoctorRegnNo.ToUpper().Trim().Replace(" ", "") == obj.DoctorRegnNo.ToUpper().Trim().Replace(" ", "")).Count();
                        if (isregtnoExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Registration Number already Exists" };
                        }
                        if (!string.IsNullOrEmpty(obj.MobileNumber) && obj.MobileNumber != "0")
                        {
                            var isMobileNoExist = db.GtEsdocd.Where(x => x.MobileNumber.ToUpper().Trim().Replace(" ", "") == obj.MobileNumber.ToUpper().Trim().Replace(" ", "") && x.ActiveStatus).Count();
                            if(isMobileNoExist>0)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Mobile Number is already Exists" };
                            }
                        }
                        if (!string.IsNullOrEmpty(obj.EMailId))
                        {
                            var isEmailIdExist = db.GtEsdocd.Where(x => x.EmailId.ToUpper().Trim().Replace(" ", "") == obj.EMailId.ToUpper().Trim().Replace(" ", "") && x.ActiveStatus).Count();
                            if (isEmailIdExist > 0)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "EMail Id is already Exists" };
                            }
                        }
                        int maxDoctorId = db.GtEsdocd.Select(d => d.DoctorId).DefaultIfEmpty().Max();
                        int DocId = maxDoctorId + 1;
                        var dMaster = new GtEsdocd
                        {
                            DoctorId = DocId,
                            DoctorName = obj.DoctorName,
                            DoctorShortName = obj.DoctorShortName,
                            Gender = obj.Gender,
                            DoctorRegnNo = obj.DoctorRegnNo,
                            Isdcode = obj.ISDCode,
                            MobileNumber = obj.MobileNumber,
                            EmailId = obj.EMailId,
                            DoctorClass = obj.DoctorClass,
                            DoctorCategory = obj.DoctorCategory,
                            AllowConsultation = obj.AllowConsultation,
                            PayoutType = obj.PayoutType,
                            AllowSms = obj.AllowSMS,
                            TraiffFrom = obj.TraiffFrom,
                            Password = obj.Password,
                            SeniorityLevel = obj.SeniorityLevel,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormID,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID,

                        };
                        db.GtEsdocd.Add(dMaster);
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor Master Created Successfully.", ID = DocId };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateDoctorMaster(DO_DoctorMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEsdocd dc_ms = db.GtEsdocd.Where(w => w.DoctorId == obj.DoctorId).FirstOrDefault();
                        if (dc_ms == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Id does not exist." };
                        }
                        var _shortnameExist = db.GtEsdocd.Where(x => x.DoctorShortName.ToUpper().Trim().Replace(" ", "") == obj.DoctorShortName.ToUpper().Trim().Replace(" ", "") && x.DoctorId != obj.DoctorId).Count();
                        if (_shortnameExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Short Name already Exists" };
                        }
                        var _isregtnoExist = db.GtEsdocd.Where(x => x.DoctorRegnNo.ToUpper().Trim().Replace(" ", "") == obj.DoctorRegnNo.ToUpper().Trim().Replace(" ", "") && x.DoctorId != obj.DoctorId).Count();
                        if (_isregtnoExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Doctor Registration Number already Exists" };
                        }
                        if (!string.IsNullOrEmpty(obj.MobileNumber) && obj.MobileNumber != "0")
                        {
                            var isMobileNoExist = db.GtEsdocd.Where(x => x.MobileNumber.ToUpper().Trim().Replace(" ", "") == obj.MobileNumber.ToUpper().Trim().Replace(" ", "") && x.DoctorId != obj.DoctorId && x.ActiveStatus).Count();
                            if (isMobileNoExist > 0)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Mobile Number is already Exists" };
                            }
                        }
                        if (!string.IsNullOrEmpty(obj.EMailId))
                        {
                            var isEmailIdExist = db.GtEsdocd.Where(x => x.EmailId.ToUpper().Trim().Replace(" ", "") == obj.EMailId.ToUpper().Trim().Replace(" ", "") && x.DoctorId != obj.DoctorId && x.ActiveStatus).Count();
                            if (isEmailIdExist > 0)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "EMail Id is already Exists" };
                            }
                        }

                        dc_ms.DoctorName = obj.DoctorName.Trim();
                        dc_ms.DoctorShortName = obj.DoctorShortName;
                        dc_ms.Gender = obj.Gender;
                        dc_ms.DoctorRegnNo = obj.DoctorRegnNo;
                        dc_ms.Isdcode = obj.ISDCode;
                        dc_ms.MobileNumber = obj.MobileNumber;
                        dc_ms.EmailId = obj.EMailId;
                        dc_ms.DoctorClass = obj.DoctorClass;
                        dc_ms.DoctorCategory = obj.DoctorCategory;
                        dc_ms.AllowConsultation = obj.AllowConsultation;
                        dc_ms.PayoutType = obj.PayoutType;
                        dc_ms.AllowSms = obj.AllowSMS;
                        dc_ms.TraiffFrom = obj.TraiffFrom;
                        dc_ms.Password = obj.Password;
                        dc_ms.SeniorityLevel = obj.SeniorityLevel;
                        dc_ms.ActiveStatus = obj.ActiveStatus;
                        dc_ms.ModifiedBy = obj.UserID;
                        dc_ms.ModifiedOn = System.DateTime.Now;
                        dc_ms.ModifiedTerminal = obj.TerminalID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor Master Updated Successfully.", ID = obj.DoctorId };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_DoctorMaster>> GetDoctorMasterList()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEsdocd
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorClass),
                        d => new { d.DoctorClass },
                        a => new { DoctorClass = a.ApplicationCode },
                        (d, a) => new { d, a = a.FirstOrDefault() })
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorCategory),
                        dd => new { dd.d.DoctorCategory },
                        aa => new { DoctorCategory = aa.ApplicationCode },
                        (dd, aa) => new { dd, aa = aa.FirstOrDefault() })
                         .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.PayoutType),
                        ddd => new { ddd.dd.d.PayoutType },
                        aaa => new { PayoutType = aaa.ApplicationCode },
                        (ddd, aaa) => new { ddd, aaa = aaa.FirstOrDefault() })
                         .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.SeniorityLevel),
                        dddd => new { dddd.ddd.dd.d.SeniorityLevel },
                        aaaa => new { SeniorityLevel = aaaa.ApplicationCode },
                        (dddd, aaaa) => new { dddd, aaaa = aaaa.FirstOrDefault() })
                        .Where(w => w.dddd.ddd.dd.d.ActiveStatus == true)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorMaster
                        {
                            DoctorId = x.dddd.ddd.dd.d.DoctorId,
                            DoctorName = x.dddd.ddd.dd.d.DoctorName,
                            DoctorShortName = x.dddd.ddd.dd.d.DoctorShortName,
                            Gender = x.dddd.ddd.dd.d.Gender,
                            DoctorRegnNo = x.dddd.ddd.dd.d.DoctorRegnNo,
                            ISDCode = x.dddd.ddd.dd.d.Isdcode,
                            MobileNumber = x.dddd.ddd.dd.d.MobileNumber,
                            EMailId = x.dddd.ddd.dd.d.EmailId,
                            DoctorClass = x.dddd.ddd.dd.d.DoctorClass,
                            DoctorClassDesc = x.dddd.ddd.dd.a != null ? x.dddd.ddd.dd.a.CodeDesc : string.Empty,
                            DoctorCategory = x.dddd.ddd.dd.d.DoctorCategory,
                            DoctorCategoryDesc = x.dddd.ddd.aa != null ? x.dddd.ddd.aa.CodeDesc : string.Empty,
                            AllowConsultation = x.dddd.ddd.dd.d.AllowConsultation,
                            PayoutType = x.dddd.ddd.dd.d.PayoutType,
                            PayoutTypeDesc = x.dddd.aaa.CodeDesc != null ? x.dddd.aaa.CodeDesc : string.Empty,
                            SeniorityLevel = x.dddd.ddd.dd.d.SeniorityLevel,
                            SeniorityLevelDesc = x.aaaa != null ? x.aaaa.CodeDesc : string.Empty,
                            AllowSMS = x.dddd.ddd.dd.d.AllowSms,
                            TraiffFrom = x.dddd.ddd.dd.d.TraiffFrom,
                            Password = x.dddd.ddd.dd.d.Password,
                            ActiveStatus = x.dddd.ddd.dd.d.ActiveStatus

                        }).OrderBy(x => x.DoctorName).ToListAsync();

                    return await dc_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_DoctorMaster>> GetDoctorMasterListForPrefix(string doctorNamePrefix)
        {
            if (doctorNamePrefix == null)
                doctorNamePrefix = "";
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEsdocd
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorClass),
                        d => new { d.DoctorClass },
                        a => new { DoctorClass = a.ApplicationCode },
                        (d, a) => new { d, a = a.FirstOrDefault() })
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorCategory),
                        dd => new { dd.d.DoctorCategory },
                        aa => new { DoctorCategory = aa.ApplicationCode },
                        (dd, aa) => new { dd, aa = aa.FirstOrDefault() })
                         .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.PayoutType),
                        ddd => new { ddd.dd.d.PayoutType },
                        aaa => new { PayoutType = aaa.ApplicationCode },
                        (ddd, aaa) => new { ddd, aaa = aaa.FirstOrDefault() })
                         .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.SeniorityLevel),
                        dddd => new { dddd.ddd.dd.d.SeniorityLevel },
                        aaaa => new { SeniorityLevel = aaaa.ApplicationCode },
                        (dddd, aaaa) => new { dddd, aaaa = aaaa.FirstOrDefault() })
                        .Where(w => w.dddd.ddd.dd.d.DoctorName.StartsWith(doctorNamePrefix))
                        .AsNoTracking()
                        .Select(x => new DO_DoctorMaster
                        {
                            DoctorId = x.dddd.ddd.dd.d.DoctorId,
                            DoctorName = x.dddd.ddd.dd.d.DoctorName,
                            DoctorShortName = x.dddd.ddd.dd.d.DoctorShortName,
                            Gender = x.dddd.ddd.dd.d.Gender,
                            DoctorRegnNo = x.dddd.ddd.dd.d.DoctorRegnNo,
                            ISDCode = x.dddd.ddd.dd.d.Isdcode,
                            MobileNumber = x.dddd.ddd.dd.d.MobileNumber,
                            EMailId = x.dddd.ddd.dd.d.EmailId,
                            DoctorClass = x.dddd.ddd.dd.d.DoctorClass,
                            DoctorClassDesc = x.dddd.ddd.dd.a != null ? x.dddd.ddd.dd.a.CodeDesc : string.Empty,
                            DoctorCategory = x.dddd.ddd.dd.d.DoctorCategory,
                            DoctorCategoryDesc = x.dddd.ddd.aa != null ? x.dddd.ddd.aa.CodeDesc : string.Empty,
                            AllowConsultation = x.dddd.ddd.dd.d.AllowConsultation,
                            PayoutType = x.dddd.ddd.dd.d.PayoutType,
                            PayoutTypeDesc = x.dddd.aaa.CodeDesc != null ? x.dddd.aaa.CodeDesc : string.Empty,
                            SeniorityLevel = x.dddd.ddd.dd.d.SeniorityLevel,
                            SeniorityLevelDesc = x.aaaa != null ? x.aaaa.CodeDesc : string.Empty,
                            AllowSMS = x.dddd.ddd.dd.d.AllowSms,
                            TraiffFrom = x.dddd.ddd.dd.d.TraiffFrom,
                            Password = x.dddd.ddd.dd.d.Password,
                            ActiveStatus = x.dddd.ddd.dd.d.ActiveStatus
                        }).OrderBy(x => x.DoctorName).ToListAsync();

                    return await dc_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_DoctorMaster> GetDoctorMaster(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms =await db.GtEsdocd
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorClass),
                        d => new { d.DoctorClass },
                        a => new { DoctorClass = a.ApplicationCode },
                        (d, a) => new { d, a = a.FirstOrDefault() })
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorCategory),
                        dd => new { dd.d.DoctorCategory },
                        aa => new { DoctorCategory = aa.ApplicationCode },
                        (dd, aa) => new { dd, aa = aa.FirstOrDefault() })
                         .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.PayoutType),
                        ddd => new { ddd.dd.d.PayoutType },
                        aaa => new { PayoutType = aaa.ApplicationCode },
                        (ddd, aaa) => new { ddd, aaa = aaa.FirstOrDefault() })
                         .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.SeniorityLevel),
                        dddd => new { dddd.ddd.dd.d.SeniorityLevel },
                        aaaa => new { SeniorityLevel = aaaa.ApplicationCode },
                        (dddd, aaaa) => new { dddd, aaaa = aaaa.FirstOrDefault() })
                        .Where(w => w.dddd.ddd.dd.d.DoctorId == doctorId)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorMaster
                        {
                            DoctorId = x.dddd.ddd.dd.d.DoctorId,
                            DoctorName = x.dddd.ddd.dd.d.DoctorName,
                            DoctorShortName = x.dddd.ddd.dd.d.DoctorShortName,
                            Gender = x.dddd.ddd.dd.d.Gender,
                            DoctorRegnNo = x.dddd.ddd.dd.d.DoctorRegnNo,
                            ISDCode = x.dddd.ddd.dd.d.Isdcode,
                            MobileNumber = x.dddd.ddd.dd.d.MobileNumber,
                            EMailId = x.dddd.ddd.dd.d.EmailId,
                            DoctorClass = x.dddd.ddd.dd.d.DoctorClass,
                            DoctorClassDesc = x.dddd.ddd.dd.a != null ? x.dddd.ddd.dd.a.CodeDesc : string.Empty,
                            DoctorCategory = x.dddd.ddd.dd.d.DoctorCategory,
                            DoctorCategoryDesc = x.dddd.ddd.aa != null ? x.dddd.ddd.aa.CodeDesc : string.Empty,
                            AllowConsultation = x.dddd.ddd.dd.d.AllowConsultation,
                            PayoutType = x.dddd.ddd.dd.d.PayoutType,
                            PayoutTypeDesc = x.dddd.aaa.CodeDesc != null ? x.dddd.aaa.CodeDesc : string.Empty,
                            SeniorityLevel = x.dddd.ddd.dd.d.SeniorityLevel,
                            SeniorityLevelDesc = x.aaaa != null ? x.aaaa.CodeDesc : string.Empty,
                            AllowSMS = x.dddd.ddd.dd.d.AllowSms,
                            TraiffFrom = x.dddd.ddd.dd.d.TraiffFrom,
                            Password = x.dddd.ddd.dd.d.Password,
                            ActiveStatus = x.dddd.ddd.dd.d.ActiveStatus

                        }).FirstOrDefaultAsync();
                    return  dc_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> ActiveOrDeActiveDoctor(bool status, int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEsdocd doctor = db.GtEsdocd.Where(x => x.DoctorId == doctorId).FirstOrDefault();
                        if (doctor == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor is not exist" };
                        }

                        doctor.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Doctor Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Doctor De Activated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));

                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        #endregion

        #region Doctor Business Link
        public async Task<List<DO_DoctorMaster>> GetDoctorMasterBusinessList(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEsdocd
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorClass),
                        d => new { d.DoctorClass },
                        a => new { DoctorClass = a.ApplicationCode },
                        (d, a) => new { d, a = a.FirstOrDefault() })
                        .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorCategory),
                        dd => new { dd.d.DoctorCategory },
                        aa => new { DoctorCategory = aa.ApplicationCode },
                        (dd, aa) => new { dd, aa = aa.FirstOrDefault() })
                        .GroupJoin(db.GtEsdobl.Where(x => x.BusinessKey == businessKey && x.ActiveStatus),
                        ddd => new { ddd.dd.d.DoctorId },
                        dbl => new { dbl.DoctorId },
                        (ddd, dbl) => new { ddd, dbl = dbl.FirstOrDefault() })
                        .Where(w => w.ddd.dd.d.ActiveStatus == true)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorMaster
                        {
                            DoctorId = x.ddd.dd.d.DoctorId,

                            DoctorName = x.ddd.dd.d.DoctorName,
                            DoctorShortName = x.ddd.dd.d.DoctorShortName,
                            Gender = x.ddd.dd.d.Gender == "F" ? "Female" : "Male",
                            //Qualification = x.ddd.dd.d.Qualification,
                            DoctorRegnNo = x.ddd.dd.d.DoctorRegnNo,
                            ISDCode = x.ddd.dd.d.Isdcode,
                            MobileNumber = x.ddd.dd.d.MobileNumber,
                            DoctorClass = x.ddd.dd.d.DoctorClass,
                            DoctorClassDesc = x.ddd.dd.a != null ? x.ddd.dd.a.CodeDesc : string.Empty,
                            DoctorCategory = x.ddd.dd.d.DoctorCategory,
                            DoctorCategoryDesc = x.ddd.aa != null ? x.ddd.aa.CodeDesc : string.Empty,
                            AllowConsultation = x.ddd.dd.d.AllowConsultation,
                            //IsRevenueShareApplicable = x.ddd.dd.d.IsRevenueShareApplicable,
                            AllowSMS = x.ddd.dd.d.AllowSms,
                            ActiveStatus = x.dbl != null ? x.dbl.ActiveStatus : false

                        }).OrderBy(x => x.DoctorName).ToListAsync();

                    return await dc_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertIntoDoctorBusinessLink(List<DO_DoctorMaster> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (obj != null)
                        {
                            int _doctorId = obj.FirstOrDefault().DoctorId;
                            var doc_businesslist = db.GtEsdobl.Where(c => c.DoctorId == _doctorId).ToList();
                            if (doc_businesslist.Count > 0)
                            {
                                foreach (var objdoc in doc_businesslist)
                                {
                                    db.GtEsdobl.Remove(objdoc);
                                    db.SaveChanges();
                                }

                            }
                            
                            foreach (var key in obj.Where(x=>x.ActiveStatus==true))
                            {
                                GtEsdobl objkeys = new GtEsdobl
                                {
                                    DoctorId = key.DoctorId,
                                    BusinessKey = key.BusinessKey,
                                    ActiveStatus = key.ActiveStatus,
                                    FormId = key.FormID,
                                    CreatedBy = key.UserID,
                                    CreatedOn = DateTime.Now,
                                    CreatedTerminal = key.TerminalID
                                };
                                db.GtEsdobl.Add(objkeys);
                                await db.SaveChangesAsync();

                            }
                            
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Business Location Linked Successfully" };
                        }

                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "No Business Locations selected to Save" };
                        }
                    }

                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        //public async Task<DO_ReturnParameter> InsertIntoDoctorBusinessLink(List<DO_DoctorMaster> obj)
        //{
        //    using (var db = new eSyaEnterprise())
        //    {
        //        using (var dbContext = db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                bool dataSaved = false;
        //                foreach (DO_DoctorMaster objDM in obj)
        //                {
        //                    GtEsdobl dMaster = db.GtEsdobl.Where(x => x.BusinessKey == objDM.BusinessKey && x.DoctorId == objDM.DoctorId).FirstOrDefault();
        //                    if (dMaster == null)
        //                    {
        //                        if (objDM.ActiveStatus)
        //                        {
        //                            dMaster = new GtEsdobl
        //                            {
        //                                BusinessKey = objDM.BusinessKey,
        //                                DoctorId = objDM.DoctorId,
        //                                ActiveStatus = objDM.ActiveStatus,
        //                                FormId = objDM.FormID,
        //                                CreatedBy = objDM.UserID,
        //                                CreatedOn = System.DateTime.Now,
        //                                CreatedTerminal = objDM.TerminalID,

        //                            };
        //                            db.GtEsdobl.Add(dMaster);
        //                            dataSaved = true;
        //                        }
        //                    }
        //                    else if(objDM.ActiveStatus != dMaster.ActiveStatus)
        //                    {
        //                        dMaster.ActiveStatus = objDM.ActiveStatus;
        //                        dMaster.ModifiedBy = objDM.UserID;
        //                        dMaster.ModifiedOn = System.DateTime.Now;
        //                        dMaster.ModifiedTerminal = objDM.TerminalID;
        //                        dataSaved = true;
        //                    }
        //                }
        //                if(!dataSaved)
        //                {
        //                    return new DO_ReturnParameter() { Status = false, Message = "Please Select any Doctor to Save." };
        //                }

        //                await db.SaveChangesAsync();
        //                dbContext.Commit();
        //                return new DO_ReturnParameter() { Status = true, Message = "Doctor Business Link Updated Successfully." };
        //            }
        //            catch (DbUpdateException ex)
        //            {
        //                dbContext.Rollback();
        //                throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
        //            }
        //            catch (Exception ex)
        //            {
        //                dbContext.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        public async Task<List<DO_BusinessLocation>> GetBusinessLocationDoctorList(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEcbsln
                        .GroupJoin(db.GtEsdobl.Where(x => x.DoctorId == doctorId),
                        d => new { d.BusinessKey },
                        a => new { a.BusinessKey },
                        (d, a) => new { d, a = a.FirstOrDefault() })
                        //.Join(db.GtEsdocd,
                        //aa => new { aa.a.DoctorId },
                        //bb => new { bb.DoctorId },
                        //(aa, bb) => new { aa, bb })
                        .Where(w => w.d.ActiveStatus == true)
                        .AsNoTracking()
                        .Select(x => new DO_BusinessLocation
                        {
                            BusinessKey = x.d.BusinessKey,
                            LocationDescription = x.d.BusinessName,
                            //SegmentDesc = Convert.ToString(x.d.GtEcbssg.SegmentDesc),
                            SegmentDesc = x.d.BusinessName,
                            ActiveStatus = x.a != null ? x.a.ActiveStatus : false

                        }).OrderBy(x => x.LocationDescription).ToListAsync();

                    return await dc_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertIntoBusinessDoctorLink(List<DO_DoctorMaster> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        bool dataSaved = false;
                        foreach (DO_DoctorMaster objDM in obj)
                        {
                            GtEsdobl dMaster = db.GtEsdobl.Where(x => x.BusinessKey == objDM.BusinessKey && x.DoctorId == objDM.DoctorId).FirstOrDefault();
                            if (dMaster == null)
                            {
                                if (objDM.ActiveStatus)
                                {
                                    dMaster = new GtEsdobl
                                    {
                                        BusinessKey = objDM.BusinessKey,
                                        DoctorId = objDM.DoctorId,
                                        ActiveStatus = objDM.ActiveStatus,
                                        FormId = objDM.FormID,
                                        CreatedBy = objDM.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = objDM.TerminalID,

                                    };
                                    db.GtEsdobl.Add(dMaster);
                                    dataSaved = true;
                                }
                            }
                            else if (objDM.ActiveStatus != dMaster.ActiveStatus)
                            {
                                dMaster.ActiveStatus = objDM.ActiveStatus;
                                dMaster.ModifiedBy = objDM.UserID;
                                dMaster.ModifiedOn = System.DateTime.Now;
                                dMaster.ModifiedTerminal = objDM.TerminalID;
                                dataSaved = true;
                            }
                        }
                        if (!dataSaved)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Please Select any Business Location." };
                        }

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Business Location Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_BusinessLocation>> GetDoctorBusinessKey(int doctorId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEcbsln
                        .Join(db.GtEsdobl, 
                        l => new {l.BusinessKey},
                        d => new {d.BusinessKey},
                        (l,d) => new {l,d}
                        )
                        .Where(w => w.d.ActiveStatus && w.l.ActiveStatus && w.d.DoctorId == doctorId)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.l.BusinessKey,
                            LocationDescription = r.l.BusinessName
                        }).Distinct().ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_BusinessLocation>> GetDoctorLocationbyDoctorId(int doctorId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEsdobl.Where(x=>x.DoctorId==doctorId && x.ActiveStatus==true)
                        .Join(db.GtEcbsln,
                        l => new { l.BusinessKey },
                        d => new { d.BusinessKey },
                        (l, d) => new { l, d }
                        )
                       
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.l.BusinessKey,
                            LocationDescription = r.d.BusinessName,
                        }).Distinct().ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Specialty Doctor Link

        public async Task<List<DO_SpecialtyDoctorLink>> GetSpecialtyListByDoctorId(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var do_ms = db.GtEsdosp
                        .Join(db.GtEsspcd,
                        d => new { d.SpecialtyId },
                        s => new { s.SpecialtyId },
                        (d, s) => new { d, s }
                        )
                        .Join(db.GtEcbsln,
                        dd => new {dd.d.BusinessKey},
                        b => new {b.BusinessKey},
                        (dd,b) => new {dd,b}
                        )
                        .Where(w => w.dd.d.DoctorId == doctorId && w.b.ActiveStatus && w.dd.s.ActiveStatus)
                        .AsNoTracking()
                        .Select(x => new DO_SpecialtyDoctorLink
                        {
                            DoctorID = x.dd.d.DoctorId,
                            SpecialtyID = x.dd.s.SpecialtyId,
                            SpecialtyDesc = x.dd.s.SpecialtyDesc,
                            LocationDesc = x.b.BusinessName,
                            BusinessKey = x.dd.d.BusinessKey,
                            ActiveStatus = x.dd.d.ActiveStatus

                        }).OrderBy(x => x.DoctorName).ToListAsync();

                    return await do_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertDoctorSpecialtyLink(DO_SpecialtyDoctorLink obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEsdosp spDl = db.GtEsdosp.Where(x => x.BusinessKey == obj.BusinessKey && x.SpecialtyId == obj.SpecialtyID && x.DoctorId == obj.DoctorID).FirstOrDefault();
                        if (spDl != null)
                        {
                            spDl.ActiveStatus = obj.ActiveStatus;
                            spDl.ModifiedBy = obj.UserID;
                            spDl.ModifiedOn = System.DateTime.Now;
                            spDl.ModifiedTerminal = obj.TerminalID;
                        }
                        else if (obj.ActiveStatus)
                        {
                            var sMaster = new GtEsdosp
                            {
                                BusinessKey = obj.BusinessKey,
                                SpecialtyId = obj.SpecialtyID,
                                DoctorId = obj.DoctorID,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID,

                            };
                            db.GtEsdosp.Add(sMaster);
                        }

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Specialty Linked with Doctor Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateDoctorSpecialtyLink(DO_SpecialtyDoctorLink obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEsdosp sp_ms = db.GtEsdosp.Where(w => w.SpecialtyId == obj.SpecialtyID && w.BusinessKey == obj.BusinessKey && w.DoctorId == obj.DoctorID).FirstOrDefault();
                        if (sp_ms == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Specialty does not exist." };
                        }

                        sp_ms.ActiveStatus = obj.ActiveStatus;
                        sp_ms.ModifiedBy = obj.UserID;
                        sp_ms.ModifiedOn = System.DateTime.Now;
                        sp_ms.ModifiedTerminal = obj.TerminalID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Specialty Link Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_SpecialtyDoctorLink>> GetSpecialtyListByBKeyDoctorId(int businessKey, int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var do_ms = db.GtEsdosp
                        .Join(db.GtEsspcd,
                        d => new { d.SpecialtyId },
                        c => new { c.SpecialtyId },
                        (d, c) => new { d, c }
                        )
                        .Where(w => w.d.BusinessKey == businessKey && w.d.DoctorId == doctorId && w.d.ActiveStatus && w.c.ActiveStatus)
                        .AsNoTracking()
                        .Select(x => new DO_SpecialtyDoctorLink
                        {
                            DoctorID = x.d.DoctorId,
                            SpecialtyID = x.d.SpecialtyId,
                            SpecialtyDesc = x.c.SpecialtyDesc

                        }).OrderBy(x => x.DoctorName).ToListAsync();

                    return await do_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region About Doctor Details
        public async Task<Do_DoctorDetails> GetDoctordetailsbydoctorId(int doctorId)
        {
            using (var db = new eSyaEnterprise())
                {
                    try
                    {
                        var dc_details = db.GtEsdoab.Where(x=>x.DoctorId==doctorId)
                            .Select(x => new Do_DoctorDetails
                            {
                                DoctorId=x.DoctorId,
                                LanguageKnown=x.LanguageKnown,
                                Experience=x.Experience,
                                DoctorRemarks=x.DoctorRemarks,
                                CertificationCourse=x.CertificationCourse,
                                AboutDoctor=x.AboutDoctor,
                                ActiveStatus=x.ActiveStatus
                            })
                            .FirstOrDefaultAsync();

                        return await dc_details;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateIntoDoctordetails(Do_DoctorDetails obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var dc_details = db.GtEsdoab.Where(x => x.DoctorId == obj.DoctorId).FirstOrDefault();
                        if (dc_details == null)
                        {
                            var details = new GtEsdoab
                            {
                                DoctorId = obj.DoctorId,
                                LanguageKnown = obj.LanguageKnown,
                                Experience = obj.Experience,
                                DoctorRemarks=obj.DoctorRemarks,
                                CertificationCourse = obj.CertificationCourse,
                                AboutDoctor = obj.AboutDoctor,
                                //ProfileImagePath = obj.ProfileImagePath,
                                ActiveStatus=obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID,

                            };
                            db.GtEsdoab.Add(details);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Doctor Details Created sucessfully" };
                        }

                        else
                        {
                            dc_details.DoctorId = obj.DoctorId;
                            dc_details.LanguageKnown = obj.LanguageKnown;
                            dc_details.Experience = obj.Experience;
                            dc_details.DoctorRemarks = obj.DoctorRemarks;
                            dc_details.CertificationCourse = obj.CertificationCourse;
                            dc_details.AboutDoctor = obj.AboutDoctor;
                            //dc_details.ProfileImagePath = obj.ProfileImagePath;
                            dc_details.ActiveStatus = obj.ActiveStatus;
                            dc_details.ModifiedBy = obj.UserID;
                            dc_details.ModifiedOn = System.DateTime.Now;
                            dc_details.ModifiedTerminal = obj.TerminalID;
                        }
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor Details Updated Successfully."};
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        #endregion Doctor Details

        #region Doctor day Schedule
        public async Task<List<DO_SpecialtyCodes>> GetSpecialtiesByBusinessKey(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var do_ms = db.GtEsspbl.Where(x=>x.BusinessKey==businessKey)
                        .Join(db.GtEsspcd.Where(x=>x.ActiveStatus==true),
                        d => new { d.SpecialtyId },
                        c => new { c.SpecialtyId },
                        (d, c) => new { d, c }
                        )
                        .AsNoTracking()
                        .Select(x => new DO_SpecialtyCodes
                        {
                            SpecialtyID = x.d.SpecialtyId,
                            SpecialtyDesc = x.c.SpecialtyDesc,
                            ActiveStatus=x.c.ActiveStatus
                        }).OrderBy(x => x.SpecialtyDesc).ToListAsync();

                    return await do_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_DoctorClinic>> GetClinicAndConsultationTypebySpecialty(int businessKey, int specialtyId)
        {
            using (var db = new eSyaEnterprise())
            {

                try
                {
                    //var do_cl = db.GtEsopcl
                    //    .Join(db.GtEcapcd.Where(w => w.CodeType == CodeTypeValue.Clinic),
                    //        l => new { l.ClinicId },
                    //        c => new { ClinicId = c.ApplicationCode },
                    //        (l, c) => new { l, c })
                    //    .Join(db.GtEcapcd.Where(w => w.CodeType == CodeTypeValue.ConsultationType),
                    //        lc => new { lc.l.ConsultationId },
                    //        o => new { ConsultationId = o.ApplicationCode },
                    //        (lc, o) => new { lc, o })
                    //     .GroupJoin(db.GtEsdocl.Where(w => w.BusinessKey == businessKey && w.SpecialtyId == specialtyId),
                    //         lco => new { lco.lc.l.BusinessKey, lco.lc.l.ClinicId, lco.lc.l.ConsultationId },
                    //         d => new { d.BusinessKey, d.ClinicId, d.ConsultationId },
                    //         (lco, d) => new { lco, d = d.DefaultIfEmpty().FirstOrDefault() })
                    //     .Where(w => w.lco.lc.l.BusinessKey == businessKey)
                    //   .Select(r => new DO_DoctorClinic
                    //   {

                    //       ClinicId= r.d != null ? r.d.ClinicId:0,
                    //       ClinicDesc= r.lco.lc.c.CodeDesc,
                    //       ConsultationId = r.d != null ? r.d.ConsultationId : 0,
                    //       ConsultationDesc = r.lco.o.CodeDesc,
                    //       ActiveStatus = r.d != null ? true : false

                    //       //BusinessKey = r.d != null ? r.d.BusinessKey : 0,
                    //       //ClinicId = r.lco.lc.l.ClinicId,
                    //       //ClinicDesc = r.lco.lc.c.CodeDesc,
                    //       //ConsultationId = r.lco.lc.l.ConsultationId,
                    //       //ConsultationDesc = r.lco.o.CodeDesc,
                    //       //ActiveStatus = r.d != null ? r.d.ActiveStatus : false
                    //   }).ToListAsync();

                    var do_cl = db.GtEsopcl
                           
                          .Select(r => new DO_DoctorClinic
                          {

                             
                              ActiveStatus = r.ActiveStatus

                           //BusinessKey = r.d != null ? r.d.BusinessKey : 0,
                           //ClinicId = r.lco.lc.l.ClinicId,
                           //ClinicDesc = r.lco.lc.c.CodeDesc,
                           //ConsultationId = r.lco.lc.l.ConsultationId,
                           //ConsultationDesc = r.lco.o.CodeDesc,
                           //ActiveStatus = r.d != null ? r.d.ActiveStatus : false
                       }).ToListAsync();

                    return await do_cl;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                
            }
        }

        public async Task<List<DO_DoctorMaster>> GetDoctorsbySpecialtyClinicAndConsultation(int businessKey,int specialtyId, int clinicId, int consultationId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var do_cl = db.GtEsdocl
                        .Join(db.GtEcapcd.Where(w => w.CodeType == CodeTypeValue.Clinic),
                        l => new { l.ClinicId },
                        c => new { ClinicId = c.ApplicationCode },
                        (l, c) => new { l, c })
                        //.Join(db.GtEcapcd.Where(w => w.CodeType == CodeTypeValue.ConsultationType),
                        //lc => new { lc.l.ConsultationId },
                        //o => new { ConsultationId = o.ApplicationCode },
                        //(lc, o) => new { lc, o })
                        .Join(db.GtEsdocd.Where(w => w.ActiveStatus),
                                                //lco => new { lco.lc.l.DoctorId },
                                                lco => new { lco.l.DoctorId },
                        d => new { d.DoctorId },
                        (lco, d) => new { lco, d })
                        .Join(db.GtEsspcd.Where(w => w.ActiveStatus),
                                                //lcod => new { lcod.lco.lc.l.SpecialtyId },
                                                lcod => new { lcod.lco.l.SpecialtyId },

                        s => new { s.SpecialtyId },
                        (lcod, s) => new { lcod, s })
                                               //.Where(w => w.lcod.lco.lc.l.BusinessKey == businessKey && w.lcod.lco.lc.l.SpecialtyId == specialtyId && w.lcod.lco.lc.l.ClinicId == clinicId && w.lcod.lco.lc.l.ConsultationId == consultationId)
                                               .Where(w => w.lcod.lco.l.BusinessKey == businessKey && w.lcod.lco.l.SpecialtyId == specialtyId && w.lcod.lco.l.ClinicId == clinicId)

.AsNoTracking()
                       .Select(r => new DO_DoctorMaster
                       {
                           //DoctorId = r.lcod.lco.lc.l.DoctorId,
                           //DoctorName = r.lcod.d.DoctorName,
                           DoctorId = r.lcod.lco.l.DoctorId,
                           DoctorName = r.lcod.d.DoctorName,
                       }).ToListAsync();

                    return await do_cl;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_DoctordaySchedule>> GetDoctordaySchedulebySearchCriteria(int businessKey,int specialtyId, int clinicId, int consultationId,int doctorId, DateTime scheduleFromDate, DateTime scheduleToDate)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_sc = db.GtEsdos2
                        .Join(db.GtEsspcd,
                        o => new { o.SpecialtyId },
                        s => new { s.SpecialtyId },
                        (o, s) => new { o, s })
                        .Join(db.GtEsdocd,
                        os => new { os.o.DoctorId },
                        d => new { d.DoctorId },
                        (os, d) => new { os, d })

                        .Join(db.GtEcapcd.Where(w => w.CodeType == CodeTypeValue.Clinic),
                            l => new { l.os.o.ClinicId},
                            c => new { ClinicId = c.ApplicationCode },
                            (l, c) => new { l, c })
                        .Join(db.GtEcapcd.Where(w => w.CodeType == CodeTypeValue.ConsultationType),
                            lc => new { lc.l.os.o.ConsultationId},
                            ol => new { ConsultationId = ol.ApplicationCode },
                            (lc, ol) => new { lc, ol })
                        .Where(w => w.lc.l.os.o.BusinessKey == businessKey && w.lc.l.os.o.ClinicId == clinicId && w.lc.l.os.o.ConsultationId == consultationId
                         && w.lc.l.os.o.SpecialtyId == specialtyId && w.lc.l.os.o.DoctorId == doctorId /*&& w.lc.l.os.o.ScheduleDate.Date >= scheduleFromDate.Date */
                        /* && w.lc.l.os.o.ScheduleDate.Date <= scheduleToDate.Date*/)

                        .AsNoTracking()

                        .Select(x => new DO_DoctordaySchedule
                        {
                            
                            BusinessKey = x.lc.l.os.o.BusinessKey,
                            ConsultationId = x.lc.l.os.o.ConsultationId,
                            ConsultationDesc = x.ol.CodeDesc,
                            ClinicId = x.lc.l.os.o.ClinicId,
                            ClinicDesc = x.lc.c.CodeDesc,
                            SpecialtyId = x.lc.l.os.o.SpecialtyId,
                            SpecialtyDesc = x.lc.l.os.s.SpecialtyDesc,
                            DoctorId = x.lc.l.os.o.DoctorId,
                            DoctorName = x.lc.l.d.DoctorName,
                            //ScheduleDate = x.lc.l.os.o.ScheduleDate,
                            SerialNo = x.lc.l.os.o.SerialNo,
                            ScheduleFromTime = x.lc.l.os.o.ScheduleFromTime,
                            ScheduleToTime = x.lc.l.os.o.ScheduleToTime,
                            //NoOfPatients = x.lc.l.os.o.NoOfPatients,
                            //XlsheetReference=x.lc.l.os.o.XlsheetReference,
                            ActiveStatus = x.lc.l.os.o.ActiveStatus
                        })
                        .ToListAsync();

                    return await dc_sc;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertIntoDoctordaySchedule(DO_DoctordaySchedule obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var ds_list = db.GtEsdos2.Where(x => x.BusinessKey == obj.BusinessKey && x.ConsultationId == obj.ConsultationId
                                      && x.ClinicId == obj.ClinicId && x.SpecialtyId == obj.SpecialtyId && x.DoctorId == obj.DoctorId
                                     /* && x.ScheduleDate == obj.ScheduleDate*/ && x.ActiveStatus).ToList();

                        bool isexists = false;
                        foreach (var item in ds_list)
                        {
                            if ((obj.ScheduleFromTime >= item.ScheduleFromTime && obj.ScheduleFromTime < item.ScheduleToTime)
                                   || (obj.ScheduleToTime > item.ScheduleFromTime && obj.ScheduleToTime <= item.ScheduleToTime))
                            {
                                isexists = true;
                            }
                        }
                        if (isexists == true)
                        {
                             return new DO_ReturnParameter() { Status = false, Message = "Time slot for selected date is already exists." };
                        }
                        var _isexists =await db.GtEsdos2.Where(x => x.BusinessKey == obj.BusinessKey && x.ConsultationId == obj.ConsultationId
                                     && x.ClinicId == obj.ClinicId && x.SpecialtyId == obj.SpecialtyId && x.DoctorId == obj.DoctorId
                                     /*&& x.ScheduleDate == obj.ScheduleDate*/).FirstOrDefaultAsync();
                        if (_isexists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "already exists." };
                        }
                        else
                        {
                            int serialNumber = db.GtEsdos2.Where(x => x.BusinessKey == obj.BusinessKey && x.ConsultationId == obj.ConsultationId && x.ClinicId == obj.ClinicId && x.SpecialtyId == obj.SpecialtyId && x.DoctorId == obj.DoctorId /*&& x.ScheduleDate == obj.ScheduleDate*/).Select(x => x.SerialNo).DefaultIfEmpty().Max() + 1;
                            ////int serialNumber = db.GtEsdos2.Where(x => x.BusinessKey == obj.BusinessKey && x.ConsultationId == obj.ConsultationId && x.ClinicId == obj.ClinicId && x.SpecialtyId == obj.SpecialtyId && x.DoctorId == obj.DoctorId ).Select(x => x.SerialNo).DefaultIfEmpty().Max() + 1;

                            var do_sc = new GtEsdos2
                            {
                                BusinessKey = obj.BusinessKey,
                                ConsultationId = obj.ConsultationId,
                                ClinicId = obj.ClinicId,
                                SpecialtyId = obj.SpecialtyId,
                                DoctorId = obj.DoctorId,
                                //ScheduleDate = obj.ScheduleDate,
                                SerialNo = serialNumber,
                                ScheduleFromTime = obj.ScheduleFromTime,
                                ScheduleToTime = obj.ScheduleToTime,
                                //NoOfPatients = obj.NoOfPatients,
                                //XlsheetReference = "#",
                                //XlsheetReference = obj.XlsheetReference,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID,
                            };

                            db.GtEsdos2.Add(do_sc);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Doctor day Schedule Created Successfully." };
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateDoctordaySchedule(DO_DoctordaySchedule obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEsdos2 _daySchedule = db.GtEsdos2.Where(x => x.BusinessKey == obj.BusinessKey && x.ConsultationId == obj.ConsultationId && x.ClinicId == obj.ClinicId && x.SpecialtyId == obj.SpecialtyId && x.DoctorId == obj.DoctorId /*&& x.ScheduleDate == obj.ScheduleDate*/ && x.SerialNo == obj.SerialNo).FirstOrDefault();
                        if (_daySchedule == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor day Schedule doesn't Exists to update" };
                        }
                        else
                        {
                            bool isexists = false;
                            var ds_list = db.GtEsdos2.Where(x => x.BusinessKey == obj.BusinessKey && x.ConsultationId == obj.ConsultationId
                                      && x.ClinicId == obj.ClinicId && x.SpecialtyId == obj.SpecialtyId && x.DoctorId == obj.DoctorId
                                      /*&& x.ScheduleDate == obj.ScheduleDate*/ && x.ActiveStatus && x.SerialNo != obj.SerialNo).ToList();

                            foreach (var item in ds_list)
                            {
                                if ((obj.ScheduleFromTime >= item.ScheduleFromTime && obj.ScheduleFromTime < item.ScheduleToTime)
                                       || (obj.ScheduleToTime > item.ScheduleFromTime && obj.ScheduleToTime <= item.ScheduleToTime))
                                {
                                    isexists = true;
                                }
                            }
                            if (isexists == true)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Time slot for selected date is already exists." };
                            }

                            _daySchedule.ScheduleFromTime = obj.ScheduleFromTime;
                            _daySchedule.ScheduleToTime = obj.ScheduleToTime;
                            //_daySchedule.NoOfPatients = obj.NoOfPatients;
                            //_daySchedule.XlsheetReference = obj.XlsheetReference;
                            _daySchedule.ActiveStatus = obj.ActiveStatus;
                            _daySchedule.ModifiedBy = obj.UserID;
                            _daySchedule.ModifiedOn = System.DateTime.Now;
                            _daySchedule.ModifiedTerminal = obj.TerminalID;

                        };

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor day Schedule Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> ActiveOrDeActiveDoctordaySchedule(DO_DoctordaySchedule objdel)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEsdos2 _dayschedule = db.GtEsdos2.Where(x => x.BusinessKey == objdel.BusinessKey && x.ConsultationId == objdel.ConsultationId && x.ClinicId == objdel.ClinicId && x.SpecialtyId == objdel.SpecialtyId && x.DoctorId == objdel.DoctorId && x.SerialNo == objdel.SerialNo /*&& x.ScheduleDate== objdel.ScheduleDate*/).FirstOrDefault();
                        if (_dayschedule == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Scheduler is not exist" };
                        }

                        _dayschedule.ActiveStatus = objdel.status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (objdel.status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Doctor day Schedule Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Doctor day Schedule De Activated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));

                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> ImpotedDoctorScheduleList(List<DO_DoctordaySchedule> obj)
        {
            using (var db = new eSyaEnterprise())
            {

                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                       
                        foreach (var time in obj)
                        {
                            if (time.ScheduleFromTime >= time.ScheduleToTime)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = time.ScheduleFromTime+ "From Time can't be more than or equal to" + time.ScheduleToTime + "To Time." };
                            }
                           
                            var doctor = db.GtEsdocd.Where(x => x.DoctorName.ToUpper().Trim() == time.DoctorName.ToUpper().Trim()).FirstOrDefault();
                            if (doctor == null)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Doctor:" + time.DoctorName + "is not avalabe" };
                            }
                            else
                            {
                                time.DoctorId = doctor.DoctorId;
                            }
                            var clinic = db.GtEcapcd.Where(x => x.CodeDesc.ToUpper().Trim() == time.ClinicDesc.ToUpper().Trim()).FirstOrDefault();
                            if (clinic == null)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Doctor:" + time.ClinicDesc + "is not avalabe" };
                            }
                            else
                            {
                                time.ClinicId = clinic.ApplicationCode;
                            }
                            var consultation = db.GtEcapcd.Where(x => x.CodeDesc.ToUpper().Trim() == time.ConsultationDesc.ToUpper().Trim()).FirstOrDefault();
                            if (consultation == null)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Doctor:" + time.ConsultationDesc + "is not avalabe" };
                            }
                            else
                            {
                                time.ConsultationId = consultation.ApplicationCode;
                            }
                            var specialty = db.GtEsspcd.Where(x => x.SpecialtyDesc.ToUpper().Trim() == time.SpecialtyDesc.ToUpper().Trim()).FirstOrDefault();
                            if (specialty == null)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Doctor:" + time.SpecialtyDesc + "is not avalabe" };
                            }
                            else
                            {
                                time.SpecialtyId = specialty.SpecialtyId;
                            }


                            var ds_list = db.GtEsdos2.Where(x => x.BusinessKey == time.BusinessKey && x.ConsultationId == time.ConsultationId
                                      && x.ClinicId == time.ClinicId && x.SpecialtyId == time.SpecialtyId && x.DoctorId == time.DoctorId
                                      /*&& x.ScheduleDate == time.ScheduleDate*/ && x.ActiveStatus).ToList();

                            bool isexists = false;
                            foreach (var _isexists in ds_list)
                            {
                                if ((time.ScheduleFromTime >= _isexists.ScheduleFromTime && time.ScheduleFromTime < _isexists.ScheduleToTime)
                                       || (time.ScheduleToTime > _isexists.ScheduleFromTime && time.ScheduleToTime <= _isexists.ScheduleToTime))
                                {
                                    isexists = true;
                                }
                            }
                            if (isexists == true)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Time slot for Date:" +time.ScheduleDate+ "is already exists for Doctor:" + time.DoctorName };
                            }

                            var scheduled = await db.GtEsdos2.Where(x => x.BusinessKey == time.BusinessKey && x.ConsultationId == time.ConsultationId
                                     && x.ClinicId == time.ClinicId && x.SpecialtyId == time.SpecialtyId && x.DoctorId == time.DoctorId
                                    /* && x.ScheduleDate == time.ScheduleDate*/ && x.SerialNo == time.SerialNo).FirstOrDefaultAsync();

                            if (scheduled == null)
                            {
                                int serialNumber = db.GtEsdos2.Where(x => x.BusinessKey == time.BusinessKey && x.ConsultationId == time.ConsultationId && x.ClinicId == time.ClinicId && x.SpecialtyId == time.SpecialtyId && x.DoctorId == time.DoctorId /*&& x.ScheduleDate == time.ScheduleDate*/).Select(x => x.SerialNo).DefaultIfEmpty().Max() + 1;
                                //int serialNumber = db.GtEsdos2.Where(x => x.BusinessKey == time.BusinessKey && x.ConsultationId == time.ConsultationId && x.ClinicId == time.ClinicId && x.SpecialtyId == time.SpecialtyId && x.DoctorId == time.DoctorId).Select(x => x.SerialNo).DefaultIfEmpty().Max() + 1;
                                var do_sc = new GtEsdos2
                                {
                                    BusinessKey = time.BusinessKey,
                                    ConsultationId = time.ConsultationId,
                                    ClinicId = time.ClinicId,
                                    SpecialtyId = time.SpecialtyId,
                                    DoctorId = time.DoctorId,
                                    //ScheduleDate = time.ScheduleDate,
                                    SerialNo = serialNumber,
                                    ScheduleFromTime = time.ScheduleFromTime,
                                    ScheduleToTime = time.ScheduleToTime,
                                    //NoOfPatients = time.NoOfPatients,
                                    //XlsheetReference = "#",
                                    ActiveStatus = time.ActiveStatus,
                                    FormId = time.FormId,
                                    CreatedBy = time.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = time.TerminalID,
                                };

                                db.GtEsdos2.Add(do_sc);
                                await db.SaveChangesAsync();
                            }
                            else
                            {
                                scheduled.ScheduleFromTime = time.ScheduleFromTime;
                                scheduled.ScheduleToTime = time.ScheduleToTime;
                                //scheduled.NoOfPatients = time.NoOfPatients;
                                //scheduled.XlsheetReference = "#";
                                scheduled.ActiveStatus = time.ActiveStatus;
                                scheduled.ModifiedBy = time.UserID;
                                scheduled.ModifiedOn = System.DateTime.Now;
                                scheduled.ModifiedTerminal = time.TerminalID;
                                await db.SaveChangesAsync();
                            }

                        }
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Excel Imported Successfully for Doctor Schedule " };
                    }
                    catch (DbUpdateException ex)
                    {

                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }

                }
            }

        }


        #endregion

        #region New Doctor Master Profile 
        //public async Task<List<DO_DoctorMasterProfile>> GetDoctorMasterProfileListbyPrefix(string doctorNamePrefix)
        //{
        //    if (doctorNamePrefix == null)
        //        doctorNamePrefix = "";
        //    using (var db = new eSyaEnterprise())
        //    {
        //        try
        //        {
        //            var dc_ms = db.GtEsdocd
        //                .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorClass),
        //                d => new { d.DoctorClass },
        //                a => new { DoctorClass = a.ApplicationCode },
        //                (d, a) => new { d, a = a.FirstOrDefault() }).DefaultIfEmpty()
        //                .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.DoctorCategory),
        //                dd => new { dd.d.DoctorCategory },
        //                aa => new { DoctorCategory = aa.ApplicationCode },
        //                (dd, aa) => new { dd, aa = aa.FirstOrDefault() }).DefaultIfEmpty()
        //                 .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.PayoutType),
        //                ddd => new { ddd.dd.d.PayoutType },
        //                aaa => new { PayoutType = aaa.ApplicationCode },
        //                (ddd, aaa) => new { ddd, aaa = aaa.FirstOrDefault() }).DefaultIfEmpty()
        //                .GroupJoin(db.GtEcapcd.Where(x => x.CodeType == CodeTypeValue.SeniorityLevel),
        //                dddd => new { dddd.ddd.dd.d.SeniorityLevel },
        //                aaaa => new { SeniorityLevel = aaaa.ApplicationCode },
        //                (dddd, aaaa) => new { dddd, aaaa = aaaa.FirstOrDefault() }).DefaultIfEmpty()
        //                .Where(w => w.dddd.ddd.dd.d.DoctorName.StartsWith(doctorNamePrefix))
        //                .AsNoTracking()
        //                .Select(x => new DO_DoctorMasterProfile
        //                {
        //                    DoctorId = x.dddd.ddd.dd.d.DoctorId,
        //                    DoctorName = x.dddd.ddd.dd.d.DoctorName,
        //                    DoctorShortName = x.dddd.ddd.dd.d.DoctorShortName,
        //                    Gender = x.dddd.ddd.dd.d.Gender,
        //                    DoctorRegnNo = x.dddd.ddd.dd.d.DoctorRegnNo,
        //                    Isdcode = x.dddd.ddd.dd.d.Isdcode,
        //                    MobileNumber = x.dddd.ddd.dd.d.MobileNumber,
        //                    EmailId= x.dddd.ddd.dd.d.EmailId,
        //                    DoctorClass = x.dddd.ddd.dd.d.DoctorClass,
        //                    DoctorClassDesc =x.dddd.ddd.dd.a != null ? x.dddd.ddd.dd.a.CodeDesc: string.Empty,
        //                    DoctorCategory = x.dddd.ddd.dd.d.DoctorCategory,
        //                    DoctorCategoryDesc = x.dddd.ddd.aa != null ? x.dddd.ddd.aa.CodeDesc : string.Empty,
        //                    AllowConsultation = x.dddd.ddd.dd.d.AllowConsultation,
        //                    PayoutType = x.dddd.ddd.dd.d.PayoutType,
        //                    PayoutTypeDesc = x.dddd.aaa.CodeDesc!= null ? x.dddd.aaa.CodeDesc : string.Empty,
        //                    SeniorityLevel = x.dddd.ddd.dd.d.SeniorityLevel,
        //                    SeniorityLevelDesc = x.aaaa != null ? x.aaaa.CodeDesc : string.Empty,
        //                    AllowSms = x.dddd.ddd.dd.d.AllowSms,
        //                    TraiffFrom = x.dddd.ddd.dd.d.TraiffFrom,
        //                    Password = x.dddd.ddd.dd.d.Password,
        //                    ActiveStatus = x.dddd.ddd.dd.d.ActiveStatus
        //                }).OrderBy(x => x.DoctorName).ToListAsync();

        //            return  await dc_ms;
        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
        #endregion

        #region Doctor Profilr Business Link 
        public async Task<List<DO_DoctorBusinessLink>> GetDoctorBusinessLinkList(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEcbsln
                        .GroupJoin(db.GtEsdobl.Where(x => x.DoctorId == doctorId),
                        d => new { d.BusinessKey },
                        a => new { a.BusinessKey },
                        (d, a) => new { d, a = a.FirstOrDefault() })
                        .Where(w => w.d.ActiveStatus == true)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorBusinessLink
                        {
                            BusinessKey = x.d.BusinessKey,
                            BusinessLocation = x.d.BusinessName,
                            TimeSlotInMins = x.a != null ? x.a.TimeSlotInMins : 0,
                            PatientCountPerHour = x.a != null ? x.a.PatientCountPerHour : 0,
                            ActiveStatus = x.a != null ? x.a.ActiveStatus : false

                        }).OrderBy(x => x.BusinessLocation).ToListAsync();

                    return await dc_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateDoctorBusinessLink(List<DO_DoctorBusinessLink> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        bool dataSaved = false;
                        foreach (DO_DoctorBusinessLink objDM in obj)
                        {
                            GtEsdobl dMaster = db.GtEsdobl.Where(x => x.BusinessKey == objDM.BusinessKey && x.DoctorId == objDM.DoctorId).FirstOrDefault();
                            if (dMaster == null)
                            {
                                
                                    dMaster = new GtEsdobl
                                    {
                                        BusinessKey = objDM.BusinessKey,
                                        DoctorId = objDM.DoctorId,
                                        TimeSlotInMins=objDM.TimeSlotInMins,
                                        PatientCountPerHour=objDM.PatientCountPerHour,
                                        ActiveStatus = objDM.ActiveStatus,
                                        FormId = objDM.FormID,
                                        CreatedBy = objDM.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = objDM.TerminalID,

                                    };
                                    db.GtEsdobl.Add(dMaster);
                                    dataSaved = true;
                                
                            }
                            else
                            {
                                dMaster.TimeSlotInMins = objDM.TimeSlotInMins;
                                dMaster.PatientCountPerHour = objDM.PatientCountPerHour;
                                dMaster.ActiveStatus = objDM.ActiveStatus;
                                dMaster.ModifiedBy = objDM.UserID;
                                dMaster.ModifiedOn = System.DateTime.Now;
                                dMaster.ModifiedTerminal = objDM.TerminalID;
                                dataSaved = true;
                            }
                        }
                      
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Business Location Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_DoctorBusinessLink>> GetDoctorLinkWithBusinessLocation(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    try
                    {
                        var sp_ms = db.GtEsdobl
                            .Join(db.GtEcbsln,
                            s => new { s.BusinessKey },
                            b => new { b.BusinessKey },
                            (s, b) => new { s, b })
                            .Where(w => w.s.DoctorId == doctorId && w.s.ActiveStatus)
                            .AsNoTracking()
                            .Select(x => new DO_DoctorBusinessLink
                            {
                                BusinessKey = x.s.BusinessKey,
                                BusinessLocation = x.b.BusinessName,
                                IsdCode=x.b.Isdcode
                            })
                            .GroupBy(y => y.BusinessKey, (key, grp) => grp.FirstOrDefault())
                            .OrderBy(x => x.BusinessLocation).ToListAsync();

                        return await sp_ms;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Doctor Profile Image
        public async Task<DO_ReturnParameter> InsertIntoDoctorProfileImage(DO_DoctorImage obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (obj.DoctorProfileImage == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Please Select Doctor Image" };

                        }
                        if (obj.DoctorSignatureImage == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Please Select Doctor Signature" };

                        }
                        var doc_image = db.GtEsdoim.Where(x => x.DoctorId == obj.DoctorId).FirstOrDefault();
                            if (doc_image != null)
                            {
                                doc_image.DoctorImage = obj.DoctorProfileImage;
                                doc_image.DoctorSignature = obj.DoctorSignatureImage;
                                doc_image.ActiveStatus = true;
                                doc_image.ModifiedBy = obj.UserID;
                                doc_image.ModifiedOn = System.DateTime.Now;
                                doc_image.ModifiedTerminal = obj.TerminalID;
                                await db.SaveChangesAsync();

                            }
                            else
                            {
                                var dimage = new GtEsdoim
                                {
                                    DoctorId = obj.DoctorId,
                                    DoctorImage = obj.DoctorProfileImage,
                                    DoctorSignature=obj.DoctorSignatureImage,
                                    ActiveStatus = true,
                                    CreatedBy = obj.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = obj.TerminalID
                                };
                                db.GtEsdoim.Add(dimage);
                            }
                        
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor Image & Signature Uploaded Successfully"};
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_DoctorImage> GetDoctorProfileImagebyDoctorId(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = await db.GtEsdoim.Where(x => x.DoctorId == doctorId)
                          .Select(i => new DO_DoctorImage
                          {
                              DoctorId=i.DoctorId,
                              DoctorProfileImage=i.DoctorImage,
                              DoctorSignatureImage=i.DoctorSignature,
                              ActiveStatus=i.ActiveStatus
                          }).FirstOrDefaultAsync();
                    
                    return dc_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Doctor Statutory Details
        //parameter based
        //public async Task<List<DO_DoctorStatutoryDetails>> GetDoctorStatutoryInformation(int doctorId, int isdCode)
        //{
        //    try
        //    {
        //        using (var db = new eSyaEnterprise())
        //        {
        //            var ds = db.GtEccnsd
        //                .Join(db.GtEcsupa.Where(w => w.ParameterId == 1),
        //                    x => new { x.Isdcode, x.StatutoryCode },
        //                y => new { y.Isdcode, y.StatutoryCode },
        //                   (x, y) => new { x, y })
        //                .GroupJoin(db.GtEsdosd.Where(w => w.DoctorId == doctorId),
        //                 xy => xy.x.StatutoryCode,
        //                 c => c.StatutoryCode,
        //                 (xy, c) => new { xy, c = c.FirstOrDefault() }).DefaultIfEmpty()
        //                .Where(w => w.xy.x.Isdcode == isdCode && (bool)w.xy.x.ActiveStatus)
        //                .Select(r => new DO_DoctorStatutoryDetails
        //                {
        //                    Isdcode = isdCode,
        //                    StatutoryCode = r.xy.x.StatutoryCode,
        //                    StatutoryDescription = r.xy.x.StatutoryDescription,
        //                    StatutoryValue = r.c != null ? r.c.StatutoryDescription : "",
        //                    TaxPerc = r.c != null ? r.c.TaxPerc : 0,
        //                    EffectiveFrom = r.c != null ? r.c.EffectiveFrom : DateTime.Now,
        //                    EffectiveTill = r.c != null ? r.c.EffectiveTill : null,
        //                    ActiveStatus = r.c != null ? r.c.ActiveStatus : false,
        //                }).ToListAsync();

        //            return await ds;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //without parameter based

        public async Task<List<DO_DoctorStatutoryDetails>> GetDoctorStatutoryDetails(int doctorId, int isdCode)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                    //var ds = db.GtEccnsd
                    //    .GroupJoin(db.GtEsdosd.Where(x => x.DoctorId == doctorId),
                    //     xy => new { xy.StatutoryCode },
                    //     c => new { c.StatutoryCode },
                    //     (xy, c) => new { xy, c = c.DefaultIfEmpty().Where(w => w.Isdcode == xy.Isdcode && w.StatutoryCode == xy.StatutoryCode).FirstOrDefault() })
                    //    .Select(r => new DO_DoctorStatutoryDetails
                    //    {
                    //        Isdcode = isdCode,
                    //        StatutoryCode = r.xy.StatutoryCode,
                    //        StatutoryDescription = r.xy.StatutoryDescription,
                    //        StatutoryValue = r.c != null ? r.c.StatutoryDescription : "",
                    //        TaxPerc = r.c != null ? r.c.TaxPerc : 0,
                    //        EffectiveFrom = r.c != null ? r.c.EffectiveFrom : DateTime.Now,
                    //        EffectiveTill = r.c != null ? r.c.EffectiveTill : null,
                    //        ActiveStatus = r.c != null ? r.c.ActiveStatus : false,
                    //    }).ToListAsync();
                    //return await ds;
                    return await db.GtEccnsd.Where(x => x.Isdcode == isdCode)
                       .GroupJoin(db.GtEsdosd.Where(x => x.DoctorId == doctorId),
                       m => m.StatutoryCode,
                       l => l.StatutoryCode,
                       (m, l) => new
                       { m, l }).SelectMany(z => z.l.DefaultIfEmpty(),
                       (a, b) => new DO_DoctorStatutoryDetails
                       {
                           Isdcode = a.m.Isdcode,
                           StatutoryCode= a.m.StatutoryCode,
                           StatutoryDescription = a.m.StatutoryDescription,
                           StatutoryValue = b != null ? b.StatutoryDescription : "",
                           TaxPerc = b != null ? b.TaxPerc : 0,
                           EffectiveFrom = b != null ? b.EffectiveFrom : DateTime.Now,
                           EffectiveTill = b != null ? b.EffectiveTill : null,
                           ActiveStatus = b != null ? b.ActiveStatus : false
                       }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateDoctorStatutoryDetails(List<DO_DoctorStatutoryDetails> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var is_StatutoryDetailEnter = obj.Where(w => !String.IsNullOrEmpty(w.StatutoryValue)).Count();
                        if (is_StatutoryDetailEnter <= 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Please Enter Statutory Detail." };
                        }

                        foreach (var sd in obj.Where(w => !String.IsNullOrEmpty(w.StatutoryValue)))
                        {
                            GtEsdosd cs_sd = db.GtEsdosd.Where(x => x.Isdcode == sd.Isdcode
                                            && x.StatutoryCode == sd.StatutoryCode && x.DoctorId==sd.DoctorId).FirstOrDefault();
                            if (cs_sd == null)
                            {
                                var o_cssd = new GtEsdosd
                                {
                                    DoctorId=sd.DoctorId,
                                    Isdcode = sd.Isdcode,
                                    StatutoryCode = sd.StatutoryCode,
                                    StatutoryDescription = sd.StatutoryValue,
                                    TaxPerc=sd.TaxPerc,
                                    EffectiveFrom=sd.EffectiveFrom,
                                    EffectiveTill=sd.EffectiveTill,
                                    ActiveStatus = sd.ActiveStatus,
                                    FormId = sd.FormID,
                                    CreatedBy = sd.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = sd.TerminalID
                                };
                                db.GtEsdosd.Add(o_cssd);
                            }
                            else
                            {
                                cs_sd.StatutoryDescription = sd.StatutoryValue;
                                cs_sd.TaxPerc = sd.TaxPerc;
                                cs_sd.EffectiveFrom = sd.EffectiveFrom;
                                cs_sd.EffectiveTill = sd.EffectiveTill;
                                cs_sd.ActiveStatus = sd.ActiveStatus;
                                cs_sd.ModifiedBy = sd.UserID;
                                cs_sd.ModifiedOn = System.DateTime.Now;
                                cs_sd.ModifiedTerminal = sd.TerminalID;
                            }
                            await db.SaveChangesAsync();
                        }

                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Saved Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_ISDCodes>> GetISDCodesbyBusinessKey(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var do_cl = db.GtEcbsln
                        .Join(db.GtEccncd.Where(w => w.ActiveStatus),
                        lc => new { lc.Isdcode },
                        o => new { o.Isdcode },
                        (lc, o) => new { lc, o })
                        .Where(w => w.lc.BusinessKey == businessKey && w.lc.ActiveStatus)
                       .AsNoTracking()
                       .Select(r => new DO_ISDCodes
                       {
                           Isdcode = r.lc.Isdcode,
                           CountryName = r.o.CountryName,
                           CountryFlag=r.o.CountryFlag,
                           MobileNumberPattern=r.o.MobileNumberPattern,
                           CountryCode = r.o.CountryCode,
                       }).ToListAsync();

                    return await do_cl;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<DO_ISDCodes> GetISDCodesbyDoctorId(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEsdobl
                        .Join(db.GtEcbsln,
                        d => new { d.BusinessKey },
                        a => new { a.BusinessKey },
                        (d, a) => new { d, a })
                        .Join(db.GtEccncd,
                        dd => new { dd.a.Isdcode },
                        aa => new { aa.Isdcode },
                        (dd, aa) => new { dd, aa })
                        .Where(w => w.dd.d.DoctorId == doctorId && w.dd.d.ActiveStatus == true && w.aa.ActiveStatus==true
                            && w.dd.a.ActiveStatus==true)
                        .AsNoTracking()
                        .Select(x => new DO_ISDCodes
                        {
                            Isdcode = x.dd.a.Isdcode,
                            CountryFlag = x.aa.CountryFlag,
                            CountryCode=x.aa.CountryCode,
                            CountryName=x.aa.CountryName,
                            MobileNumberPattern = x.aa.MobileNumberPattern,

                        }).ToList();
                    if (dc_ms.Count > 0)
                    { 
                      var res = dc_ms.GroupBy(x => x.Isdcode).Select(y => y.First()).Distinct();
                      return res.ToList();
                    }
                    else
                    {
                        return dc_ms.ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
            }
        }
        #endregion

        #region Doctor Profile Consultation Rates
        public async Task<List<DO_DoctorProfileConsultationRate>> GetDoctorProfileConsultationRatebyDoctorId(int businessKey, int clinictype, string currencycode, int ratetype,int doctorId)
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {
                    var defaultDate = DateTime.Now.Date;
                    var result = db.GtEsclsl.Where(w => w.BusinessKey == businessKey && w.ActiveStatus && (clinictype == 0 ? true : w.ClinicId == clinictype))
                        .Join(db.GtEssrms,
                        l => l.ServiceId,
                        s => s.ServiceId,
                        (l, s) => new { l, s })
                        .Join(db.GtEcapcd,
                        ls => ls.l.ClinicId,
                        c => c.ApplicationCode,
                        (ls, c) => new { ls, c })
                        .Join(db.GtEcapcd,
                        lsc => lsc.ls.l.ConsultationId,
                        n => n.ApplicationCode,
                        (lsc, n) => new { lsc, n })
                        .GroupJoin(db.GtEsdoro.Where(w =>w.DoctorId==doctorId && w.BusinessKey == businessKey && (clinictype == 0 ? true : w.ClinicId == clinictype) && w.CurrencyCode == currencycode && w.RateType == ratetype).OrderByDescending(o => o.ActiveStatus),
                        lscn => lscn.lsc.ls.l.ClinicId,
                        r => r.ClinicId,
                        (lscn, r) => new { lscn, r = r.Where(w => w.ConsultationId == lscn.lsc.ls.l.ConsultationId && w.ServiceId == lscn.lsc.ls.l.ServiceId).FirstOrDefault() })
                                 .Select(x => new DO_DoctorProfileConsultationRate
                                 {
                                     ServiceId = x.lscn.lsc.ls.s.ServiceId,
                                     ClinicId = x.lscn.lsc.c.ApplicationCode,
                                     ConsultationId = x.lscn.n.ApplicationCode,
                                     ServiceDesc = x.lscn.lsc.ls.s.ServiceDesc,
                                     ClinicDesc = x.lscn.lsc.c.CodeDesc,
                                     ConsultationDesc = x.lscn.n.CodeDesc,
                                     Tariff = x.r != null ? x.r.Tariff : 0,
                                     EffectiveDate = x.r != null ? x.r.EffectiveDate : defaultDate,
                                     EffectiveTill=x.r!=null?x.r.EffectiveTill:null,
                                     ActiveStatus = x.r != null ? x.r.ActiveStatus : true,
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

        public async Task<DO_ReturnParameter> AddOrUpdateDoctorProfileConsultationRate(List<DO_DoctorProfileConsultationRate> obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var c_visitrate in obj)
                        {
                            var ServiceExist = db.GtEsdoro.Where(w =>w.DoctorId== c_visitrate.DoctorId && w.ServiceId == c_visitrate.ServiceId && w.BusinessKey == c_visitrate.BusinessKey && w.ClinicId == c_visitrate.ClinicId && w.ConsultationId == c_visitrate.ConsultationId && w.CurrencyCode == c_visitrate.CurrencyCode && w.RateType == c_visitrate.RateType && w.EffectiveTill == null).FirstOrDefault();
                            if (ServiceExist != null)
                            {
                                if (c_visitrate.EffectiveDate != ServiceExist.EffectiveDate)
                                {
                                    if (c_visitrate.EffectiveDate < ServiceExist.EffectiveDate)
                                    {
                                        return new DO_ReturnParameter() { Status = false, Message = "New effective date can't be less than the current effective date" };
                                    }
                                    ServiceExist.EffectiveTill = c_visitrate.EffectiveDate.AddDays(-1);
                                    ServiceExist.ModifiedBy = c_visitrate.UserID;
                                    ServiceExist.ModifiedOn = System.DateTime.Now;
                                    ServiceExist.ModifiedTerminal = c_visitrate.TerminalID;
                                    ServiceExist.ActiveStatus = false;

                                    var clinicvisitrate = new GtEsdoro
                                    {
                                        DoctorId=c_visitrate.DoctorId,
                                        BusinessKey = c_visitrate.BusinessKey,
                                        ServiceId = c_visitrate.ServiceId,
                                        ClinicId = c_visitrate.ClinicId,
                                        ConsultationId = c_visitrate.ConsultationId,
                                        RateType = c_visitrate.RateType,
                                        CurrencyCode = c_visitrate.CurrencyCode,
                                        EffectiveDate = c_visitrate.EffectiveDate,
                                        Tariff = c_visitrate.Tariff,
                                        ActiveStatus = c_visitrate.ActiveStatus,
                                        FormId = c_visitrate.FormId,
                                        CreatedBy = c_visitrate.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = c_visitrate.TerminalID
                                    };
                                    db.GtEsdoro.Add(clinicvisitrate);


                                }
                                else
                                {
                                    ServiceExist.Tariff = c_visitrate.Tariff;
                                    ServiceExist.ActiveStatus = c_visitrate.ActiveStatus;

                                    ServiceExist.ModifiedBy = c_visitrate.UserID;
                                    ServiceExist.ModifiedOn = System.DateTime.Now;
                                    ServiceExist.ModifiedTerminal = c_visitrate.TerminalID;
                                }

                            }
                            else
                            {
                                if (c_visitrate.Tariff != 0)
                                {
                                    var clinicvisitrate = new GtEsdoro
                                    {
                                        DoctorId= c_visitrate.DoctorId,
                                        BusinessKey = c_visitrate.BusinessKey,
                                        ServiceId = c_visitrate.ServiceId,
                                        ClinicId = c_visitrate.ClinicId,
                                        ConsultationId = c_visitrate.ConsultationId,
                                        RateType = c_visitrate.RateType,
                                        CurrencyCode = c_visitrate.CurrencyCode,
                                        EffectiveDate = c_visitrate.EffectiveDate,
                                        Tariff = c_visitrate.Tariff,
                                        ActiveStatus = c_visitrate.ActiveStatus,
                                        FormId = c_visitrate.FormId,
                                        CreatedBy = c_visitrate.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = c_visitrate.TerminalID
                                    };
                                    db.GtEsdoro.Add(clinicvisitrate);
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
        #endregion

        #region Doctor Profile Address
        public async Task<List<DO_DoctorProfileAddress>> GetStatesbyIsdCode(int Isdcode)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtAddrin
                        .Where(w => w.Isdcode == Isdcode && w.ActiveStatus)   
                        .AsNoTracking()
                        .Select(x => new DO_DoctorProfileAddress
                        {
                            StateCode = x.StateCode,
                            StateDesc = x.StateDesc

                        }).OrderBy(x => x.StateDesc).ToListAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_DoctorProfileAddress>> GetCitiesbyStateCode(int Isdcode,int statecode)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtAddrin
                        .Where(w => w.Isdcode == Isdcode &&w.StateCode==statecode && w.ActiveStatus)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorProfileAddress
                        {
                            CityCode = x.CityCode,
                            CityDesc = x.CityDesc

                        }).OrderBy(x => x.CityDesc).ToListAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_DoctorProfileAddress>> GetZipDescriptionbyCityCode(int Isdcode, int statecode,int citycode)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtAddrin
                        .Where(w => w.Isdcode == Isdcode && w.StateCode == statecode && w.CityCode==citycode && w.ActiveStatus)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorProfileAddress
                        {
                            ZipserialNumber = x.ZipserialNumber,
                            ZipDesc=x.Zipdesc,

                        }).OrderBy(x => x.ZipDesc).ToListAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_DoctorProfileAddress> GetZipCodeAndArea(int Isdcode, int statecode, int citycode,int zipserialno)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtAddrin
                        .Where(w => w.Isdcode == Isdcode && w.StateCode == statecode && w.CityCode == citycode && w.ZipserialNumber==zipserialno && w.ActiveStatus)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorProfileAddress
                        {
                            Zipcode = x.Zipcode,
                            Area=x.Area,
                        }).FirstOrDefaultAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_DoctorProfileAddress> FillCoumbosbyZipCode(int Isdcode, string zipcode)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtAddrin
                        .Where(w => w.Isdcode == Isdcode && w.Zipcode.ToUpper().Trim().Replace(" ", "") ==zipcode.ToUpper().Trim().Replace(" ", "") && w.ActiveStatus)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorProfileAddress
                        {
                            Isdcode = x.Isdcode,
                            StateCode = x.StateCode,
                            CityCode = x.CityCode,
                            Zipcode = x.Zipcode,
                            ZipserialNumber=x.ZipserialNumber,
                            Area=x.Area
                        }).FirstOrDefaultAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_DoctorProfileAddress> GetDoctorAddressDoctorId(int Isdcode,int doctorId,int businesskey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEsdoad
                        .Where(w => w.DoctorId == doctorId && w.Isdcode==Isdcode && w.BusinessKey==businesskey)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorProfileAddress
                        {
                            BusinessKey=x.BusinessKey,
                            Isdcode = x.Isdcode,
                            StateCode = x.StateCode,
                            CityCode=x.CityCode,
                            Zipcode=x.Zipcode,
                            ZipserialNumber=x.ZipserialNumber,
                            ZipDesc=x.Zipcode,
                            Area=x.Area,
                            Address=x.Address,
                            Pobox=x.Pobox,
                            ActiveStatus=x.ActiveStatus
                        }).OrderBy(x => x.StateDesc).FirstOrDefaultAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateIntoDoctorProfileAddress(DO_DoctorProfileAddress obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var dc_address = db.GtEsdoad.Where(x => x.DoctorId == obj.DoctorId && x.Isdcode==obj.Isdcode && x.BusinessKey==obj.BusinessKey).FirstOrDefault();
                        if (dc_address == null)
                        {
                            var _address = new GtEsdoad
                            {
                                BusinessKey=obj.BusinessKey,
                                DoctorId = obj.DoctorId,
                                Isdcode = obj.Isdcode,
                                StateCode = obj.StateCode,
                                CityCode = obj.CityCode,
                                Zipcode = obj.Zipcode,
                                ZipserialNumber = obj.ZipserialNumber,
                                Area = obj.Area,
                                Address = obj.Address,
                                Pobox = obj.Pobox,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID,

                            };
                            db.GtEsdoad.Add(_address);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Doctor Address Created sucessfully" };
                        }

                        else
                        {
                            dc_address.StateCode = obj.StateCode;
                            dc_address.CityCode = obj.CityCode;
                            dc_address.Zipcode = obj.Zipcode;
                            dc_address.ZipserialNumber = obj.ZipserialNumber;
                            dc_address.Area = obj.Area;
                            dc_address.Address = obj.Address;
                            dc_address.Pobox = obj.Pobox;
                            dc_address.ActiveStatus = obj.ActiveStatus;
                            dc_address.ModifiedBy = obj.UserID;
                            dc_address.ModifiedOn = System.DateTime.Now;
                            dc_address.ModifiedTerminal = obj.TerminalID;
                        }
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor Address Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        #endregion
    }
}

