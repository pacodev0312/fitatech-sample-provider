using Fintatech.Common.Financial.Messaging.Rpc;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers.Rpc;

internal sealed class IsDataProviderAliveRpcHandler
    : IRequestHandler<IsDataProviderAliveRpcRequest, IsDataProviderAliveRpcResponse>
{
    public Task<IsDataProviderAliveRpcResponse> Handle(
        IsDataProviderAliveRpcRequest request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(new IsDataProviderAliveRpcResponse
        {
            Data = true,
        });
    }
}