using Fintatech.Common.Financial.DependencyInjection;
using Fintatech.DataProviders.Sample.Core.Provider.Services;
using Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Consumers;
using Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Rpc;
using Microsoft.Extensions.DependencyInjection;

namespace Fintatech.DataProviders.Sample.Core.Provider.DependencyInjection;

/// <summary>
/// Extends <see cref="IServiceCollection"/> with Cryptoquote data provider services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds application services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The services available in the application.</param>
    /// <returns>The original <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
            options.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        services.AddDataProviderInfo<SampleDataProviderInfoProvider>();

        services.AddSingleton<ILevel1StreamService, Level1StreamService>();

        services.AddHostedService<Level1SubscriptionRequestConsumer>();

        services.AddHostedService<GetProviderBarsRpcService>();
        services.AddHostedService<IsDataProviderAliveRpcService>();
        services.AddHostedService<IsServiceAliveRpcService>();
        services.AddHostedService<Level1QuoteSnapshotRpcService>();
        services.AddHostedService<NearestSupportedTimeFrameRpcService>();
        services.AddHostedService<SupportedRequestsRpcService>();

        services.AddHostedService<ServiceStarter>();

        return services;
    }
}