using Fintatech.Common.Core.Sessions;
using Fintatech.Common.Financial.Messaging.Rpc;
using Fintatech.Common.Messaging.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Rpc;

internal sealed class IsServiceAliveRpcService(
    IServiceScopeFactory serviceScopeFactory,
    IServiceSessionProvider serviceSessionProvider,
    ILogger<IsServiceAliveRpcService> logger
) : RpcServerService<IsServiceAliveRpcRequest, IsServiceAliveRpcResponse>(serviceScopeFactory, logger)
{
    protected override bool FilterRequest(IsServiceAliveRpcRequest request)
        => request.ServiceSession.Equals(serviceSessionProvider.GetSession());
}