
using ABP_ConferenceBookingApp.Interfaces;
using ABP_ConferenceBookingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_ConferenceBookingApp.Service
{
    public class ServiceConferenceService : Interfaces.ServiceConferenceService
    {
        private readonly ServiceConferenceRepository _serviceConferenceRepository;

        public ServiceConferenceService(ServiceConferenceRepository serviceConferenceRepository) 
        {
            _serviceConferenceRepository = serviceConferenceRepository;
        }
        public async Task<List<ServiceConference>> CheckServiceConference(ICollection<ServiceConference> serviceConferences)
        {
            var allService = await _serviceConferenceRepository.GetAllAsync();

            var existingServiceConferences = allService
                .Where(a => serviceConferences.Any(s => s.Name == a.Name))
                .ToList();

            var newServiceConferences = serviceConferences
                .Where(s => !allService.Any(a => a.Name == s.Name))
                .ToList();

            // Присоединяем существующие услуги к контексту, чтобы избежать их повторного добавления
            foreach (var existingService in existingServiceConferences)
            {
                _serviceConferenceRepository.SetStatusUnchanged(existingService);
            }
            return existingServiceConferences;
        }
    }
}
