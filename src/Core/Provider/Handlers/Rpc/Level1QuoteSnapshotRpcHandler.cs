using Fintatech.Common.Financial.Data;
using Fintatech.Common.Financial.Messaging.Rpc;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers.Rpc;

internal sealed class Level1QuoteSnapshotRpcHandler :
    IRequestHandler<ProviderLevel1QuoteSnapshotRpcRequest, ProviderLevel1QuoteSnapshotRpcResponse>
{
    public Task<ProviderLevel1QuoteSnapshotRpcResponse> Handle(
        ProviderLevel1QuoteSnapshotRpcRequest request,
        CancellationToken cancellationToken)
    {
        // TODO: Update code to return the latest quote for the requested instrument.

        var time = DateTimeOffset.UtcNow;
        var ask = new Tick(time, 1.0815m, 1000);
        var bid = new Tick(time, 1.0808m, 900);
        var last = new Tick(time, 1.0811m, 950);

        var response = new ProviderLevel1QuoteSnapshotRpcResponse
        {
            Data = new Level1Quote(ask, bid, last),
        };

        return Task.FromResult(response);
    }
}