using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HostnoMore.Models;
using HostnoMore.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using HostnoMore.Helper;
using Prism.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using Plugin.ExternalMaps;

namespace HostnoMore.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        IPageDialogService _pageDialogService;

        INavigationService _navigationService;
        public DelegateCommand loginButton { get; set; }
        public DelegateCommand RegisterButton { get; set; }

        private string rest_id;
        public string restID
        {
            get { return rest_id; }
            set { SetProperty(ref rest_id, value); }
        }

        private string rest_password;
        public string restPassword
        {
            get { return rest_password; }
            set { SetProperty(ref rest_password, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            loginButton = new DelegateCommand(GoToMainPage);
            RegisterButton = new DelegateCommand(GoToRegister);
        }

        private async void GoToMainPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToMainPage)}");

            if(firebaseHelper.GetPerson(rest_id, rest_password) != null)
            {
                await _navigationService.NavigateAsync("MainPage", null);
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Username or password is invalid", "Dismiss");
            }
            

        }

        private async void GoToRegister()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToRegister)}");

            await _navigationService.NavigateAsync("RegisrationPage", null);

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }
    }
}

