using Fintatech.Common.Financial.Services;
using Fintatech.Common.Messaging.Core.Services;
using Fintatech.DataConsolidators.Bars.Core.Common.Messaging.Rpc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Rpc;

internal sealed class GetProviderBarsRpcService(
    IServiceScopeFactory serviceScopeFactory,
    IDataProviderInfoProvider infoProvider,
    ILogger<GetProviderBarsRpcService> logger
) : RpcServerService<GetProviderBarsRpcRequest, GetProviderBarsRpcResponse>(serviceScopeFactory, logger)
{
    protected override bool FilterRequest(GetProviderBarsRpcRequest request)
        => request.Request.Provider == infoProvider.GetProviderInfo().CodeName;
}