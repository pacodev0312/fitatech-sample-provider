using Fintatech.Common.AspNetCore.Hosting;
using Fintatech.Common.Financial.Kafka.DependencyInjection;
using Fintatech.Common.Messaging.Kafka.DependencyInjection;
using Fintatech.DataConsolidators.Instruments.Core.Common.Kafka.DependencyInjection;
using Fintatech.DataConsolidators.Instruments.Core.Common.Options;
using Fintatech.DataConsolidators.Realtime.Core.Common.Kafka.DependencyInjection;
using Fintatech.DataConsolidators.Realtime.Core.Common.Messaging;
using Fintatech.DataConsolidators.Subscriptions.Core.Common.Kafka.DependencyInjection;
using Fintatech.DataProviders.Sample.Core.Provider.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using BarRedisServices =
    Fintatech.DataConsolidators.Bars.Core.Common.Redis.DependencyInjection.ServiceCollectionExtensions;
using FinancialRedisServices = Fintatech.Common.Financial.Redis.DependencyInjection.ServiceCollectionExtensions;
using InstrumentRedisServices =
    Fintatech.DataConsolidators.Instruments.Core.Common.Redis.DependencyInjection.ServiceCollectionExtensions;
using RedisHealthChecksBuilder = Fintatech.Common.Messaging.Redis.DependencyInjection.HealthChecksBuilderExtensions;
using RedisServices = Fintatech.Common.Messaging.Redis.DependencyInjection.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<MemoryCacheOptions>(configuration.GetSection("memoryCache"));
services.Configure<InstrumentCacheOptions>(configuration.GetSection("memoryCache:instruments"));

services.AddDefaultServices(configuration);
services.AddApplication();

services
    .AddKafka(configuration)
    .AddConsumerTriggerConsumer()
    .AddServiceEnumeration()
    .AddInstrumentPublisher()
    .AddEnumerateInstrumentsConsumer()
    .AddLevel1UpdatePublisher()
    .AddLevel1SubscriptionConsumer()
    .AddMessageConsumer<Level1UpdateMessageKey, Level1UpdateMessage>("l1-updates");

RedisServices.AddRedis(services, configuration);
BarRedisServices.AddProviderBarsRpcServer(services);
BarRedisServices.AddNearestSupportedTimeFrameRpcServer(services);
BarRedisServices.AddSupportedBarRequestsRpcServer(services);
InstrumentRedisServices.AddInstrumentService(services);
FinancialRedisServices.AddIsDataProviderAliveRpcServer(services);
FinancialRedisServices.AddIsServiceAliveRpcServer(services);
FinancialRedisServices.AddProviderLevel1QuoteSnapshotRpcServer(services);

RedisHealthChecksBuilder.AddRedis(services
    .AddHealthChecks()
    .AddKafka());

services.AddPublishServiceSessionStartupJob();

var app = builder.Build();

app.UseDefaultServices(configuration);

app.MapHealthCheck("/v1/health/alive", _ => false);
app.MapHealthCheck("/v1/health/ready");

await app.RunStartupJobs(CancellationToken.None);
await app.RunAsync();