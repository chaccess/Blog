using Api.ViewModels;
using AutoMapper;
using Main.Queries;
using Main.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace blog_app.Controllers
{
    [ApiController]
    [Route("records")]
    public class RecordsController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost(Name = "SaveRecord")]
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