using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HostnoMore.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string page;
        public DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public MainPageViewModel(INavigationService navigationService)
        {
            Title = "MainPage";
            _navigationService = navigationService;
        }
        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("ComboPage");
        }
        async void ExecuteNavigateCommand2()
        {
            await _navigationService.NavigateAsync("EntreeSelectionPage");
        }
        async void ExecuteNavigateCommand3()
        {
            await _navigationService.NavigateAsync("");
        }
    }
}
