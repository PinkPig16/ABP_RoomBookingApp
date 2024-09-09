using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface HallConferenceRepository
    {
        Task<HallConference?> GetAsyncById(int id);
        Task<IEnumerable<HallConference>> GetAllAsync();
        Task<bool> Add(HallConference hallConference);
        Task<bool> UpdateAsync(HallConference hallConference);
        Task<bool> DeleteAsync(HallConference hallConference);
        Task<HallConference?> GetAsync(HallConference hallConference);
        Task<bool> SaveChangeAsync();
    }
}
