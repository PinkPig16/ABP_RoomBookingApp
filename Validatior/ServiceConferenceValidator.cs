using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Validatior
{
    public class ServiceConferenceValidator : Interfaces.ServiceConferenceValidator
    {
        public bool Validate(ServiceConference serviceConference, out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(serviceConference.Name) || serviceConference.Name.Length > 100)
            {
                errors.Add("Invalid Service name.");
            }

            return errors.Count == 0;
        }
    }
}
