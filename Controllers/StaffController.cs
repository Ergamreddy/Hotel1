using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;
using Microsoft.AspNetCore.Mvc;
using static hotel.DTOs.StaffDTO;

namespace hotel.Controllers;


[ApiController]
[Route("Api/Controller")]

public class StaffController : ControllerBase
{
    private readonly ILogger<StaffController> _logger;
    private readonly IStaffRepository _staff;

    public StaffController(ILogger<StaffController> logger, IStaffRepository Staff)
    {
        _logger = logger;
        _staff = Staff;
    }
    [HttpGet]
    public async Task<ActionResult<List<StaffDTO>>> GetAllUsers()
    {
        var usersList = await _staff.GetList();

        
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpPost]
    public async Task<ActionResult<StaffDTO>> Staff([FromBody] StaffCreateDTO Data)
    {
        var toCreateStaff = new Staff
        {
            StaffId = Data.StaffId,
            Name = Data.Name,
            Gender = Data.Gender,
            Mobile = Data.Mobile,
            Shift = Data.Shift,
            Position = Data.Position,
        };
        var createStaff = await _staff.Create(toCreateStaff);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpGet("{staff_id}")]
    public async Task<ActionResult<StaffDTO>> GetUserById([FromRoute] long staff_id)
    {
        var user = await _staff.GetById(staff_id);

        if (user is null)
            return NotFound("No user found with given Staff id");

        return Ok(user.asDTO);
    }
    [HttpPut("{staff_id}")]
    public async Task<ActionResult> UpdateStaff([FromRoute] long staff_id,
       [FromBody] StaffUpdateDTO Data)
    {
        var existing = await _staff.GetById(staff_id);
        if (existing is null)
            return NotFound("No user found with given staff id");

        var toUpdateStaff = existing with
        {
            Mobile = Data.Mobile,
            Shift = Data.Shift,

        };

        var didUpdate = await _staff.Update(toUpdateStaff);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update Staff");

        return NoContent();
    }

    [HttpDelete("{staff_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long staff_id)
    {
        // var existing = await _roomservicestaff.Delete(staff_id);
        // if (existing is null)
        //     return NotFound("No user found with given staff id");

        var didDelete = await _staff.Delete(staff_id);

        return NoContent();
    }
}

