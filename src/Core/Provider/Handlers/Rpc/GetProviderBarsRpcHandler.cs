using Fintatech.DataConsolidators.Bars.Core.Common.Messaging.Rpc;
using Fintatech.DataConsolidators.Bars.Core.Common.Models;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers.Rpc;

internal sealed class GetProviderBarsRpcHandler : IRequestHandler<GetProviderBarsRpcRequest, GetProviderBarsRpcResponse>
{
    public Task<GetProviderBarsRpcResponse> Handle(
        GetProviderBarsRpcRequest request,
        CancellationToken cancellationToken)
    {
        // TODO: Update code to process historical bars request.

        var time = DateTimeOffset.UtcNow;

        return Task.FromResult(new GetProviderBarsRpcResponse
        {
            Data =
            [
                new Bar
                {
                    Timestamp = time.AddMinutes(-3),
                    Open = 1.0875m,
                    High = 1.0877m,
                    Low = 1.0861m,
                    Close = 1.0865m,
                    Volume = 1000,
                },
                new Bar
                {
                    Timestamp = time.AddMinutes(-2),
                    Open = 1.0867m,
                    High = 1.09m,
                    Low = 1.0864m,
                    Close = 1.0882m,
                    Volume = 1200,
                },
                new Bar
                {
                    Timestamp = time.AddMinutes(-1),
                    Open = 1.0867m,
                    High = 1.09m,
                    Low = 1.0865m,
                    Close = 1.0881m,
                    Volume = 990,
                },
            ],
        });
    }
}