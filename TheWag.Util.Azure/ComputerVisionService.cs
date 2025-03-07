using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Azure.Identity;
using TheWag.Util.Images.Models;


namespace TheWag.Util.Azure
{
    public class ComputerVisionService
    {
        private readonly ImageAnalysisClient _client;
        private string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
        private string key = Environment.GetEnvironmentVariable("VISION_KEY");
        public ComputerVisionService(string accountName) 
        {
            //TODO: cant seem to get DefaultAzureCredential working, so using key for now
            //thewagcomputervision
            //var azureKeyCredential = new DefaultAzureCredential();
            //var uri = new Uri($"https://{accountName}.cognitiveservices.azure.com/");
            //Client = new ImageAnalysisClient(uri, azureKeyCredential);

            _client = new ImageAnalysisClient(
                new Uri(endpoint),
                new AzureKeyCredential(key));
        }


        public ImageAnalysisResults GetImageAnalysis(BinaryData imageData)
        {
            VisualFeatures visualFeatures =
                VisualFeatures.Caption |
                //VisualFeatures.Objects |
                VisualFeatures.Tags |
                VisualFeatures.SmartCrops;

            var options = new ImageAnalysisOptions
            {
                GenderNeutralCaption = true,
                Language = "en",
                SmartCropsAspectRatios = new float[] { 0.9F, 1.33F }
            };

            

            ImageAnalysisResult result = _client.Analyze(
                                        imageData,
                                        visualFeatures,
                                        options);


            var ias = new ImageAnalysisResults() 
            { 
                Description= result.Caption.Text,
                Tags = result.Tags.Values.Select(t => t.Name).ToList(),
                CropRegions = result.SmartCrops.Values
            };
          
            //vm.IsDog = false;
            //foreach (DetectedObject detectedObject in result.Objects.Values)
            //{
            //    if (detectedObject.Tags.First().Name == "dog")
            //    {
            //        vm.IsDog = true;
            //    }
            //}
            //foreach (var tag in vm.Tags)
            //{
            //    if (tag == "dog")
            //    {
            //        vm.IsDog = true;
            //    }
            //}
            return ias;

          
        }

    }
}
