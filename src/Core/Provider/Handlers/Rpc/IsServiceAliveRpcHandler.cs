using Fintatech.Common.Financial.Messaging.Rpc;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers.Rpc;

internal sealed class IsServiceAliveRpcHandler : IRequestHandler<IsServiceAliveRpcRequest, IsServiceAliveRpcResponse>
{
    public Task<IsServiceAliveRpcResponse> Handle(IsServiceAliveRpcRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new IsServiceAliveRpcResponse
        {
            Data = true,
        });
    }
}