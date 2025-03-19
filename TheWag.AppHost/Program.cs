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

//var sql = builder.AddSqlServer("WagDBServer")
//                 .WithLifetime(ContainerLifetime.Persistent)
//                 .WithContainerRuntimeArgs("-p", "1433:1433");

//var sqlServer = builder.AddAzureSqlServer("sqlserver")
//                       .AddDatabase("sqldb");

//var wagDbService = builder.AddProject<Projects.TheWag_Api_WagDB>("wagdbservice");

var wagDbApi = builder.AddProject<Projects.TheWag_Api_WagDB>("wagdbapi");
//.WithReference(wagdb);


builder.AddProject<Projects.TheWag_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache).WaitFor(cache)
    .WithEnvironment("VISION_KEY", visionKeySecret)
    .WithEnvironment("VISION_ENDPOINT", visionEndpointSecret)
    .WithReference(blobs).WaitFor(blobs)
    .WithReference(wagDbApi).WaitFor(wagDbApi);

//var wagdb = builder.AddConnectionString("wagdb");



builder.Build().Run();
