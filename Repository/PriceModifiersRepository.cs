using ABP_ConferenceBookingApp.Data;
using ABP_ConferenceBookingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_ConferenceBookingApp.Repository
{
    public class PriceModifiersRepository : Interfaces.PriceModifiersRepository
    {
        private ApplicationDB _context;

        public PriceModifiersRepository(ApplicationDB applicationbDB) 
        {
            _context = applicationbDB;
        }
        public async Task<IEnumerable<PriceModifiers>> GetAllAsync()
        {
            return await _context.PriceModifiers.OrderBy(x => x.dateStart).ToListAsync();
        }

        public async Task<PriceModifiers?> GetAsyncById(int id)
        {
            return await _context.PriceModifiers.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task UpdateAsync(PriceModifiers priceModifiers)
        {
            _context.Update(priceModifiers);
            await SaveChangeAsync();
        }
        public async Task Add(PriceModifiers priceModifiers)
        {
            _context.Add(priceModifiers);
            await SaveChangeAsync(); 
        }

        public async Task DeleteAsync(PriceModifiers priceModifiers)
        {
            _context.Remove(priceModifiers);
            await _context.SaveChangesAsync();
        }
    }
}
