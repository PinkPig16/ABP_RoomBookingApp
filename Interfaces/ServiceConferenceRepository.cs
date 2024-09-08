using ABP_RoomBookingApp.Model;

namespace ABP_RoomBookingApp.Interfaces
{
    public interface ServiceConferenceRepository
    {
        Task<ServiceConference?> GetAsyncById(int id);
        Task<IEnumerable<ServiceConference>> GetAllAsync();
        Task Add(ServiceConference serviceConference);
        Task UpdateAsync(ServiceConference serviceConference);
        Task DeleteAsync(ServiceConference serviceConference);
        Task SaveChangeAsync();
    }
}
