using ABP_ConferenceBookingApp.Interfaces;
using ABP_ConferenceBookingApp.Model.DTO;
using ABP_ConferenceBookingApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ABP_ConferenceBookingApp.Service
{
    public class HallConferenceService : Interfaces.HallConferenceService
    {
        private readonly HallConferenceRepository _hallRepository;
        private readonly ServiceConferenceRepository _serviceRepository;
        private readonly HallConferenceValidator _hallValidator;

        public HallConferenceService(HallConferenceRepository hallConferenceRepository,
                                     HallConferenceValidator hallConferenceValidator,
                                     ServiceConferenceRepository serviceConferenceRepository) 
        {
            _hallRepository = hallConferenceRepository;
            _hallValidator = hallConferenceValidator;
            _serviceRepository = serviceConferenceRepository;
        }
        public async Task<int> CreateHallAsync(HallConference hallConference)
        {
            if (!_hallValidator.ValidateCreateHall(hallConference, out var errors))
            {
                throw new ArgumentException(string.Join(", ", errors));
            }
            await _hallRepository.Add(hallConference);

            return hallConference.Id; 
                
        }

        

        public async Task<bool> DeleteHallAsync(int id)
        {
            var hallConference = await _hallRepository.GetAsyncById(id);
            if (hallConference != null)
            {
                await _hallRepository.DeleteAsync(hallConference);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateHallAsync(HallConference hallConference)
        {
            if (!_hallValidator.ValidateCreateHall(hallConference, out var errors))
            {
                throw new ArgumentException(string.Join(", ", errors));
            }
            var updateResult = await _hallRepository.UpdateAsync(hallConference);
            if(updateResult)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
