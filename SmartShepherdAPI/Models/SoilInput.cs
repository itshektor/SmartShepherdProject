namespace SmartShepherdAPI.Models
{
    public class SoilInput
    {
        public double ph { get; set; }
        public double moisture { get; set; }
        public string cropType { get; set; } = string.Empty;
    }

}