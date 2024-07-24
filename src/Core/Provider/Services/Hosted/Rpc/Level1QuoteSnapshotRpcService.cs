using Fintatech.Common.Financial.Messaging.Rpc;
using Fintatech.Common.Financial.Services;
using Fintatech.Common.Messaging.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Rpc;

internal sealed class Level1QuoteSnapshotRpcService(
    IServiceScopeFactory serviceScopeFactory,
    IDataProviderInfoProvider infoProvider,
    ILogger<Level1QuoteSnapshotRpcService> logger
) : RpcServerService<ProviderLevel1QuoteSnapshotRpcRequest, ProviderLevel1QuoteSnapshotRpcResponse>(
    serviceScopeFactory, logger)
{
    protected override bool FilterRequest(ProviderLevel1QuoteSnapshotRpcRequest request)
        => request.Provider == infoProvider.GetProviderInfo().CodeName;
}