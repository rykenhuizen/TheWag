using Azure.AI.Vision.ImageAnalysis;
using Azure.Identity;
using TheWag.Util.Images.Models;


namespace TheWag.Util.Images
{
    public class ComputerVisionService
    {
        private readonly ImageAnalysisClient Client;
        public ComputerVisionService() 
        {
            Client = new ImageAnalysisClient(new Uri("https://vision.cognitiveservices.azure.com/"), new DefaultAzureCredential());
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

            ImageAnalysisResult result = Client.Analyze(
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
