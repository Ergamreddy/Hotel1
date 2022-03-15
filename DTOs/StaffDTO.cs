using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record StaffDTO
{

    [JsonPropertyName("staff_id")]
    public long StaffId { get; set; }
    [JsonPropertyName("name")]
    public String Name { get; set; }
    [JsonPropertyName("gender")]
    public int Gender { get; set; }
    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
    [JsonPropertyName("shift")]
    public int Shift { get; set; }
    [JsonPropertyName("position")]
    public string Position { get; set; }



    public record StaffCreateDTO
    {
        [JsonPropertyName("staff_id")]
        [Required]

        public long StaffId { get; set; }

        [JsonPropertyName("name")]
        [Required]

        public String Name { get; set; }
        [JsonPropertyName("gender")]
        public int Gender { get; set; }
        [JsonPropertyName("mobile")]
        public long Mobile { get; set; }
        [JsonPropertyName("shift")]
        public int Shift { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }


    }

    public record StaffUpdateDTO
    {
        [JsonPropertyName("mobile")]

        public long Mobile { get; set; }

        [JsonPropertyName("shift")]
        public int Shift { get; set; }

    }
}