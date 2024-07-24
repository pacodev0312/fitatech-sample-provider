using Fintatech.DataConsolidators.Instruments.Core.Common.Services;
using Fintatech.DataProviders.Sample.Core.Provider.Requests;
using Fintatech.DataProviders.Sample.Core.Provider.Services;
using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Handlers;

internal sealed class UnsubscribeLevel1Handler(
    IInstrumentService instrumentService,
    ILevel1StreamService level1Processor
) : IRequestHandler<UnsubscribeLevel1Request>
{
    public async Task Handle(UnsubscribeLevel1Request request, CancellationToken cancellationToken)
    {
        var instrument = await instrumentService.Find(request.InstrumentId, cancellationToken);

        await level1Processor.Unsubscribe(instrument, cancellationToken);
    }
}