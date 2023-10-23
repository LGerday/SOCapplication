
using System;
using soc.Core;

namespace soc.Services;

public interface INavigationService
{
    Core.ViewModel CurrentView { get; }
    void NavigateTo<T>() where T : Core.ViewModel;
}
public class NavigationService : ObservableObject , INavigationService
{
    private Core.ViewModel _currentView;
    private readonly Func<Type,Core.ViewModel> _viewModelFactory;


    public Core.ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type,Core.ViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<TViewModel>() where TViewModel : Core.ViewModel
    {
        Core.ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}