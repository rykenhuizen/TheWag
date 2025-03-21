using Azure.Provisioning.Storage;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var visionKeySecret = builder.AddParameter("visionkey", secret: true);
var visionEndpointSecret = builder.AddParameter("visionendpoint", secret: true);

var blobs = builder.AddAzureStorage("storage")
    .ConfigureInfrastructure(infra =>
    {
        var storageAccount = infra.GetProvisionableResources()
                                  .OfType<StorageAccount>()                    
                                  .Single();

        storageAccount.AllowBlobPublicAccess = true;
        storageAccount.AccessTier = StorageAccountAccessTier.Hot;
        storageAccount.Sku = new StorageSku { Name = StorageSkuName.StandardLrs };
    }).RunAsEmulator(
         azurite =>
         {
             azurite.WithLifetime(ContainerLifetime.Persistent);
         }).AddBlobs("blobs");

IResourceBuilder<IResourceWithConnectionString> databaseConnectionString = builder.AddConnectionString("wagdb");

var wagDbApi = builder.AddProject<Projects.TheWag_Api_WagDB>("wagdbapi")
    .WithReference(databaseConnectionString)
    ;

builder.AddProject<Projects.TheWag_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache).WaitFor(cache)
    .WithEnvironment("VISION_KEY", visionKeySecret)
    .WithEnvironment("VISION_ENDPOINT", visionEndpointSecret)
    .WithReference(blobs).WaitFor(blobs)
    .WithReference(wagDbApi).WaitFor(wagDbApi)
    ;


builder.Build().Run();
