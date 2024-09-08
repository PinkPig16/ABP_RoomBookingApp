using ABP_RoomBookingApp.Data;
using ABP_RoomBookingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_RoomBookingApp.Repository
{
    public class PriceModifiersRepository : Interfaces.PriceModifiersRepository
    {
        private ApplicationDB _context;

        public PriceModifiersRepository(ApplicationDB applicationbDB) 
        {
            _context = applicationbDB;
        }
        public Task<IEnumerable<PriceModifiers>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PriceModifiers?> GetAsyncById(int id)
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
