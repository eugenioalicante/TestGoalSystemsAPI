using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestGoalSystems.Application.Features.Inventories.Commands.CreateInventory;
using TestGoalSystems.Application.Features.Inventories.Commands.DeleteInventory;
using TestGoalSystems.Application.Features.Inventories.Commands.UpdateInventory;
using TestGoalSystems.Application.Features.Inventories.Queries.GetInventoriesList;

namespace TestGoalSystemsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetInventory")]        
        [ProducesResponseType(typeof(IEnumerable<InventoriesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InventoriesVm>>> GetVideosByUsername(string username)
        {
            var query = new GetInventoriesListQuery(username);
            var inventories = await _mediator.Send(query);
            return Ok(inventories);
        }

        [HttpPost(Name = "CreateInventory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateInventoryCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateInventory")]
        [ProducesResponseType((int)StatusCodes.Status204NoContent)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpdateInventory([FromBody] UpdateInventoryCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteInventory")]
        [ProducesResponseType((int)StatusCodes.Status204NoContent)]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> DeleteInventory(int id)
        {
            var command = new DeleteInventoryCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
