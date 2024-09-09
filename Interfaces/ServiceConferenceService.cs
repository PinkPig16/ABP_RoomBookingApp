using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface ServiceConferenceService
    {
        Task<List<ServiceConference>> CheckServiceConference(ICollection<ServiceConference> serviceConference);
    }
}
