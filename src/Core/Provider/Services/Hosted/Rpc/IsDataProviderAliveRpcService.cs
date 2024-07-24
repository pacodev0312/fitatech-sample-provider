using Fintatech.Common.Financial.Messaging.Rpc;
using Fintatech.Common.Financial.Services;
using Fintatech.Common.Messaging.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Rpc;

internal sealed class IsDataProviderAliveRpcService(
    IServiceScopeFactory serviceScopeFactory,
    IDataProviderInfoProvider infoProvider,
    ILogger<IsDataProviderAliveRpcService> logger
) : RpcServerService<IsDataProviderAliveRpcRequest, IsDataProviderAliveRpcResponse>(serviceScopeFactory, logger)
{
    protected override bool FilterRequest(IsDataProviderAliveRpcRequest request)
        => request.Provider == infoProvider.GetProviderInfo().CodeName;
}