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
    public class DoctorLeaveRepository : IDoctorLeaveRepository
    {
        public async Task<DO_ReturnParameter> InsertIntoDoctorLeave(DO_DoctorLeave obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var isDoctorLeaveExist = db.GtEsdold.Where(x => x.DoctorId == obj.DoctorId && ((x.OnLeaveFrom.Date >= obj.OnLeaveFrom.Date && x.OnLeaveFrom.Date <= obj.OnLeaveTill.Date) || (x.OnLeaveTill.Date >= obj.OnLeaveFrom.Date && x.OnLeaveTill.Date <= obj.OnLeaveTill.Date)) && x.ActiveStatus == true).Count();
                        if (isDoctorLeaveExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Leave already Exists for the Date Range" };
                        }

                        var dMasterLeave = new GtEsdold
                        {
                            DoctorId = obj.DoctorId,
                            OnLeaveFrom = obj.OnLeaveFrom.Date,
                            OnLeaveTill = obj.OnLeaveTill.Date,
                            NoOfDays = obj.NoOfDays,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormID,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID,

                        };
                        db.GtEsdold.Add(dMasterLeave);

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor Leave Created Successfully." };
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

        public async Task<DO_ReturnParameter> UpdateDoctorLeave(DO_DoctorLeave obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEsdold doctorLeave = db.GtEsdold.Where(x => x.DoctorId == obj.DoctorId && x.OnLeaveFrom.Date == obj.OnLeaveFrom.Date).FirstOrDefault();
                        if (doctorLeave == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Doctor Leave doesn't Exists to update" };
                        }
                        else
                        {
                            doctorLeave.ActiveStatus = obj.ActiveStatus;
                            doctorLeave.ModifiedBy = obj.UserID;
                            doctorLeave.ModifiedOn = System.DateTime.Now;
                            doctorLeave.ModifiedTerminal = obj.TerminalID;

                        };

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Doctor Leave Updated Successfully." };
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

        public async Task<List<DO_DoctorLeave>> GetDoctorLeaveListAll(int doctorId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEsdold
                        .Where(w => w.DoctorId == doctorId)    //&& w.OnLeaveTill >= System.DateTime.Now.Date
                        .AsNoTracking()
                        .Select(x => new DO_DoctorLeave
                        {
                            DoctorId = x.DoctorId,
                            OnLeaveFrom = x.OnLeaveFrom,
                            OnLeaveTill = x.OnLeaveTill,
                            NoOfDays = x.NoOfDays,
                            ActiveStatus = x.ActiveStatus

                        }).OrderByDescending(x => x.OnLeaveFrom).ToListAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_DoctorLeave> GetDoctorLeaveData(int doctorId, DateTime leaveFromDate)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var dc_ms = db.GtEsdold
                        .Where(w => w.DoctorId == doctorId && w.OnLeaveFrom.Date == leaveFromDate.Date)
                        .AsNoTracking()
                        .Select(x => new DO_DoctorLeave
                        {
                            DoctorId = x.DoctorId,
                            OnLeaveFrom = x.OnLeaveFrom,
                            OnLeaveTill = x.OnLeaveTill,
                            NoOfDays = x.NoOfDays,
                            ActiveStatus = x.ActiveStatus

                        }).FirstOrDefaultAsync();

                    return await dc_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
