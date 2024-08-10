using Api.ViewModels;
using AutoMapper;
using Main.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Authorization;
using Main.Api.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace blog_app.Controllers
{
    [ApiController]
    [Route("records")]
    public class RecordsController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost("SaveRecord")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SaveRecord([FromBody] RecordViewModel viewModel)
        {
            if (viewModel is null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<SaveRecordCommand>(viewModel);

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
