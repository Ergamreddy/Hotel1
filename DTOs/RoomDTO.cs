using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record RoomDTO
{
    [JsonPropertyName("room_id")]
    public long RoomId { get; set; }
    [JsonPropertyName("room_type")]
    public string RoomType { get; set; }
    [JsonPropertyName("facilities")]
    public string Facilities { get; set; }
    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("staff_id")]
    public long StaffId { get; set; }
     public List<StaffDTO> Staff { get; internal set; }
}
public record RoomCreateDTO
{
    // internal object Facilities;
    // internal object Size;
    // internal object Price;

    [JsonPropertyName("room_id")]
    [Required]

    public long RoomId { get; set; }

    [JsonPropertyName("room_type")]
    [Required]

    public string RoomType { get; set; }

    [JsonPropertyName("facilities")]
    [Required]
    public string Facilities { get; set; }
    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    

    [JsonPropertyName("Staff_id")]
    [Required]
    public long StaffId { get; set; }

}
public record RoomUpdateDTO
{
    // internal object Facilities;
    // internal object Price;

    [JsonPropertyName("room_type")]

    public string RoomType { get; set; }

    [JsonPropertyName("facilities")]
    public string Facilities { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

}