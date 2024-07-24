using MediatR;

namespace Fintatech.DataProviders.Sample.Core.Provider.Requests;

internal sealed record SubscribeLevel1Request(Guid InstrumentId) : IRequest;