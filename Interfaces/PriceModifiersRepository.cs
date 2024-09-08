using ABP_RoomBookingApp.Model;

namespace ABP_RoomBookingApp.Interfaces
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
