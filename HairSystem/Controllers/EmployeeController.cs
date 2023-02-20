using Microsoft.AspNetCore.Mvc;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Repository.Interfaces;
using Hair.Application.Extensions;
using Hair.Application.Interfaces;
using Hair.Application.Common;
using System.Reflection.Metadata.Ecma335;

namespace HairSystem.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly VisualizeEmployeeDataService _getEmployeeData;

        public EmployeeController(VisualizeEmployeeDataService getEmployeeData)
        {
            _getEmployeeData = getEmployeeData;
        }

        [HttpGet]
        [Route("VisualizeEmployeeData")]
        public IActionResult Visualize([FromBody] VisualizeEmployeeDataDto dataDto)
        {
            var result = _getEmployeeData.GetEmployeeData(dataDto.Email, dataDto.Password);
            return StatusCode(result._StatusCode, result._Message == null ? new { Message = result._Message } : result._Data);
        }
    }
}
