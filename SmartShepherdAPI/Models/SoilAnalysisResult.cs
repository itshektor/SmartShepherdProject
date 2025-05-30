namespace SmartShepherdAPI.Models
{

    public class SoilAnalysisResult
    {
        public string Suggestion { get; set; } = string.Empty;
        public List<string> RecommendedTools { get; set; } = new List<string>();
    }


}