﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Common.ExchangeAdapter.Contracts;

namespace Lykke.Service.IntrinsicEventIndicators.Core.Services.LyciAssets
{
    public interface IPriceManager
    {
        Task Handle(TickPrice tickPrice);

        PriceValue GetPrice(string asset);
        List<PriceValue> GetPrices();
    }

    public class PriceValue
    {
        public PriceValue(string asset, decimal avgMid)
        {
            Asset = asset;
            AvgMid = avgMid;
        }

        public string Asset { get; set; }
        public decimal AvgMid { get; set; }
    }
}
