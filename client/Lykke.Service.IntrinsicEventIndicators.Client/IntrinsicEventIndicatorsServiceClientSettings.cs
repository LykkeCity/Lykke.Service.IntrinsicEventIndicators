﻿using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.IntrinsicEventIndicators.Client
{
    /// <summary>
    /// MarketMakerReports client settings.
    /// </summary>
    [PublicAPI]
    public class IntrinsicEventIndicatorsServiceClientSettings
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl { get; set; }
    }
}
