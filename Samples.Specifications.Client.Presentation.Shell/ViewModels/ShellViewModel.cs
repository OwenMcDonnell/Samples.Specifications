﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Core;
using Samples.Client.Model.Shared;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;
using Samples.Specifications.Client.Presentation.Shell.Properties;
using Solid.Practices.Scheduling;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{    
    [UsedImplicitly]
    public sealed class ShellViewModel : Conductor<INotifyPropertyChanged>.Collection.OneActive, IShellViewModel
    {
        private readonly IWindowManager _windowManager;
        private readonly IViewModelCreatorService _viewModelCreatorService;

        public ShellViewModel(
            IWindowManager windowManager,
            IViewModelCreatorService viewModelCreatorService)
        {
            _windowManager = windowManager;
            _viewModelCreatorService = viewModelCreatorService;

            EventHandler strongHandler = OnLoggedInSuccessfully;
            LoginViewModel.LoggedInSuccessfully += WeakDelegate.From(strongHandler);
        }

        private IActionCommand _closeCommand;

        public ICommand CloseCommand =>
            CommandFactory.GetCommand(ref _closeCommand, () => TryClose(), () => true);

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        public bool IsLoggedIn => UserContext.Current != null;

        private LoginViewModel _loginViewModel;
        public ILoginViewModel LoginViewModel => _loginViewModel ?? (_loginViewModel = CreateLoginViewModel());

        private LoginViewModel CreateLoginViewModel()
        {
            return _viewModelCreatorService.CreateViewModel<LoginViewModel>();
        }

        private MainViewModel _mainViewModel;
        public IMainViewModel MainViewModel => _mainViewModel ?? (_mainViewModel = CreateMainViewModel());

        private MainViewModel CreateMainViewModel()
        {
            return _viewModelCreatorService.CreateViewModel<MainViewModel>();
        }

        public override string DisplayName
        {
            get => string.Empty;
            set { }
        }

        private async Task Close()
        {
            await TaskRunner.RunAsync(() => Dispatch.Current.OnUiThread(() =>
            {
                TryClose();
            }));
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            _windowManager.ShowDialog(LoginViewModel);

            if (UserContext.Current == null)
            {
                await Close();
            }
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                Settings.Default.Save();
            }

            base.OnDeactivate(close);
        }

        private void OnLoggedInSuccessfully(object sender, EventArgs eventArgs)
        {
            ActivateItem(MainViewModel);
        }

        public void Dispose()
        {
            _closeCommand?.Dispose();
            foreach (var item in Items.OfType<IDisposable>())
            {
                item.Dispose();
            }
        }
    }
}
