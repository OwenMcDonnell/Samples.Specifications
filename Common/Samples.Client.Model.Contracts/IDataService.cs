﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samples.Client.Model.Contracts
{
    public interface IDataService
    {
        IEnumerable<IWarehouseItem> WarehouseItems { get; }

        Task GetWarehouseItemsAsync();

        Task<IWarehouseItem> NewWarehouseItemAsync();

        Task DeleteWarehouseItemAsync(IWarehouseItem item);

        void StartEventMonitoring();

        void StopEventMonitoring();

        Task ClearEventsAsync();

        IEnumerable<IEvent> Events { get; }

        bool EventMonitoringStarted { get; }
    }
}
