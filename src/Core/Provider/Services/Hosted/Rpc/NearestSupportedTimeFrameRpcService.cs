using Fintatech.Common.Financial.Services;
using Fintatech.Common.Messaging.Core.Services;
using Fintatech.DataConsolidators.Bars.Core.Common.Messaging.Rpc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Rpc;

internal sealed class NearestSupportedTimeFrameRpcService(
    IServiceScopeFactory serviceScopeFactory,
    IDataProviderInfoProvider infoProvider,
    ILogger<NearestSupportedTimeFrameRpcService> logger
) : RpcServerService<NearestSupportedTimeFrameRpcRequest, NearestSupportedTimeFrameRpcResponse>(
    serviceScopeFactory, logger)
{
    protected override bool FilterRequest(NearestSupportedTimeFrameRpcRequest request)
        => request.Provider == infoProvider.GetProviderInfo().CodeName;
}