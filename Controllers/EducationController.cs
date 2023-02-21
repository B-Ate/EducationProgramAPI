using educationprogramAPI.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace educationprogramAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly ILogger<EducationController> _logger;
        private readonly IMediator _mediator;

        public EducationController(IMediator mediator, ILogger<EducationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddProgram")]
        public async Task<IActionResult> AddEducationProgram(AddProgramRequest request)
        {
            var result = await this._mediator.Send(request);
            
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddEducation")]
        public async Task<IActionResult> AddEducationToProgram(AddEducationRequest request)
        {
            var result = await this._mediator.Send(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetPrograms")]
        public async Task<IActionResult> GetEducationProgram()
        {
            GetProgramsRequest request = new GetProgramsRequest();
            var result = await this._mediator.Send(request);
            
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetProgramwithId")]
        public async Task<IActionResult> GetEducationProgram(GetProgramWithIdRequest request)
        {
            var result = await this._mediator.Send(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
