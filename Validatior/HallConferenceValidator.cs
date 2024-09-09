using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Validatior
{
    public class HallConferenceValidator : Interfaces.HallConferenceValidator
    {
        public bool ValidateCreateHall(HallConference hallConference, out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(hallConference.Name) || hallConference.Name.Length > 100)
            {
                errors.Add("Invalid conference hall name.");
            }

            if (hallConference.Capacity <= 0)
            {
                errors.Add("Capacity must be greater than 0.");
            }

            if (hallConference.Price <= 0)
            {
                errors.Add("Price must be greater than 0.");
            }

            return errors.Count == 0;
        }
    }
}
