using hotel.DTOs;

namespace hotel.Models;

public record Room
{
    // internal object Facilities;
    // internal object Size;
    // internal object Price;

    public long RoomId { get; set; }
    public string RoomType { get; set; }
    public string Facilities { get; set; }
    public int Size { get; set; }
    public decimal Price { get; set; }
    public long StaffId { get; set; }

    public RoomDTO asDTO => new RoomDTO
    {
        RoomId = RoomId,
        RoomType = RoomType,
        Facilities = Facilities,
        Size = Size,
        Price = Price,
        StaffId = StaffId,
    };

    // public static implicit operator Room(Room v)
    // {
    //     throw new NotImplementedException();
    // }
}