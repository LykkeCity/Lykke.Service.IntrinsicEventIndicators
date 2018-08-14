﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lykke.Service.IntrinsicEventIndicators.Client.AutorestClient.Models;

namespace Lykke.Service.IntrinsicEventIndicators.Client
{
    public interface IIntrinsicEventIndicatorsClient : IDisposable
    {
        /// <summary>
        /// Checks if service is alive
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>IsAlive response</returns>
        /// <exception cref="Exceptions.ApiException">Thrown on getting error response.</exception>
        /// <exception cref="Microsoft.Rest.HttpOperationException">Thrown on getting incorrect http response.</exception>
        /// <exception cref="OperationCanceledException">Thrown on canceled token</exception>
        Task<IsAliveResponse> IsAliveAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds delta.
        /// </summary>
        /// <param name="column">Delta to add.</param>
        /// <param name="cancellationToken"></param>
        Task AddDeltaAsync(IntrinsicEventIndicatorsColumnPost column, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes delta.
        /// </summary>
        /// <param name="columnId">delta</param>
        /// <param name="cancellationToken"></param>
        Task RemoveDeltaAsync(string columnId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds asset pair.
        /// </summary>
        /// <param name="row">Asset pair to add.</param>
        /// <param name="cancellationToken"></param>
        Task AddAssetPairAsync(IntrinsicEventIndicatorsRowPost row, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Edits asset pair.
        /// </summary>
        /// <param name="row">Asset pair to edit.</param>
        /// <param name="cancellationToken"></param>
        Task EditAssetPairAsync(IntrinsicEventIndicatorsRowEdit row, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Deletes asset pair.
        /// </summary>
        /// <param name="rowId">asset pair</param>
        /// <param name="cancellationToken"></param>
        Task RemoveAssetPairAsync(string rowId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets data.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Data</returns>
        Task<IntrinsicEventIndicatorsDto> GetDataAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets runners states.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Runners states</returns>
        Task<IDictionary<string, IList<RunnerStateDto>>> GetRunnersStatesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds delta.
        /// </summary>
        /// <param name="column">Delta to add.</param>
        /// <param name="cancellationToken"></param>
        Task AddDeltaExternalAsync(IntrinsicEventIndicatorsColumnPost column, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes delta.
        /// </summary>
        /// <param name="columnId">delta</param>
        /// <param name="cancellationToken"></param>
        Task RemoveDeltaExternalAsync(string columnId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds asset pair.
        /// </summary>
        /// <param name="row">Asset pair to add.</param>
        /// <param name="cancellationToken"></param>
        Task AddAssetPairExternalAsync(IntrinsicEventIndicatorsRowPost row, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Edits asset pair.
        /// </summary>
        /// <param name="row">Edit pair to add.</param>
        /// <param name="cancellationToken"></param>
        Task EditAssetPairExternalAsync(IntrinsicEventIndicatorsRowEdit row, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Deletes asset pair.
        /// </summary>
        /// <param name="rowId">asset pair</param>
        /// <param name="cancellationToken"></param>
        Task RemoveAssetPairExternalAsync(string rowId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets data.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Data</returns>
        Task<IntrinsicEventIndicatorsDto> GetDataExternalAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets runners states.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Runners states</returns>
        Task<IDictionary<string, IList<RunnerStateDto>>> GetRunnersStatesExternalAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
