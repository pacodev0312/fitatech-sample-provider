using Fintatech.Common.Financial.Messaging;
using Fintatech.Common.Financial.Models;
using Fintatech.Common.Financial.Services;

namespace Fintatech.DataProviders.Sample.Core.Provider.Services;

internal sealed class SampleDataProviderInfoProvider : DataProviderInfoProvider
{
    protected override DataProviderInfoMessage Info { get; } = new()
    {
        Name = "Sample",
        CodeName = "sample",
        Features =
        [
            DataProviderFeature.Instruments,
            DataProviderFeature.HistoricalBars,
            DataProviderFeature.RealtimeLevel1
        ],
    };
}