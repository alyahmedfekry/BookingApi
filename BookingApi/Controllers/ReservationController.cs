using MediatR;
using Microsoft.AspNetCore.Mvc;
using BookingApi.Commands;
using BookingApi.Queries;
using System.ComponentModel.DataAnnotations.Schema;
using BookingApi.Commands.AddNewReservation;
using BookingApi.Commands.UpdateReservation;
using BookingApi.Commands.DeleteReservation;

namespace BookingApi.Controllers
{
    [ApiController]
    [Route("bookingapi/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllReservationsQuery());
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var query = new GetReservationByIdQuery(id);
            var result= await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);  
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] AddNewReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Update([FromBody] UpdateReservationCommand command)
        {
            var result=await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteReservationCommand(id);
            var result=  await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
