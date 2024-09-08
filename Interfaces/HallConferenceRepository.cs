using ABP_RoomBookingApp.Model;

namespace ABP_RoomBookingApp.Interfaces
{
    public interface HallConferenceRepository
    {
        Task<HallConference?> GetAsyncById(int id);
        Task<IEnumerable<HallConference>> GetAllAsync();
        Task Add(HallConference hallConference);
        Task UpdateAsync(HallConference hallConference);
        Task DeleteAsync(HallConference hallConference);
        Task SaveChangeAsync();
    }
}
