using hotel.DTOs;

namespace hotel.Models;

public record Staff
{
    public long StaffId { get; set; }
    public String Name { get; set; }
    public int Gender { get; set; }
    public long Mobile { get; set; }
    public int Shift { get; set; }
    public string Position { get; set; }

    public StaffDTO asDTO => new StaffDTO
    {
        StaffId = StaffId,
        Name = Name,
        Gender = Gender,
        Mobile = Mobile,
        Shift = Shift,
        Position = Position,
    };
}
