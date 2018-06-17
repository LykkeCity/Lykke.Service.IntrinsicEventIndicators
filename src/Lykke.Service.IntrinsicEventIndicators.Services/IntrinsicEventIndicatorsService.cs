﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Service.IntrinsicEventIndicators.Core.Domain;
using Lykke.Service.IntrinsicEventIndicators.Core.Domain.Model;
using Lykke.Service.IntrinsicEventIndicators.Core.Services;
using Lykke.Service.IntrinsicEventIndicators.Services.Exchanges;

namespace Lykke.Service.IntrinsicEventIndicators.Services
{
    public abstract class IntrinsicEventIndicatorsService : IIntrinsicEventIndicatorsService
    {
        private readonly IIntrinsicEventIndicatorsRepository _repo;
        private readonly ILog _log;
        private readonly ITickPriceManager _tickPriceManager;

        private bool _initialized;

        protected IntrinsicEventIndicatorsService(IIntrinsicEventIndicatorsRepository repo,
            ITickPriceManager tickPriceManager, ILog log)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _log = log.CreateComponentScope(nameof(IntrinsicEventIndicatorsService));
            _tickPriceManager = tickPriceManager;

            EnsureInitialized();
        }

        public async Task AddColumn(IIntrinsicEventIndicatorsColumn column)
        {
            EnsureInitialized();

            await _repo.AddColumnAsync(column);
            await UpdateRunners();
        }

        public async Task RemoveColumn(string columnId)
        {
            EnsureInitialized();

            await _repo.RemoveColumnAsync(columnId);
            await UpdateRunners();
        }

        public async Task AddAssetPair(IIntrinsicEventIndicatorsRow row)
        {
            EnsureInitialized();

            await _repo.AddAssetPairAsync(row);
            await UpdateRunners();
        }

        public async Task RemoveAssetPair(string rowId)
        {
            EnsureInitialized();

            await _repo.RemoveAssetPairAsync(rowId);
            await UpdateRunners();
        }

        public async Task<IntrinsicEventIndicators.Core.Domain.Model.IntrinsicEventIndicators> GetData()
        {
            EnsureInitialized();

            var rows = (await _repo.GetRowsAsync()).OrderBy(x =>
                TickPriceManager.GetExchangeAssetPairKey(x.Exchange, x.AssetPair)).ToList();
            var columns = (await _repo.GetColumnsAsync()).OrderBy(x => x.Delta).ToList();            

            var data = await _tickPriceManager.GetIntrinsicEventIndicators(
                rows.Select(x => TickPriceManager.GetExchangeAssetPairKey(x.Exchange, x.AssetPair)).ToList(),
                columns.Select(x => x.Delta).ToList());

            return await Task.FromResult(new IntrinsicEventIndicators.Core.Domain.Model.IntrinsicEventIndicators
            {
                Columns = columns.ToArray(),
                Rows = rows.ToArray(),
                Data = data
            });
        }

        public Task<IDictionary<string, IList<IRunnerState>>> GetRunnersStates()
        {
            EnsureInitialized();

            return _tickPriceManager.GetRunnersStates();
        }

        private void EnsureInitialized()
        {
            if (_initialized) return;

            var task = Task.Run(UpdateRunners);
            Task.WaitAll(task);

            _initialized = true;
        }

        private async Task UpdateRunners()
        {
            var columns = (await _repo.GetColumnsAsync()).Select(x => x.Delta).OrderBy(x => x).ToList();
            var rows = (await _repo.GetRowsAsync()).Select(x =>
                TickPriceManager.GetExchangeAssetPairKey(x.Exchange, x.AssetPair)).OrderBy(x => x).ToList();

            await _tickPriceManager.UpdateRunners(rows.Select(x => x.ToUpperInvariant()).Distinct().ToList(), columns.Distinct().ToList());
        }
    }
}