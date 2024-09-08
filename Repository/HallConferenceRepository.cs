using ABP_RoomBookingApp.Data;
using ABP_RoomBookingApp.Interfaces;
using ABP_RoomBookingApp.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ABP_RoomBookingApp.Repository
{
    public class HallConferenceRepository : Interfaces.HallConferenceRepository
    {
        private ApplicationDB _context;

        public HallConferenceRepository(ApplicationDB applicationDB) 
        {
            _context = applicationDB;
        }
        public Task<IEnumerable<HallConference>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HallConference?> GetAsyncById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateAsync(HallConference hallConference)
        {
             _context.Update(hallConference);
             await SaveChangeAsync();
        }
        public async Task Add(HallConference hallConference)
        {
            _context.Add(hallConference);
            await SaveChangeAsync();
        }

        public async Task DeleteAsync(HallConference hallConference)
        {
            _context.Remove(hallConference);
            await SaveChangeAsync();
        }
    }
}
