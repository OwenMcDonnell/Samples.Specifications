﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attest.Fake.Builders;
using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;
using Samples.Specifications.Client.Data.Fake.Containers;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class FakeWarehouseProvider : FakeProviderBase<WarehouseProviderBuilder, IWarehouseProvider>, IWarehouseProvider
    {
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;
        private readonly Random _random = new Random();

        public FakeWarehouseProvider(
            WarehouseProviderBuilder warehouseProviderBuilder,
            IWarehouseContainer warehouseContainer)
        {
            _warehouseProviderBuilder = warehouseProviderBuilder;
            _warehouseProviderBuilder.WithWarehouseItems(warehouseContainer.WarehouseItems);
        }

        IEnumerable<WarehouseItemDto> IWarehouseProvider.GetWarehouseItems()
        {
            Task.Delay(_random.Next(2000));
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            var warehouseItems = service.GetWarehouseItems();
            return warehouseItems;
        }

        bool IWarehouseProvider.DeleteWarehouseItem(Guid id)
        {
            Task.Delay(_random.Next(2000));
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            var retVal = service.DeleteWarehouseItem(id);
            return retVal;
        }

        void IWarehouseProvider.UpdateWarehouseItem(WarehouseItemDto dto)
        {
            var delayTask = Task.Delay(_random.Next(2000));
            delayTask.Wait();
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            service.UpdateWarehouseItem(dto);
        }

        void IWarehouseProvider.CreateWarehouseItem(WarehouseItemDto dto)
        {
            var delayTask = Task.Delay(_random.Next(2000));
            delayTask.Wait();
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            service.CreateWarehouseItem(dto);
        }
    }
}
