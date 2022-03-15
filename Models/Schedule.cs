using hotel.DTOs;

namespace hotel.Models;

public record Schedule
{
    public long ScheduleId { get; set; }
    public long RoomId { get; set; }
    public long GuestId { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }
    public int GuestCount { get; set; }

    public ScheduleDTO asDTO => new ScheduleDTO
    {
        ScheduleId = ScheduleId,
        RoomId = RoomId,
        GuestId = GuestId,
        CheckIn = CheckIn,
        CheckOut = CheckOut,
        GuestCount = GuestCount,
    };
}