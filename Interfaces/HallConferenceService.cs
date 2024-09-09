using ABP_ConferenceBookingApp.Model.DTO;
using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface HallConferenceService
    {
        Task<int> CreateHallAsync(HallConference hallConference);
        Task<bool> DeleteHallAsync(int id);
        Task<bool> UpdateHallAsync(HallConference hallConference);
    }
}
