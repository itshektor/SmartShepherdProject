// SoilData.cs
namespace SmartShepherdAPI.Models
{
    public class SoilData
    {
        public int Id { get; set; }
        public double PH { get; set; }
        public double Moisture { get; set; }
        public string? CropType { get; set; }
        public DateTime Timestamp { get; set; }
    }


}