using Fintatech.Common.Abstractions.Messaging;
using Fintatech.Common.Core.Services;
using Fintatech.Common.Financial.Services;
using Fintatech.DataConsolidators.Subscriptions.Core.Common.Messaging;
using Fintatech.DataProviders.Sample.Core.Provider.Requests;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services.Hosted.Consumers;

internal sealed class Level1SubscriptionRequestConsumer(
    IServiceScopeFactory serviceScopeFactory,
    IDataProviderInfoProvider infoProvider,
    IMediator mediator,
    ILogger<Level1SubscriptionRequestConsumer> logger
) : MessageConsumerService<Level1SubscriptionProviderMessageKey, Level1SubscriptionProviderMessage>(
    serviceScopeFactory, logger)
{
    protected override Task ProcessMessage(
        ConsumeMessageContext<Level1SubscriptionProviderMessageKey, Level1SubscriptionProviderMessage> context,
        CancellationToken cancellationToken)
    {
        var message = context.Message;

        if (message.Provider != infoProvider.GetProviderInfo().CodeName)
            return Task.CompletedTask;

        object request = message.IsSubscribe
            ? new SubscribeLevel1Request(message.InstrumentId)
            : new UnsubscribeLevel1Request(message.InstrumentId);

        return mediator.Send(request, cancellationToken);
    }
}