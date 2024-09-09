using ABP_ConferenceBookingApp.Data;
using ABP_ConferenceBookingApp.Model;
using ABP_ConferenceBookingApp.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace ABP_ConferenceBookingApp.Repository
{
    public class BookingHallRepository : Interfaces.BookingHallRepository
    {
        private ApplicationDB _context;

        public BookingHallRepository(ApplicationDB applicationDB)
        {
            _context = applicationDB;
        }
        public async Task<IEnumerable<BookingHall>> GetAllAsync()
        {
            return await _context.BookingHalls.ToListAsync();
        }

        public async Task<BookingHall?> GetAsyncById(int id)
        {
            return await _context.BookingHalls.Include(x => x.ServiceConferences).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(BookingHall bookingHall)
        {
            _context.Update(bookingHall);
            return await SaveChangeAsync();
        }
        public async Task<bool> Add(BookingHall bookingHall)
        {
            _context.Add(bookingHall);
            return await SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(BookingHall bookingHall)
        {
            _context.Remove(bookingHall);
            return await SaveChangeAsync();
        }
        public async Task<IEnumerable<HallConference>> GetAvailableHalls(HallSearchCriteriaDto dto)
        {
            var availableHalls = await _context.HallConferences
                            .Where(h => h.Capacity >= dto.Capacity)
                            .Where(h => !_context.BookingHalls
                            .Any(b => b.hallConference.Id == h.Id
                                        && b.BookingDate == dto.Date
                                        && b.StartTime < dto.EndTime
                                        && b.EndTime > dto.StartTime))
                                            .ToListAsync();

            return availableHalls;
        }
    }

}
