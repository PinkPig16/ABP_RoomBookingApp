using ABP_ConferenceBookingApp.Model.DTO;
using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface HallConferenceValidator
    {
        bool ValidateCreateHall(HallConference hallConference, out List<string> errors);
    }
}
