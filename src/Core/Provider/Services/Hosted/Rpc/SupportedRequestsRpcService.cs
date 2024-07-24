using Fintatech.Common.Financial.Services;
using Fintatech.Common.Messaging.Core.Services;
using Fintatech.DataConsolidators.Bars.Core.Common.Messaging.Rpc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Rpc;

internal sealed class SupportedRequestsRpcService(
    IServiceScopeFactory serviceScopeFactory,
    IDataProviderInfoProvider infoProvider,
    ILogger<SupportedRequestsRpcService> logger
) : RpcServerService<SupportedRequestsRpcRequest, SupportedRequestsRpcResponse>(serviceScopeFactory, logger)
{
    protected override bool FilterRequest(SupportedRequestsRpcRequest request)
        => request.Provider == infoProvider.GetProviderInfo().CodeName;
}