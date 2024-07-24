using Fintatech.DataConsolidators.Instruments.Core.Common.Services;
using Fintatech.DataProviders.Sample.Core.Provider.Requests;
using Fintatech.DataProviders.Sample.Core.Provider.Services;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers;

internal sealed class SubscribeLevel1Handler(IInstrumentService instrumentService, ILevel1StreamService level1Stream)
    : IRequestHandler<SubscribeLevel1Request>
{
    public async Task Handle(SubscribeLevel1Request request, CancellationToken cancellationToken)
    {
        var instrument = await instrumentService.Find(request.InstrumentId, cancellationToken);

        await level1Stream.Subscribe(instrument, cancellationToken);
    }
}