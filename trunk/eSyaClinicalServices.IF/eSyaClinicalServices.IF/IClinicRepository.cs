using HCP.ClinicalServices.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.ClinicalServices.IF
{
    public interface IClinicRepository
    {
        Task<DO_ReturnParameter> InsertUpdateOPClinicLink(List<DO_OPClinic> obj);

        Task<List<DO_OPClinic>> GetClinicConsultantIdList(int businessKey);

        Task<List<DO_DoctorClinic>> GetDoctorClinicLinkList(int businessKey, int specialtyId, int doctorId);

        Task<List<DO_DoctorClinic>> GetDoctorClinicLinkListbyClinicConsultation(int businessKey, int clinicId, int consultationId);

        Task<DO_ReturnParameter> InsertUpdateDoctorClinicLink(List<DO_DoctorClinic> obj);

        Task<List<DO_ClinicRoom>> GetClinicRoomListByBKeyFloorId(int businessKey, int floorId);

        Task<DO_ReturnParameter> InsertIntoClinicRoomMaster(DO_ClinicRoom obj);

        Task<DO_ReturnParameter> UpdateClinicRoomMaster(DO_ClinicRoom obj);
        

        #region CliniccServiceLink

        Task<List<DO_ClinicServiceLink>> GetClinicServiceLinkByBKey(int businessKey);

        Task<List<DO_ApplicationCode>> GetConsultationTypeByBKeyClinicType(int businessKey, int clinictype);

        Task<List<DO_ServiceCode>> GetServicesPerformedByDoctor();

        Task<DO_ReturnParameter> AddClinicServiceLink(DO_ClinicServiceLink obj);

        #endregion

        #region ClinicVisitRate

        Task<List<DO_ClinicVisitRate>> GetClinicVisitRateByBKeyClinicTypeCurrCodeRateType(int businessKey, int clinictype, string currencycode, int ratetype);

        Task<DO_ReturnParameter> AddOrUpdateClinicVisitRate(List<DO_ClinicVisitRate> obj);
        
        #endregion
    }
}
