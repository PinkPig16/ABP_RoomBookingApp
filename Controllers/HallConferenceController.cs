using ABP_ConferenceBookingApp.Model.DTO;
using ABP_ConferenceBookingApp.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ABP_ConferenceBookingApp.Interfaces;

namespace ABP_ConferenceBookingApp.Controllers
{
    [ApiController]
    [Route("api/Hall")]
    public class HallConferenceController : Controller
    {
        private readonly HallConferenceService _hallService;
        private readonly IMapper _mapper;
        private readonly ServiceConferenceService _serviceConferenceService;

        public HallConferenceController(HallConferenceService hallService, IMapper mapper,
                                        ServiceConferenceService serviceConferenceService) 
        {
            _hallService = hallService;
            _mapper = mapper;
            _serviceConferenceService = serviceConferenceService;
        } 
        [HttpPost]
        public async Task<IActionResult> AddHall([FromBody] HallConferenceDto dto)
        {
            var hallConference = _mapper.Map<HallConference>(dto);

            //Избавление от дублей 
            if (hallConference.ServiceConferences != null) 
            {   
                hallConference.ServiceConferences = await _serviceConferenceService.CheckServiceConference(hallConference.ServiceConferences);
                
            }

            var id = await _hallService.CreateHallAsync(hallConference);

            return Ok(new { id, Message = "Conference hall successfully created." });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHall([FromQuery] int id, [FromBody] HallConferenceDto dto)
        {
            var hallConference = _mapper.Map<HallConference>(dto);
            hallConference.Id = id;
            var update = await _hallService.UpdateHallAsync(hallConference);
            if (update)
            {
                return Ok(new {Message = "Conference hall successfully update" });
            }
            else
            {
                return NotFound(new {Message = "Conference hall not found" });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHall([FromQuery] int id)
        {
            var deleted = await _hallService.DeleteHallAsync(id);
            if (deleted)
            {
                return Ok(new { id, Message = "Conference hall successfully deleted" });
            }
            else
            {
                return NotFound(new { id, Message = "Conference hall not found" });
            }
        }
    }
}
