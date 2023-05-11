using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HCP.ClinicalServices.IF;
using HCP.ClinicalServices.DO;

namespace HCP.ClinicalServices.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleRepository _DoctorScheduleRepository;

        public DoctorScheduleController(IDoctorScheduleRepository doctorScheduleRepository)
        {
            _DoctorScheduleRepository = doctorScheduleRepository;
        }

        /// <summary>
        /// Insert into Doctor Schedule Table
        /// UI Reffered - Doctor Schedule,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctorSchedule(DO_DoctorSchedule obj)
        {
            var msg = await _DoctorScheduleRepository.InsertIntoDoctorSchedule(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update into Doctor Schedule Table
        /// UI Reffered - Doctor Schedule,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDoctorSchedule(DO_DoctorSchedule obj)
        {
            var msg = await _DoctorScheduleRepository.UpdateDoctorSchedule(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Doctor Schedule List Data
        /// UI Reffered - Doctor Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorScheduleList(int businessKey, int clinicId, int specialtyId, int doctorId, int consultationType)
        {
            var msg = await _DoctorScheduleRepository.GetDoctorScheduleList(businessKey, clinicId, specialtyId, doctorId, consultationType);
            return Ok(msg);
        }

        /// <summary>
        /// Get Doctor Schedule List Data
        /// UI Reffered - Doctor Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorScheduleListAll(int businessKey, int doctorId)
        {
            var msg = await _DoctorScheduleRepository.GetDoctorScheduleListAll(businessKey, doctorId);
            return Ok(msg);
        }

        /// <summary>
        /// Get Doctor Schedule Data
        /// UI Reffered - Doctor Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorSchedule(int businessKey, int clinicId, int specialtyId, int doctorId, int consultationType, int serialNo)
        {
            var msg = await _DoctorScheduleRepository.GetDoctorSchedule(businessKey, clinicId, specialtyId, doctorId, consultationType, serialNo);
            return Ok(msg);
        }

        /// <summary>
        /// Insert into Doctor Schedule Change Table
        /// UI Reffered - Doctor Schedule Change,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctorScheduleChange(DO_DoctorSchedule obj)
        {
            var msg = await _DoctorScheduleRepository.InsertIntoDoctorScheduleChange(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update into Doctor Schedule Change Table
        /// UI Reffered - Doctor Schedule Change,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDoctorScheduleChange(DO_DoctorSchedule obj)
        {
            var msg = await _DoctorScheduleRepository.UpdateDoctorScheduleChange(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Doctor Schedule Change List Data
        /// UI Reffered - Doctor Schedule Change,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorScheduleChangeListAll(int businessKey, int doctorId)
        {
            var msg = await _DoctorScheduleRepository.GetDoctorScheduleChangeListAll(businessKey, doctorId);
            return Ok(msg);
        }

        /// <summary>
        /// Get Doctor Schedule Change Data
        /// UI Reffered - Doctor Schedule Change,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorScheduleChange(int businessKey, int clinicId, int specialtyId, int doctorId, int consultationType, DateTime scheduleChangeDate)
        {
            var msg = await _DoctorScheduleRepository.GetDoctorScheduleChange(businessKey, clinicId, specialtyId, doctorId, consultationType, scheduleChangeDate);
            return Ok(msg);
        }

        /// <summary>
        /// Insert into Doctor Schedule2 Change Table
        /// UI Reffered - Doctor Scheduler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctorScheduler(DO_DoctorSchedule obj)
        {
            var msg = await _DoctorScheduleRepository.InsertIntoDoctorScheduler(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update Doctor Schedule2 Change Table
        /// UI Reffered - Doctor Scheduler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDoctorScheduler(DO_DoctorSchedule obj)
        {
            var msg = await _DoctorScheduleRepository.UpdateDoctorScheduler(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Doctor Scheduler
        /// UI Reffered - Doctor Scheduler
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorSchedulerListAll(int businessKey, int clinicId, int consultationId, DateTime scheduleFromDate, DateTime scheduleToDate)
        {
            var msg = await _DoctorScheduleRepository.GetDoctorSchedulerListAll(businessKey, clinicId, consultationId, scheduleFromDate, scheduleToDate);
            return Ok(msg);
        }
        /// <summary>
        /// Get Doctor Schedule List Data
        /// UI Reffered - Doctor Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveDoctorScheduler(bool status, int businesskey, int consultationId, int clinicId, int specialtyId, int doctorId, int serialNo)
        {
            var msg = await _DoctorScheduleRepository.ActiveOrDeActiveDoctorScheduler(status,businesskey,consultationId,clinicId,specialtyId, doctorId,serialNo);
            return Ok(msg);
        }
    }
}