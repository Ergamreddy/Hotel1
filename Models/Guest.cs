namespace hotel.Models;
using hotel.DTOs;

public record Guest
{
    public long GuestId { get; set; }
    public String FirstName { get; set; }

    public String LastName { get; set; }
    public long Mobile { get; set; }

    public string Address { get; set; }

    public int Gender { get; set; }

    public GuestDTO asDTO => new GuestDTO
    {
        GuestId = GuestId,
        FirstName = FirstName,
        LastName = LastName,
        Mobile = Mobile,
        Address = Address,
        Gender = Gender,

    };
}

