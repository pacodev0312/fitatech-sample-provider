using System.Collections.Concurrent;
using Fintatech.Common.Financial.Data;
using Fintatech.Common.Financial.Models;
using Fintatech.Common.Financial.Services;
using Fintatech.DataConsolidators.Instruments.Core.Common.Models;
using Fintatech.DataConsolidators.Realtime.Core.Common.Messaging;
using Fintatech.DataConsolidators.Realtime.Core.Common.Services;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services;

#pragma warning disable CA5394

// TODO: Update code to connect to a real data provider and handle quote subscriptions.

internal sealed class Level1StreamService(
    IDataProviderInfoProvider infoProvider,
    ILevel1UpdatePublisher level1UpdatePublisher,
    IDataProviderConnectionStatusNotifier dataProviderConnectionStatusNotifier
) : ILevel1StreamService, IDisposable
{
    private readonly ConcurrentDictionary<string, Instrument> _subscribedInstrumentPerSymbol = new();
    private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(100));
    private readonly Random _random = new();

    public void Dispose()
    {
        _timer.Dispose();
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        await dataProviderConnectionStatusNotifier.Notify(DataProviderConnectionStatus.Connected, cancellationToken);

        while (await _timer.WaitForNextTickAsync(cancellationToken))
        {
            await GenerateQuotes(cancellationToken);
        }

        await dataProviderConnectionStatusNotifier.Notify(DataProviderConnectionStatus.Disconnected, cancellationToken);
    }

    public Task Subscribe(Instrument instrument, CancellationToken cancellationToken)
    {
        var symbol = instrument.GetMappedSymbol(infoProvider.GetProviderInfo().CodeName) ?? instrument.Symbol;

        _subscribedInstrumentPerSymbol.TryAdd(symbol, instrument);

        return Task.CompletedTask;
    }

    public Task Unsubscribe(Instrument instrument, CancellationToken cancellationToken)
    {
        var symbol = instrument.GetMappedSymbol(infoProvider.GetProviderInfo().CodeName) ?? instrument.Symbol;

        _subscribedInstrumentPerSymbol.TryRemove(symbol, out _);

        return Task.CompletedTask;
    }

    private async Task GenerateQuotes(CancellationToken cancellationToken)
    {
        foreach (var instrument in _subscribedInstrumentPerSymbol.Values)
        {
            await GenerateNextQuote(instrument, cancellationToken);
        }
    }

    private Task GenerateNextQuote(Instrument instrument, CancellationToken cancellationToken)
    {
        var price = 1.0815m;
        var time = DateTimeOffset.UtcNow;
        var ask = new Tick(time, price + _random.Next(100) / 100m, 1000);
        var bid = new Tick(time, price, 900);
        var last = new Tick(time, price - _random.Next(100) / 100m, 950);

        var message = new Level1UpdateMessage
        {
            Provider = infoProvider.GetProviderInfo().CodeName,
            InstrumentId = instrument.Id,
            Ask = ask,
            Bid = bid,
            Last = last,
        };

        return level1UpdatePublisher.Publish(message, cancellationToken);
    }
}