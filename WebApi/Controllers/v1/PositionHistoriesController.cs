using Application.Features.PositionHistories.Commands.CreatePositionHistoryCommand;
using Application.Features.PositionHistories.Commands.DeletePositionHistoryCommand;
using Application.Features.PositionHistories.Commands.UpdatePositionHistoryCommand;
using Application.Features.PositionHistories.Queries.GetAllPositionHistories;
using Application.Features.PositionHistories.Queries.GetPositionHistoryById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PositionHistoriesController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllPositionHistoriesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllPositionHistoriesQuery { 
                PageNumber = filter.PageNumber, PageSize = filter.PageSize,
                EmployeeId = filter.EmployeeId, Position = filter.Position  
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPositionHistoryByIdQuery { Id = id }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePositionHistoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdatePositionHistoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePositionHistoryCommand { Id = id }));
        }
    }
}
