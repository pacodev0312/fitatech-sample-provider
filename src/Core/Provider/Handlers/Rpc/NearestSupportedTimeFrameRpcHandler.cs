using Fintatech.DataConsolidators.Bars.Core.Common.Messaging.Rpc;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers.Rpc;

internal sealed class NearestSupportedTimeFrameRpcHandler
    : IRequestHandler<NearestSupportedTimeFrameRpcRequest, NearestSupportedTimeFrameRpcResponse>
{
    public Task<NearestSupportedTimeFrameRpcResponse> Handle(
        NearestSupportedTimeFrameRpcRequest request,
        CancellationToken cancellationToken)
    {
        // TODO: Update code to convert the requested time frame to a supported one (suitable for bars aggregation).
        // E.g. the requested time frame is 2 Min, but it is not supported.
        // However 1 Min time frame is supported. So return it.
        // Final bars will be built from bars of this time frame.
        // E.g. 5 Min -> 1 Min, 4 Hour -> 1 Hour, 1 Week -> 1 Day, etc.

        var response = new NearestSupportedTimeFrameRpcResponse
        {
            Data = request.TimeFrame,
        };

        return Task.FromResult(response);
    }
}
