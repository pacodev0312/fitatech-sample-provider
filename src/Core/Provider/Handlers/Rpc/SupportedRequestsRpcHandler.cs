using Fintatech.DataConsolidators.Bars.Core.Common.Messaging.Rpc;
using Fintatech.DataConsolidators.Bars.Core.Common.Models;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers.Rpc;

internal sealed class SupportedRequestsRpcHandler
    : IRequestHandler<SupportedRequestsRpcRequest, SupportedRequestsRpcResponse>
{
    private static readonly BarRequestKind[] SupportedRequests = [
        BarRequestKind.DateRange,
    ];

    public Task<SupportedRequestsRpcResponse> Handle(
        SupportedRequestsRpcRequest request,
        CancellationToken cancellationToken)
    {
        // TODO: Update code to return supported historical bar requests.

        var response = new SupportedRequestsRpcResponse
        {
            Data = SupportedRequests,
        };

        return Task.FromResult(response);
    }
}
