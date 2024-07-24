using Fintatech.DataConsolidators.Instruments.Core.Common.Models;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services;

internal interface ILevel1StreamService
{
    Task Run(CancellationToken cancellationToken);
    Task Subscribe(Instrument instrument, CancellationToken cancellationToken);
    Task Unsubscribe(Instrument instrument, CancellationToken cancellationToken);
}