using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Fox.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private static Type _currentViewModel;

        public NavigationService(IMvxNavigationService  mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public event BeforeNavigateEventHandler BeforeNavigate
        {
            add
            {
                _mvxNavigationService.BeforeNavigate += value;
            }

            remove
            {
                _mvxNavigationService.BeforeNavigate -= value;
            }
        }

        public event AfterNavigateEventHandler AfterNavigate
        {
            add
            {
                _mvxNavigationService.AfterNavigate += value;
            }

            remove
            {
                _mvxNavigationService.AfterNavigate -= value;
            }
        }

        public event BeforeCloseEventHandler BeforeClose
        {
            add
            {
                _mvxNavigationService.BeforeClose += value;
            }

            remove
            {
                _mvxNavigationService.BeforeClose -= value;
            }
        }

        public event AfterCloseEventHandler AfterClose
        {
            add
            {
                _mvxNavigationService.AfterClose += value;
            }

            remove
            {
                _mvxNavigationService.AfterClose -= value;
            }
        }

        public event BeforeChangePresentationEventHandler BeforeChangePresentation
        {
            add
            {
                _mvxNavigationService.BeforeChangePresentation += value;
            }

            remove
            {
                _mvxNavigationService.BeforeChangePresentation -= value;
            }
        }

        public event AfterChangePresentationEventHandler AfterChangePresentation
        {
            add
            {
                _mvxNavigationService.AfterChangePresentation += value;
            }

            remove
            {
                _mvxNavigationService.AfterChangePresentation -= value;
            }
        }

        public Task<bool> Navigate(IMvxViewModel viewModel, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(viewModel, presentationBundle, cancellationToken);
        }

        public Task<bool> Navigate<TParameter>(IMvxViewModel<TParameter> viewModel, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(viewModel, param, presentationBundle, cancellationToken);
        }

        public Task<TResult> Navigate<TResult>(IMvxViewModelResult<TResult> viewModel, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(viewModel, presentationBundle, cancellationToken);
        }

        public Task<TResult> Navigate<TParameter, TResult>(IMvxViewModel<TParameter, TResult> viewModel, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(viewModel, param, presentationBundle, cancellationToken);
        }

        public Task<bool> Navigate(Type viewModelType, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(viewModelType, presentationBundle, cancellationToken);
        }

        public Task<bool> Navigate<TParameter>(Type viewModelType, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(viewModelType, param, presentationBundle, cancellationToken);
        }

        public Task<TResult> Navigate<TResult>(Type viewModelType, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate<TResult>(viewModelType, presentationBundle, cancellationToken);
        }

        public Task<TResult> Navigate<TParameter, TResult>(Type viewModelType, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate<TParameter, TResult>(viewModelType, param, presentationBundle, cancellationToken);
        }

        public Task<bool> Navigate(string path, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(path, presentationBundle, cancellationToken);
        }

        public Task<bool> Navigate<TParameter>(string path, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate(path, param, presentationBundle, cancellationToken);
        }

        public Task<TResult> Navigate<TResult>(string path, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate<TResult>(path, presentationBundle, cancellationToken);
        }

        public Task<TResult> Navigate<TParameter, TResult>(string path, TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Navigate<TParameter, TResult>(path, param, presentationBundle, cancellationToken);
        }

        public Task<bool> Navigate<TViewModel>(IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel
        {
            if (CanNavigateOnVM(typeof(TViewModel)))
            {
                return _mvxNavigationService.Navigate<TViewModel>(presentationBundle, cancellationToken);
            }

            return Task.FromResult(false);
        }

        public Task<bool> Navigate<TViewModel, TParameter>(TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter>
        {
            if (CanNavigateOnVM(typeof(TViewModel)))
            {
                return _mvxNavigationService.Navigate<TViewModel>(presentationBundle, cancellationToken);
            }

            return Task.FromResult(false);
        }

        public Task<TResult> Navigate<TViewModel, TResult>(IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModelResult<TResult>
        {
            return _mvxNavigationService.Navigate<TViewModel, TResult>(presentationBundle, cancellationToken);
        }

        public Task<TResult> Navigate<TViewModel, TParameter, TResult>(TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter, TResult>
        {
            return _mvxNavigationService.Navigate<TViewModel, TParameter, TResult>(param, presentationBundle, cancellationToken);
        }

        public Task<bool> CanNavigate(string path)
        {
            return _mvxNavigationService.CanNavigate(path);
        }

        public Task<bool> CanNavigate<TViewModel>() where TViewModel : IMvxViewModel
        {
            return _mvxNavigationService.CanNavigate<TViewModel>();
        }

        public Task<bool> CanNavigate(Type viewModelType)
        {
            return _mvxNavigationService.CanNavigate(viewModelType);
        }

        public Task<bool> Close(IMvxViewModel viewModel, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Close(viewModel, cancellationToken);
        }

        public Task<bool> Close<TResult>(IMvxViewModelResult<TResult> viewModel, TResult result, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.Close(viewModel, result, cancellationToken);
        }

        public Task<bool> ChangePresentation(MvxPresentationHint hint, CancellationToken cancellationToken = default)
        {
            return _mvxNavigationService.ChangePresentation(hint, cancellationToken);
        }

        private bool CanNavigateOnVM(Type viewModel)
        {
            if(_currentViewModel == null)
            {
                _currentViewModel = viewModel;
                return true;
            }

            if (_currentViewModel.Equals(viewModel))
            {
                return false;
            }

            _currentViewModel = viewModel;
            return true;
        }
    }
}
