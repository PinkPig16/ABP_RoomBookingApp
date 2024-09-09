
using ABP_ConferenceBookingApp.Interfaces;
using ABP_ConferenceBookingApp.Model;
using ABP_ConferenceBookingApp.Model.DTO;

namespace ABP_ConferenceBookingApp.Service
{
    public class BookingHallService : Interfaces.BookingHallService
    {
        private readonly HallConferenceRepository _hallRepository;
        private readonly BookingHallRepository _bookingHallRepository;
        private readonly BookingHallValidator _bookingHallValidator;
        private readonly PriceModifiersRepository _priceModifiersRepository;

        public BookingHallService(HallConferenceRepository hallConferenceRepository,
                                     BookingHallValidator bookingHallValidator,
                                     BookingHallRepository bookingHallRepository,
                                     PriceModifiersRepository priceModifiersRepository)
        {
            _hallRepository = hallConferenceRepository;
            _bookingHallRepository = bookingHallRepository;
            _bookingHallValidator = bookingHallValidator;
            _priceModifiersRepository = priceModifiersRepository;

        }
        public async Task<IEnumerable<HallConference>> GetHallsAsync(HallSearchCriteriaDto dto)
        {
            return await _bookingHallRepository.GetAvailableHalls(dto);
        }
        public async Task<Decimal> BookingHall(BookingHall bookingHall)
        {
            if (!_bookingHallValidator.ValidateBookingHall(bookingHall, out var errors))
            {
                throw new ArgumentException(string.Join(", ", errors));
            }

            var findBooking = await _bookingHallRepository.GetAsyncById(bookingHall.Id);
            var totalPrice = await CalculatePrice(bookingHall);
            bookingHall.TotalPrice = totalPrice;
            if (findBooking == null)
            {
                await _bookingHallRepository.Add(bookingHall);
            }else
            {
                await _bookingHallRepository.UpdateAsync(bookingHall);
            }
            return totalPrice;    
        }

        public async Task<Decimal> CalculatePrice(BookingHall bookingHall)
        {
            var priceTime = await _priceModifiersRepository.GetAllAsync();
            var priceBookingList = priceTime.Where(x => (x.dateStart <= bookingHall.StartTime && x.dateEnd >= bookingHall.StartTime) ||
            (x.dateEnd >= bookingHall.EndTime))
                .OrderBy(x => x.dateStart).ToList();

            Decimal TotalPrice = 0;
            int hourRent = bookingHall.EndTime.Hour - bookingHall.StartTime.Hour;
            foreach(var price in priceBookingList)
            {
                var currentHour = Math.Min(price.dateEnd.Hour - bookingHall.StartTime.Hour,hourRent);
                hourRent -= currentHour;
                TotalPrice += (decimal)price.Discount * (bookingHall.hallConference.Price * currentHour);
            }
            foreach (var service in bookingHall.ServiceConferences) 
            {
                TotalPrice += service.Price;
            }
            return TotalPrice;
        }
    }
}