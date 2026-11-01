
using MovieTicketBooking.DTOs.Theatres;
using MovieTicketBooking.Models;
using MovieTicketBooking.Repositories.Interfaces;
using MovieTicketBooking.Services.Interfaces;

namespace MovieTicketBooking.Services
{
    public class TheatreService : ITheatreService
    {
        private readonly ITheatreRepository _theatreRepository;

        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }

        // Get all theatres
        public async Task<List<TheatreResponse>> GetAllAsync()
        {
            var theatres = await _theatreRepository.GetAllAsync();

            var response = theatres.Select(theatre => new TheatreResponse
            {
                TheatreId = theatre.TheatreId,
                Name = theatre.Name,
                Location = theatre.Location
            }).ToList();

            return response;
        }

        // Get theatre by ID
        public async Task<TheatreResponse?> GetByIdAsync(int id)
        {
            var theatre = await _theatreRepository.GetByIdAsync(id);

            if (theatre == null)
            {
                return null;
            }

            var response = new TheatreResponse
            {
                TheatreId = theatre.TheatreId,
                Name = theatre.Name,
                Location = theatre.Location
            };

            return response;
        }

        // Create new theatre
        public async Task<TheatreResponse> CreateAsync(
            CreateTheatreRequest request)
        {
            var theatre = new Theatre
            {
                Name = request.Name,
                Location = request.Location
            };

            var createdTheatre =
                await _theatreRepository.AddAsync(theatre);

            var response = new TheatreResponse
            {
                TheatreId = createdTheatre.TheatreId,
                Name = createdTheatre.Name,
                Location = createdTheatre.Location
            };

            return response;
        }

        // Update existing theatre
        public async Task<TheatreResponse?> UpdateAsync(
            int id,
            UpdateTheatreRequest request)
        {
            var theatre = await _theatreRepository.GetByIdAsync(id);

            if (theatre == null)
            {
                return null;
            }

            theatre.Name = request.Name;
            theatre.Location = request.Location;

            await _theatreRepository.UpdateAsync(theatre);

            var response = new TheatreResponse
            {
                TheatreId = theatre.TheatreId,
                Name = theatre.Name,
                Location = theatre.Location
            };

            return response;
        }

        // Delete theatre
        public async Task<bool> DeleteAsync(int id)
        {
            var theatre = await _theatreRepository.GetByIdAsync(id);

            if (theatre == null)
            {
                return false;
            }

            await _theatreRepository.DeleteAsync(theatre);

            return true;
        }
    }
}
