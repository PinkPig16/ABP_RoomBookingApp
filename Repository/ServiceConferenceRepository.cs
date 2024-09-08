using ABP_RoomBookingApp.Data;
using ABP_RoomBookingApp.Interfaces;
using ABP_RoomBookingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_RoomBookingApp.Repository
{
    public class ServiceConferenceRepository : Interfaces.ServiceConferenceRepository
    {
        private ApplicationDB _context;

        public ServiceConferenceRepository(ApplicationDB applicationbDB)
        {
            _context = applicationbDB;
        }
        public Task<IEnumerable<ServiceConference>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceConference?> GetAsyncById(int id)
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

        public async Task UpdateAsync(ServiceConference serviceConference)
        {
            _context.Update(serviceConference);
            await _context.SaveChangesAsync();
            
        }
        public async Task Add(ServiceConference serviceConference)
        {
            _context.Add(serviceConference);
            await SaveChangeAsync();
        }

        public async Task DeleteAsync(ServiceConference serviceConference)
        {
            _context.Remove(serviceConference);
            await SaveChangeAsync();
        }
    }
}
