using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Samples.Specifications.Client.Model.Contracts;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class MainViewModel : Screen
    {
        private readonly IViewModelCreatorService _viewModelCreatorService;
        private readonly IDataService _dataService;

        public MainViewModel(
            IViewModelCreatorService viewModelCreatorService,
            IDataService dataService)
        {
            _viewModelCreatorService = viewModelCreatorService;
            _dataService = dataService;
        }

        private WarehouseItemsViewModel _warehouseItems;
        public WarehouseItemsViewModel WarehouseItems
        {
            get { return _warehouseItems ?? (_warehouseItems = _viewModelCreatorService.CreateViewModel<WarehouseItemsViewModel>()); }
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();
            await _dataService.GetWarehouseItemsAsync();
        }
    }
}