using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hotel.Controllers;


[ApiController]
[Route("Api/ScheduleController")]

public class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;
    private readonly IScheduleRepository _Schedule;

    public ScheduleController(ILogger<ScheduleController> logger, IScheduleRepository Schedule)
    {
        _logger = logger;
        _Schedule = Schedule;
    }
    [HttpGet]
    public async Task<ActionResult<List<ScheduleDTO>>> GetAllUsers()
    {
        var usersList = await _Schedule.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpPost]
    public async Task<ActionResult<ScheduleDTO>> CreateSchedule([FromBody] ScheduleCreateDTO Data)
    {
        var toCreateSchedule = new Schedule
        {
            ScheduleId = Data.ScheduleId,
            RoomId = Data.RoomId,
            GuestId = Data.GuestId,
            CheckIn = Data.CheckIn,
            CheckOut = Data.CheckOut,
            GuestCount = Data.GuestCount
        };
        var createdRoom = await _Schedule.Create(toCreateSchedule);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpGet("{schedule_id}")]
    public async Task<ActionResult<ScheduleDTO>> GetUserById([FromRoute] long schedule_id)
    {
        var user = await _Schedule.GetById(schedule_id);

        if (user is null)
            return NotFound("No user found with given  schedule id");

        return Ok(user.asDTO);
    }
    // [HttpPut("{stay_schedule_id}")]
    // public async Task<ActionResult> UpdateUser([FromRoute] long stay_schedule_id,
    //    [FromBody] ScheduleUpdateDTO Data)
    // {
    //     var existing = await _Schedule.GetById(stay_schedule_id);
    //     if (existing is null)
    //         return NotFound("No user found with given room id");

    //     var toUpdateRoom = existing with
    //     {
    //         RoomType = Data.RoomType,
    //         RoomNumber = Data.RoomNumber

    //     };

    //     var didUpdate = await _room.Update(toUpdateRoom);

    //     if (!didUpdate)
    //         return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

    //     return NoContent();
    // }

    [HttpDelete("{schedule_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long schedule_id)
    {
        var existing = await _Schedule.GetById(schedule_id);
        if (existing is null)
            return NotFound("No user found with given stay schedule id");

        var didDelete = await _Schedule.Delete(schedule_id);

        return NoContent();
    }
}
