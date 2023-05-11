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
    public class CommonMethodController : ControllerBase
    {
        private readonly ICommonDataRepository _commonDataRepository;
        public CommonMethodController(ICommonDataRepository commonDataRepository)
        {
            _commonDataRepository = commonDataRepository;
        }
        public async Task<IActionResult> GetBusinessKey()
        {
            var ac = await _commonDataRepository.GetBusinessKey();
            return Ok(ac);
        }
        public async Task<IActionResult> GetApplicationCodesByCodeType(int codetype)
        {
            var ac = await _commonDataRepository.GetApplicationCodesByCodeType(codetype);
            return Ok(ac);
        }
        public async Task<IActionResult> GetCurrencyCodes()
        {
            var ac = await _commonDataRepository.GetCurrencyCodes();
            return Ok(ac);
        }
    }
}