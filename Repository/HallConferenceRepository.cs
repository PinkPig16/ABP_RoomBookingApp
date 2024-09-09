using ABP_ConferenceBookingApp.Data;
using ABP_ConferenceBookingApp.Interfaces;
using ABP_ConferenceBookingApp.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ABP_ConferenceBookingApp.Repository
{
    public class HallConferenceRepository : Interfaces.HallConferenceRepository
    {
        private ApplicationDB _context;

        public HallConferenceRepository(ApplicationDB applicationDB) 
        {
            _context = applicationDB;
        }
        public async Task<IEnumerable<HallConference>> GetAllAsync()
        {
            return await _context.HallConferences.ToListAsync();
        }

        public async Task<HallConference?> GetAsyncById(int id)
        {
            return await _context.HallConferences.Include(x => x.ServiceConferences).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<HallConference?> GetAsync(HallConference hallConference)
        {
            return await _context.HallConferences.FirstOrDefaultAsync(x => x.Name == hallConference.Name && 
                                    x.Capacity == hallConference.Capacity && x.Price == hallConference.Price);
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

        public async Task<bool> UpdateAsync(HallConference hallConference)
        {
             _context.Update(hallConference);
             return await SaveChangeAsync();
        }
        public async Task<bool> Add(HallConference hallConference)
        {
            _context.Add(hallConference);
           return await SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(HallConference hallConference)
        {
            _context.Remove(hallConference);
            return await SaveChangeAsync();
        }
    }
}
