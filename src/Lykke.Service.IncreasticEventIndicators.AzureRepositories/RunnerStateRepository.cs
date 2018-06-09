﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage;
using JetBrains.Annotations;
using Lykke.AzureStorage.Tables;
using Lykke.Service.IncreasticEventIndicators.Core.Domain;

namespace Lykke.Service.IncreasticEventIndicators.AzureRepositories
{
    public class RunnerStateEntity : AzureTableEntity, IRunnerState
    {
        public int Event { get; set; }
        public decimal Extreme { get; set; }
        public decimal ExpectedDcLevel { get; set; }
        public decimal ExpectedOsLevel { get; set; }
        public decimal Reference { get; set; }
        public ExpectedDirectionalChange ExpectedDirectionalChange { get; set; }
        public decimal DirectionalChangePrice { get; set; }
        public decimal Delta { get; set; }
        public string AssetPair { get; set; }
        public string Exchange { get; set; }
    }

    [UsedImplicitly]
    public abstract class RunnerStateRepository : IRunnerStateRepository
    {
        private readonly INoSQLTableStorage<RunnerStateEntity> _storage;

        protected RunnerStateRepository(INoSQLTableStorage<RunnerStateEntity> storage)
        {
            _storage = storage;
        }

        public async Task<IReadOnlyList<IRunnerState>> GetState()
        {
            return (await _storage.GetDataAsync()).ToArray();
        }

        public async Task SaveState(IReadOnlyList<IRunnerState> state)
        {
            var entities = state.Select(x =>
                new RunnerStateEntity
                {
                    PartitionKey = GeneratePartitionKey(x.AssetPair),
                    RowKey = GenerateRowKey(x.Delta),
                    Event = x.Event,
                    Extreme = x.Extreme,
                    ExpectedDcLevel = x.ExpectedDcLevel,
                    ExpectedOsLevel = x.ExpectedOsLevel,
                    Reference = x.Reference,
                    ExpectedDirectionalChange = x.ExpectedDirectionalChange,
                    DirectionalChangePrice = x.DirectionalChangePrice,
                    AssetPair = x.AssetPair,
                    Delta = x.Delta,                    
                    Exchange = x.Exchange
                }
            ).ToArray();

            await InsertOrReplaceAsync(entities);
        }

        public async Task CleanOldItems(IEnumerable<string> exchangeAssetPairs, IEnumerable<decimal> deltas)
        {
            var partitionKeys = exchangeAssetPairs.Select(GeneratePartitionKey);
            var rowKeys = deltas.Select(GenerateRowKey);

            var entitiesToDelete = await _storage.GetDataAsync(x => !partitionKeys.Contains(x.PartitionKey) || !rowKeys.Contains(x.RowKey));

            var tasks = entitiesToDelete.Select(x => _storage.DeleteAsync(x)).ToArray();
            await Task.WhenAll(tasks);
        }

        private async Task InsertOrReplaceAsync(IEnumerable<RunnerStateEntity> entities)
        {
            var tasks = entities.Select(x => _storage.InsertOrReplaceAsync(x)).ToArray();
            await Task.WhenAll(tasks);
        }        

        private static string GeneratePartitionKey(string assetPair)
        {
            return assetPair;
        }

        private static string GenerateRowKey(decimal delta)
        {
            return delta.ToString(CultureInfo.InvariantCulture);
        }
    }
}
