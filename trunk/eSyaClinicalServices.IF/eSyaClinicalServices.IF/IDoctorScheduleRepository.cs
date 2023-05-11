﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCP.ClinicalServices.DO;

namespace HCP.ClinicalServices.IF
{
    public interface IDoctorScheduleRepository
    {
        Task<DO_ReturnParameter> InsertIntoDoctorSchedule(DO_DoctorSchedule obj);
        Task<DO_ReturnParameter> UpdateDoctorSchedule(DO_DoctorSchedule obj);
        Task<List<DO_DoctorSchedule>> GetDoctorScheduleList(int businessKey, int clinicId, int specialtyId, int doctorId, int consultationType);
        Task<DO_DoctorSchedule> GetDoctorSchedule(int businessKey, int clinicId, int specialtyId, int doctorId, int consultationType, int serialNo);
        Task<List<DO_DoctorSchedule>> GetDoctorScheduleListAll(int businessKey, int doctorId);

        Task<DO_ReturnParameter> InsertIntoDoctorScheduleChange(DO_DoctorSchedule obj);
        Task<DO_ReturnParameter> UpdateDoctorScheduleChange(DO_DoctorSchedule obj);
        Task<List<DO_DoctorSchedule>> GetDoctorScheduleChangeListAll(int businessKey, int doctorId);
        Task<DO_DoctorSchedule> GetDoctorScheduleChange(int businessKey, int clinicId, int specialtyId, int doctorId, int consultationType, DateTime scheduleChangeDate);

        Task<DO_ReturnParameter> InsertIntoDoctorScheduler(DO_DoctorSchedule obj);
        Task<DO_ReturnParameter> UpdateDoctorScheduler(DO_DoctorSchedule obj);
        Task<List<DO_DoctorSchedule>> GetDoctorSchedulerListAll(int businessKey, int clinicId, int consultationId, DateTime scheduleFromDate, DateTime scheduleToDate);
        Task<DO_ReturnParameter> ActiveOrDeActiveDoctorScheduler(bool status, int businesskey, int consultationId, int clinicId, int specialtyId, int doctorId, int serialNo);
    }
}
