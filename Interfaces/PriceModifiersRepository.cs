using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface PriceModifiersRepository
    {
        Task<PriceModifiers?> GetAsyncById(int id);
        Task<IEnumerable<PriceModifiers>> GetAllAsync();
        Task Add(PriceModifiers priceModifiers);
        Task UpdateAsync(PriceModifiers priceModifiers);
        Task DeleteAsync(PriceModifiers priceModifiers);
        Task SaveChangeAsync();
    }
}
