using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Requests;

internal sealed record UnsubscribeLevel1Request(Guid InstrumentId) : IRequest;