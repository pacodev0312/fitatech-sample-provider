using Microsoft.Extensions.Hosting;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services;

internal sealed class ServiceStarter(ILevel1StreamService level1StreamService) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return level1StreamService.Run(stoppingToken);
    }
}