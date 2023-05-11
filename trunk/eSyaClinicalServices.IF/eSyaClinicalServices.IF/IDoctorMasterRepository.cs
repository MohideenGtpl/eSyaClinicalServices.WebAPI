using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCP.ClinicalServices.DO;

namespace HCP.ClinicalServices.IF
{
    public interface IDoctorMasterRepository
    {
        Task<DO_ReturnParameter> InsertIntoDoctorMaster(DO_DoctorMaster obj);

        Task<DO_ReturnParameter> UpdateDoctorMaster(DO_DoctorMaster obj);

        Task<List<DO_DoctorMaster>> GetDoctorMasterList();

        Task<DO_DoctorMaster> GetDoctorMaster(int doctorId);

        Task<List<DO_DoctorMaster>> GetDoctorMasterListForPrefix(string doctorNamePrefix);

        Task<DO_ReturnParameter> ActiveOrDeActiveDoctor(bool status, int doctorId);

        Task<List<DO_DoctorMaster>> GetDoctorMasterBusinessList(int businessKey);

        Task<DO_ReturnParameter> InsertIntoDoctorBusinessLink(List<DO_DoctorMaster> obj);

        Task<List<DO_BusinessLocation>> GetBusinessLocationDoctorList(int doctorId);

        Task<DO_ReturnParameter> InsertIntoBusinessDoctorLink(List<DO_DoctorMaster> obj);

        Task<List<DO_BusinessLocation>> GetDoctorBusinessKey(int doctorId);

        Task<List<DO_BusinessLocation>> GetDoctorLocationbyDoctorId(int doctorId);

        Task<List<DO_SpecialtyDoctorLink>> GetSpecialtyListByDoctorId(int doctorId);

        Task<DO_ReturnParameter> InsertDoctorSpecialtyLink(DO_SpecialtyDoctorLink obj);

        Task<DO_ReturnParameter> UpdateDoctorSpecialtyLink(DO_SpecialtyDoctorLink obj);

        Task<List<DO_SpecialtyDoctorLink>> GetSpecialtyListByBKeyDoctorId(int businessKey, int doctorId);

        #region Doctor Details
        Task<Do_DoctorDetails> GetDoctordetailsbydoctorId(int doctorId);
        Task<DO_ReturnParameter> InsertOrUpdateIntoDoctordetails(Do_DoctorDetails obj);
        #endregion Doctor Details

        #region Doctor day Schedule 

        Task<List<DO_SpecialtyCodes>> GetSpecialtiesByBusinessKey(int businessKey);

        Task<List<DO_DoctorClinic>> GetClinicAndConsultationTypebySpecialty(int businessKey, int specialtyId);

        Task<List<DO_DoctorMaster>> GetDoctorsbySpecialtyClinicAndConsultation(int businessKey, int specialtyId, int clinicId, int consultationId);

        Task<List<DO_DoctordaySchedule>> GetDoctordaySchedulebySearchCriteria(int businessKey, int specialtyId, int clinicId, int consultationId, int doctorId, DateTime scheduleFromDate, DateTime scheduleToDate);

        Task<DO_ReturnParameter> InsertIntoDoctordaySchedule(DO_DoctordaySchedule obj);

        Task<DO_ReturnParameter> UpdateDoctordaySchedule(DO_DoctordaySchedule obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveDoctordaySchedule(DO_DoctordaySchedule objdel);

        Task<DO_ReturnParameter> ImpotedDoctorScheduleList(List<DO_DoctordaySchedule> obj);
        #endregion

        #region Doctor Profilr Business Link
        Task<List<DO_DoctorBusinessLink>> GetDoctorBusinessLinkList(int doctorId);
        Task<DO_ReturnParameter> InsertOrUpdateDoctorBusinessLink(List<DO_DoctorBusinessLink> obj);
        #endregion

        #region Profile Image
        Task<DO_ReturnParameter> InsertIntoDoctorProfileImage(DO_DoctorImage obj);

        Task<DO_DoctorImage> GetDoctorProfileImagebyDoctorId(int doctorId);
        #endregion

        #region Doctor Statutory Details

        Task<List<DO_DoctorStatutoryDetails>> GetDoctorStatutoryDetails(int doctorId, int isdCode);

        Task<DO_ReturnParameter> InsertOrUpdateDoctorStatutoryDetails(List<DO_DoctorStatutoryDetails> obj);

        Task<List<DO_ISDCodes>> GetISDCodesbyBusinessKey(int businessKey);

        List<DO_ISDCodes> GetISDCodesbyDoctorId(int doctorId);
        #endregion

        #region Doctor Profile Consultation Rates
        Task<List<DO_DoctorProfileConsultationRate>> GetDoctorProfileConsultationRatebyDoctorId(int businessKey, int clinictype, string currencycode, int ratetype, int doctorId);

        Task<DO_ReturnParameter> AddOrUpdateDoctorProfileConsultationRate(List<DO_DoctorProfileConsultationRate> obj);
        #endregion

        #region Doctor Profile Address
        Task<List<DO_DoctorProfileAddress>> GetStatesbyIsdCode(int Isdcode);

        Task<List<DO_DoctorProfileAddress>> GetCitiesbyStateCode(int Isdcode, int statecode);

        Task<List<DO_DoctorProfileAddress>> GetZipDescriptionbyCityCode(int Isdcode, int statecode, int citycode);

        Task<DO_DoctorProfileAddress> GetZipCodeAndArea(int Isdcode, int statecode, int citycode, int zipserialno);

        Task<DO_DoctorProfileAddress> FillCoumbosbyZipCode(int Isdcode, string zipcode);

        Task<DO_DoctorProfileAddress> GetDoctorAddressDoctorId(int Isdcode, int doctorId, int businesskey);

        Task<DO_ReturnParameter> InsertOrUpdateIntoDoctorProfileAddress(DO_DoctorProfileAddress obj);

        Task<List<DO_DoctorBusinessLink>> GetDoctorLinkWithBusinessLocation(int doctorId);
        #endregion
    }
}
