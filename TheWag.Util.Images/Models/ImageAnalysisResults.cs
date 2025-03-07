using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Vision.ImageAnalysis;

namespace TheWag.Util.Images.Models
{
    public class ImageAnalysisResults
    {
        public required string Description { get; set; }
        public required IList<string> Tags { get; set; }
        public IReadOnlyList<CropRegion>? CropRegions { get; set; }
    }
}
