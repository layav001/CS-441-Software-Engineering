using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace HostnoMore.ViewModels
{
    public class MenuOneContainerPageViewModel : BindableBase
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
        public DelegateCommand GoToCart { get; set; }

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public MenuOneContainerPageViewModel(INavigationService navigationService)
        {
            Title = "MainPage";
            _navigationService = navigationService;

            GoToCart = new DelegateCommand(OnToCart);
        }
        private async void OnToCart()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnToCart)}");

            await _navigationService.NavigateAsync("CartPage", null);
        }
        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("ComboPage1");
        }
        async void ExecuteNavigateCommand2()
        {
            await _navigationService.NavigateAsync("EntreeSelectionPage1");
        }
        async void ExecuteNavigateCommand3()
        {
            await _navigationService.NavigateAsync("SidePage1");
        }

    }
}

