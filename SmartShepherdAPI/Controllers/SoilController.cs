using Microsoft.AspNetCore.Mvc;
using SmartShepherdAPI.Models;
using System.Collections.Generic;

namespace SmartShepherdAPI.Controllers
{
    [ApiController]
    [Route("api/soil")]
    public class SoilController : ControllerBase
    {
        [HttpPost("analyze")]
        public IActionResult Analyze([FromBody] SoilInput input)
        {
            if (input == null || input.ph <= 0 || input.moisture < 0 || string.IsNullOrWhiteSpace(input.cropType))
                return BadRequest("Invalid input.");

            var result = new SoilAnalysisResult
            {
                Suggestion = AnalyzeSoil(input),
                RecommendedTools = RecommendTools(input)
            };

            return Ok(result);
        }

        private string AnalyzeSoil(SoilInput input)
        {
            if (input.ph < 5.5)
                return "Soil too acidic. Consider liming.";
            if (input.ph > 7.5)
                return "Soil too alkaline. Use sulfur-based amendments.";
            if (input.moisture < 30)
                return "Soil too dry. Consider irrigation.";
            if (input.moisture > 80)
                return "Soil too wet. Improve drainage.";
            return "Soil is optimal for most crops.";
        }

        private List<string> RecommendTools(SoilInput input)
        {
            var tools = new List<string>();

            if (input.moisture < 30)
                tools.Add("Solar Water Pump");
            if (input.moisture > 80)
                tools.Add("Drainage Monitoring Kit");
            if (input.ph < 5.5 || input.ph > 7.5)
                tools.Add("Soil pH Adjustment Kit");

            tools.Add("Soil Sensor Pro"); // always useful

            return tools;
        }
    }

    public class SoilInput
    {
        public double ph { get; set; }
        public double moisture { get; set; }
        public string cropType { get; set; }
    }
    private string PredictCropType(double ph, double moisture)
        {
            if (ph >= 6.0 && ph <= 7.5 && moisture > 60)
                return "Corn";
            else if (ph >= 5.5 && ph <= 6.8 && moisture > 40)
                return "Soybeans";
            else if (ph >= 6.0 && ph <= 6.5 && moisture > 30)
                return "Wheat";
            else if (ph >= 5.0 && ph <= 6.0 && moisture < 30)
                return "Potatoes";
            else if (ph >= 7.0 && ph <= 8.5 && moisture > 50)
                return "Alfalfa";
            else
                return "Generic Vegetables";
        }

    }
