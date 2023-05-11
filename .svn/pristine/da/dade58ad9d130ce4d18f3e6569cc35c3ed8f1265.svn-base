using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HCP.ClinicalServices.IF;
using HCP.ClinicalServices.DO;

namespace HCP.ClinicalServices.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecialtyUnitsController : ControllerBase
    {
        private readonly ISpecialtyUnitsRepository _SpecialtyUnitsRepository;

        public SpecialtyUnitsController(ISpecialtyUnitsRepository specialtyUnitsRepository)
        {
            _SpecialtyUnitsRepository = specialtyUnitsRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetSpecialtyListByBusinessKey(int businessKey)
        {
            var msg = await _SpecialtyUnitsRepository.GetSpecialtyListByBusinessKey(businessKey);
            return Ok(msg);
        }


        [HttpGet]
        public async Task<IActionResult> GetUnitsValidityBySpecialty(int businessKey, int specialtyId)
        {
            var msg = await _SpecialtyUnitsRepository.GetUnitsValidityBySpecialty(businessKey,specialtyId);
            return Ok(msg);
        }

        public async Task<IActionResult> InsertSpecialtyUnitsValidity(DO_SpecialtyUnit obj)
        {
            var msg = await _SpecialtyUnitsRepository.InsertSpecialtyUnitsValidity(obj);
            return Ok(msg);
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecialtyIPInfo(int businessKey, int specialtyId)
        {
            var msg = await _SpecialtyUnitsRepository.GetSpecialtyIPInfo(businessKey, specialtyId);
            return Ok(msg);
        }

        public async Task<IActionResult> AddOrUpdateSpecialtyIPInfo(DO_SpecialtyUnit obj)
        {
            var msg = await _SpecialtyUnitsRepository.AddOrUpdateSpecialtyIPInfo(obj);
            return Ok(msg);
        }

    }
}
