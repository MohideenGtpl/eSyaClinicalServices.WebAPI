using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCP.ClinicalServices.DO;

namespace HCP.ClinicalServices.IF
{
    public interface IDoctorLeaveRepository
    {
        Task<DO_ReturnParameter> InsertIntoDoctorLeave(DO_DoctorLeave obj);
        Task<DO_ReturnParameter> UpdateDoctorLeave(DO_DoctorLeave obj);
        Task<List<DO_DoctorLeave>> GetDoctorLeaveListAll(int doctorId);
        Task<DO_DoctorLeave> GetDoctorLeaveData(int doctorId, DateTime leaveFromDate);
    }
}
