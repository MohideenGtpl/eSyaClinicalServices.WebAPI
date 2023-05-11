using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HCP.ClinicalServices.IF;
using HCP.ClinicalServices.DO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCP.ClinicalServices.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorMasterController : ControllerBase
    {
        private readonly IDoctorMasterRepository _DoctorMasterRepository;

        public DoctorMasterController(IDoctorMasterRepository doctorMasterRepository)
        {
            _DoctorMasterRepository = doctorMasterRepository;
        }

        #region Doctor Master
        /// <summary>
        /// Insert into Doctor Master Table
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctorMaster(DO_DoctorMaster obj)
        {
            var msg = await _DoctorMasterRepository.InsertIntoDoctorMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update into Doctor Master Table
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDoctorMaster(DO_DoctorMaster obj)
        {
            var msg = await _DoctorMasterRepository.UpdateDoctorMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get All Doctor Master List
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorMasterList()
        {
            var msg = await _DoctorMasterRepository.GetDoctorMasterList();
            return Ok(msg);
        }

        /// <summary>
        /// Get All Doctor Master List
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorMasterListForPrefix(string doctorNamePrefix)
        {
            var msg = await _DoctorMasterRepository.GetDoctorMasterListForPrefix(doctorNamePrefix);
            return Ok(msg);
        }

        /// <summary>
        /// Get Specific Doctor Master Data
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorMaster(int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetDoctorMaster(doctorId);
            return Ok(msg);
        }

        /// <summary>
        /// Active Or DeActive Doctor Master
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveDoctor(bool status, int doctorId)
        {
            var msg = await _DoctorMasterRepository.ActiveOrDeActiveDoctor(status,doctorId);
            return Ok(msg);
        }

        #endregion

        /// <summary>
        /// Get Doctor Business Link Data
        /// UI Reffered - Doctor Business Link,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorMasterBusinessList(int businessKey)
        {
            var msg = await _DoctorMasterRepository.GetDoctorMasterBusinessList(businessKey);
            return Ok(msg);
        }

        /// <summary>
        /// Insert/ Update into Doctor Business Link Table
        /// UI Reffered - Doctor Business Link,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctorBusinessLink(List<DO_DoctorMaster> obj)
        {
            var msg = await _DoctorMasterRepository.InsertIntoDoctorBusinessLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Business Doctor Link Data
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBusinessLocationDoctorList(int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetBusinessLocationDoctorList(doctorId);
            return Ok(msg);
        }

        /// <summary>
        /// Insert/ Update into Doctor Business Link Table
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoBusinessDoctorLink(List<DO_DoctorMaster> obj)
        {
            var msg = await _DoctorMasterRepository.InsertIntoBusinessDoctorLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Business Specialty Link Data
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorBusinessKey(int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetDoctorBusinessKey(doctorId);
            return Ok(msg);
        }
        /// <summary>
        /// Get Business Keys by doctor Id for drop down
        /// UI Reffered - Doctor Speciality,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorLocationbyDoctorId(int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetDoctorLocationbyDoctorId(doctorId);
            return Ok(msg);
        }
        
        /// <summary>
        /// Get Business Specialty Link Data
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSpecialtyListByDoctorId(int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetSpecialtyListByDoctorId(doctorId);
            return Ok(msg);
        }

        /// <summary>
        /// Insert into Doctor Specialty Link Table
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertDoctorSpecialtyLink(DO_SpecialtyDoctorLink obj)
        {
            var msg = await _DoctorMasterRepository.InsertDoctorSpecialtyLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update into Doctor Specialty Link Table
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDoctorSpecialtyLink(DO_SpecialtyDoctorLink obj)
        {
            var msg = await _DoctorMasterRepository.UpdateDoctorSpecialtyLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Business Specialty Link Data
        /// UI Reffered - Doctor Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSpecialtyListByBKeyDoctorId(int businessKey, int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetSpecialtyListByBKeyDoctorId(businessKey, doctorId);
            return Ok(msg);
        }
        #region Doctor Details
        /// <summary>
        /// Insert Or Update Doctor Doctor Details
        /// UI Reffered - Doctor Details,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateIntoDoctordetails(Do_DoctorDetails obj)
        {
            var msg = await _DoctorMasterRepository.InsertOrUpdateIntoDoctordetails(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Business Doctor Details by Doctor Id
        /// UI Reffered - Doctor Details,
        /// UI-Param-doctorId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctordetailsbydoctorId(int doctorId)
        {
            var do_details = await _DoctorMasterRepository.GetDoctordetailsbydoctorId(doctorId);
            return Ok(do_details);
        }
        #endregion Doctor Details

        #region Doctor day Schedule 
        /// <summary>
        /// Get Specialties by Business key
        /// UI Reffered - Doctor Day Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSpecialtiesByBusinessKey(int businessKey)
        {
            var specialties = await _DoctorMasterRepository.GetSpecialtiesByBusinessKey(businessKey);
            return Ok(specialties);
        }
        /// <summary>
        /// Get Clinic And Consultation Type by Specialty and Business Key
        /// UI Reffered - Doctor Day Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetClinicAndConsultationTypebySpecialty(int businessKey, int specialtyId)
        {
            var clinics = await _DoctorMasterRepository.GetClinicAndConsultationTypebySpecialty(businessKey, specialtyId);
            return Ok(clinics);
        }
        /// <summary>
        /// Get Doctors by Business Key,Specialty,Clinics and Consultation
        /// UI Reffered -Doctor Day Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorsbySpecialtyClinicAndConsultation(int businessKey, int specialtyId, int clinicId, int consultationId)
        {
            var doctors = await _DoctorMasterRepository.GetDoctorsbySpecialtyClinicAndConsultation(businessKey, specialtyId, clinicId, consultationId);
            return Ok(doctors);
        }

        /// <summary>
        /// Get Doctor day Schedule by Search Criteria
        /// UI Reffered -Doctor Day Schedule,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctordaySchedulebySearchCriteria(int businessKey, int specialtyId, int clinicId, int consultationId, int doctorId, DateTime scheduleFromDate, DateTime scheduleToDate)
        {
            var doctors = await _DoctorMasterRepository.GetDoctordaySchedulebySearchCriteria(businessKey, specialtyId, clinicId, consultationId, doctorId, scheduleFromDate, scheduleToDate);
            return Ok(doctors);
        }

        /// <summary>
        /// Insert into Doctor day Schedule
        /// UI Reffered - Doctor day Schedule,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctordaySchedule(DO_DoctordaySchedule obj)
        {
            var msg = await _DoctorMasterRepository.InsertIntoDoctordaySchedule(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update into Doctor day Schedule
        /// UI Reffered - Doctor day Schedule,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDoctordaySchedule(DO_DoctordaySchedule obj)
        {
            var msg = await _DoctorMasterRepository.UpdateDoctordaySchedule(obj);
            return Ok(msg);
        }

        /// <summary>
        ///Active/D-ACtive Doctor day Schedule
        /// UI Reffered - Doctor day Schedule,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActiveDoctordaySchedule(DO_DoctordaySchedule objdel)
        {
            var msg = await _DoctorMasterRepository.ActiveOrDeActiveDoctordaySchedule(objdel);
            return Ok(msg);
        }

        /// <summary>
        /// Import Excel file as Doctor day Schedule
        /// UI Reffered -Doctor day Schedule
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ImpotedDoctorScheduleList(List<DO_DoctordaySchedule> obj)
        {
            var msg = await _DoctorMasterRepository.ImpotedDoctorScheduleList(obj);
            return Ok(msg);

        }
        #endregion

        #region Doctor Profilr Business Link
        /// <summary>
        /// Get Doctor Business Link Data
        /// UI Reffered - Doctor Business Link,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorBusinessLinkList(int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetDoctorBusinessLinkList(doctorId);
            return Ok(msg);
        }

        /// <summary>
        /// Insert/ Update into Doctor Business Link Table
        /// UI Reffered - Doctor Business Link,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateDoctorBusinessLink(List<DO_DoctorBusinessLink> obj)
        {
            var msg = await _DoctorMasterRepository.InsertOrUpdateDoctorBusinessLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Doctor Business Link Data
        /// UI Reffered - Doctor Business Link,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorLinkWithBusinessLocation(int doctorId)
        {
            var msg = await _DoctorMasterRepository.GetDoctorLinkWithBusinessLocation(doctorId);
            return Ok(msg);
        }
        #endregion

        #region Doctor Profile Image
        /// <summary>
        /// Insert Or Update into Doctor Doctor Profile Image
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctorProfileImage(DO_DoctorImage obj)
        {
            var msg = await _DoctorMasterRepository.InsertIntoDoctorProfileImage(obj);
            return Ok(msg);
        }

        /// <summary>
        ///Get Image & Signature by doctor Id
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorProfileImagebyDoctorId(int doctorId)
        {
            var _imgs = await _DoctorMasterRepository.GetDoctorProfileImagebyDoctorId(doctorId);
            return Ok(_imgs);
        }
        #endregion

        #region Doctor Statutory Details
        /// <summary>
        ///Get Doctor Statutory Details by ISD Code
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorStatutoryDetails(int doctorId, int isdCode)
        {
            var _stdetails = await _DoctorMasterRepository.GetDoctorStatutoryDetails(doctorId, isdCode);
            return Ok(_stdetails);
        }

        /// <summary>
        /// Insert Or Update into Doctor Statutory Details
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateDoctorStatutoryDetails(List<DO_DoctorStatutoryDetails> obj)
        {
            var msg = await _DoctorMasterRepository.InsertOrUpdateDoctorStatutoryDetails(obj);
            return Ok(msg);
        }

        ///Get ISD by Business Key
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetISDCodesbyBusinessKey(int businessKey)
        {
            var Isd = await _DoctorMasterRepository.GetISDCodesbyBusinessKey(businessKey);
            return Ok(Isd);
        }

        ///Get ISD by Doctor Id
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpGet]
        public IActionResult GetISDCodesbyDoctorId(int doctorId)
        {
            var Isd =  _DoctorMasterRepository.GetISDCodesbyDoctorId(doctorId);
            return Ok(Isd);
        }
        #endregion

        #region Doctor Profile Consultation Rates
        /// <summary>
        ///Get Doctor  Consultation Rates
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorProfileConsultationRatebyDoctorId(int businessKey, int clinictype, string currencycode, int ratetype, int doctorId)
        {
            var _stdetails = await _DoctorMasterRepository.GetDoctorProfileConsultationRatebyDoctorId(businessKey, clinictype, currencycode, ratetype, doctorId);
            return Ok(_stdetails);
        }

        /// <summary>
        /// Insert Or Update into Doctor  Consultation Rates
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateDoctorProfileConsultationRate(List<DO_DoctorProfileConsultationRate> obj)
        {
            var msg = await _DoctorMasterRepository.AddOrUpdateDoctorProfileConsultationRate(obj);
            return Ok(msg);
        }
        #endregion

        #region Doctor Profile Address
        /// <summary>
        ///Get STATES bY ISD Codes 
        /// UI Reffered - Doctor Profile Address,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetStatesbyIsdCode(int Isdcode)
        {
            var states = await _DoctorMasterRepository.GetStatesbyIsdCode(Isdcode);
            return Ok(states);
        }

        /// <summary>
        ///Get CITIES bY STATE Code
        /// UI Reffered - Doctor Profile Address,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetCitiesbyStateCode(int Isdcode, int statecode)
        {
            var cities = await _DoctorMasterRepository.GetCitiesbyStateCode(Isdcode, statecode);
            return Ok(cities);
        }

        /// <summary>
        ///Get Zip Code bY City Code 
        /// UI Reffered - Doctor Profile Address,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetZipDescriptionbyCityCode(int Isdcode, int statecode, int citycode)
        {
            var zipcodes = await _DoctorMasterRepository.GetZipDescriptionbyCityCode(Isdcode, statecode, citycode);
            return Ok(zipcodes);
        }

        /// <summary>
        ///Get Zip Code bY serial number 
        /// UI Reffered - Doctor Profile Address,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetZipCodeAndArea(int Isdcode, int statecode, int citycode, int zipserialno)
        {
            var zipcodes = await _DoctorMasterRepository.GetZipCodeAndArea(Isdcode, statecode, citycode, zipserialno);
            return Ok(zipcodes);
        }
        /// <summary>
        ///Get Zip Code bY Area
        /// UI Reffered - Doctor Profile Address,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> FillCoumbosbyZipCode(int Isdcode, string zipcode)
        {
            var area= await _DoctorMasterRepository.FillCoumbosbyZipCode(Isdcode, zipcode);
            return Ok(area);
        }

        
        /// <summary>
        ///Get Doctor Address  bY doctorId 
        /// UI Reffered - Doctor Profile Address,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDoctorAddressDoctorId(int Isdcode, int doctorId, int businesskey)
        {
            var zipcodes = await _DoctorMasterRepository.GetDoctorAddressDoctorId(Isdcode, doctorId, businesskey);
            return Ok(zipcodes);
        }
        /// <summary>
        /// Insert Or Update into Doctor  Address
        /// UI Reffered - Doctor Profile Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateIntoDoctorProfileAddress(DO_DoctorProfileAddress obj)
        {
            var msg = await _DoctorMasterRepository.InsertOrUpdateIntoDoctorProfileAddress(obj);
            return Ok(msg);
        }
        #endregion
    }
}
