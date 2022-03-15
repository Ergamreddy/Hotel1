using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record GuestDTO
{
    internal List<ScheduleDTO> StaySchedule;
    internal object Schedule;

    [JsonPropertyName("guest_id")]
    public long GuestId { get; set; }

    [JsonPropertyName("first_name")]
    public String FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public String LastName { get; set; }

    [JsonPropertyName("Mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("address")]
    public String Address { get; set; }

    [JsonPropertyName("gender")]
    public int Gender { get; set; }

    // [JsonPropertyName("stay_schedule")]
    // public List<ScheduleDTO> StaySchedule { get; internal set; }

}
public record GuestCreateDTO
{
    [JsonPropertyName("guest_id")]
    [Required]

    public long GuestId { get; set; }

    [JsonPropertyName("first_name")]
    [Required]

    public String FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [Required]

    public String LastName { get; set; }

    [JsonPropertyName("mobile")]
    [Required]
    public long Mobile { get; set; }

    [JsonPropertyName("address")]
    [Required]
    public string Address { get; set; }

    [JsonPropertyName("gender")]
    [Required]
    public int Gender { get; set; }

}
public record GuestUpdateDTO
{
    internal string FirstName;

    [JsonPropertyName("last_name")]

    public String LastName { get; set; }

    [JsonPropertyName("mobile")]
    [Required]
    public long Mobile { get; set; }

    [JsonPropertyName("address")]
    [Required]
    public string Address { get; set; }



}