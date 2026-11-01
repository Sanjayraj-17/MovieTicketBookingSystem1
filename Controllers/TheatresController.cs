
using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.DTOs.Theatres;
using MovieTicketBooking.Services.Interfaces;

namespace MovieTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatresController : ControllerBase
    {
        private readonly ITheatreService _theatreService;

        public TheatresController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        // GET: api/theatres
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var theatres = await _theatreService.GetAllAsync();

            return Ok(theatres);
        }

        // GET: api/theatres/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var theatre = await _theatreService.GetByIdAsync(id);

            if (theatre == null)
            {
                return NotFound("Theatre not found");
            }

            return Ok(theatre);
        }

        // POST: api/theatres
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateTheatreRequest request)
        {
            var theatre = await _theatreService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = theatre.TheatreId },
                theatre
            );
        }

        // PUT: api/theatres/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateTheatreRequest request)
        {
            var theatre = await _theatreService.UpdateAsync(id, request);

            if (theatre == null)
            {
                return NotFound("Theatre not found");
            }

            return Ok(theatre);
        }

        // DELETE: api/theatres/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _theatreService.DeleteAsync(id);

            if (!result)
            {
                return NotFound("Theatre not found");
            }

            return NoContent();
        }
    }
}

