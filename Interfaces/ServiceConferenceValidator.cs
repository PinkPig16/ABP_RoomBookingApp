using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface ServiceConferenceValidator
    {
        bool Validate(ServiceConference serviceConference, out List<string> errors);
    }
}
