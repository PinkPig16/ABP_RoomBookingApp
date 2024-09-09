using ABP_ConferenceBookingApp.Data;
using ABP_ConferenceBookingApp.Interfaces;
using ABP_ConferenceBookingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_ConferenceBookingApp.Repository
{
    public class ServiceConferenceRepository : Interfaces.ServiceConferenceRepository
    {
        private ApplicationDB _context;

        public ServiceConferenceRepository(ApplicationDB applicationbDB)
        {
            _context = applicationbDB;
        }
        public async Task<IEnumerable<ServiceConference>> GetAllAsync()
        {
            return await _context.serviceConferences.ToListAsync();
        }

        public async Task<ServiceConference?> GetAsyncById(int id)
        {
            return await _context.serviceConferences.FirstOrDefaultAsync(x => x.Id == id);
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

        public  void SetStatusUnchanged(ServiceConference serviceConference)
        {
            var trackedEntity = _context.serviceConferences.Local.FirstOrDefault(e => e.Id == serviceConference.Id);

            if (trackedEntity == null)
            {

                _context.serviceConferences.Attach(serviceConference);
            }
            _context.Entry(serviceConference).State = EntityState.Unchanged;
        }

    }
}
