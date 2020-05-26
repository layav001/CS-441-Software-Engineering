using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HostnoMore.Models;
using HostnoMore.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using HostnoMore.Helper;
using Xamarin.Forms;

namespace HostnoMore.ViewModels
{
    public class RegisrationViewModel : BindableBase, INavigationAware
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        INavigationService nav_service;
        IPageDialogService _pageDialogService;
        IRepository _repo;

        public DelegateCommand CreditInfoPageCommand { get; set; }
        public DelegateCommand GoBackToPaymentPageCommand { get; set; }

        private string Username_Entry;
        public string UsernameEntry
        {
            get { return Username_Entry; }
            set { SetProperty(ref Username_Entry, value); }
        }

        private string Name_Entry;
        public string NameEntry
        {
            get { return Name_Entry; }
            set { SetProperty(ref Name_Entry, value); }
        }

        private string DateOfBirthMonth_Entry;
        public string DateOfBirthMonthEntry
        {
            get { return DateOfBirthMonth_Entry; }
            set { SetProperty(ref DateOfBirthMonth_Entry, value); }
        }

        private string DateOfBirthYear_Entry;
        public string DateOfBirthYearEntry
        {
            get { return DateOfBirthYear_Entry; }
            set { SetProperty(ref DateOfBirthYear_Entry, value); }
        }

        private string Password_Entry;
        public string PasswordEntry
        {
            get { return Password_Entry; }
            set { SetProperty(ref Password_Entry, value); }
        }

        public RegisrationViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IRepository repository)
        {
            nav_service = navigationService;
            _pageDialogService = pageDialogService;
            _repo = repository;

            CreditInfoPageCommand = new DelegateCommand(GoToNextPage);
        }

        private async void GoToNextPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToNextPage)}");

            if (string.IsNullOrEmpty(Username_Entry) || string.IsNullOrEmpty(Name_Entry) || string.IsNullOrEmpty(DateOfBirthMonth_Entry) || string.IsNullOrEmpty(DateOfBirthMonth_Entry)
                 || string.IsNullOrEmpty(DateOfBirthYear_Entry) || string.IsNullOrEmpty(Password_Entry))
            {
                await _pageDialogService.DisplayAlertAsync("Error", "You must fill out all fields", "Dismiss");
                return;
            }
            else
            {
                if (Username_Entry.Length < 0)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "Username is invalid", "Dismiss");
                    return;
                }
                else if (Name_Entry.Length < 0)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid name", "Dismiss");
                    return;
                }
                else if (DateOfBirthMonth_Entry.Length != 2)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid month", "Dismiss");
                    return;
                }
                else if (DateOfBirthYear_Entry.Length != 4)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid year", "Dismiss");
                    return;
                }
                else if (Password_Entry.Length < 0)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "You must enter a valid password", "Dismiss");
                    return;
                }
                else
                {
                    var person = await firebaseHelper.GetPerson(Name_Entry, Password_Entry);
                    if (person == null)
                    {
                        firebaseHelper.AddPerson(Username_Entry, Name_Entry, Password_Entry);
                    }
                   
                    await nav_service.NavigateAsync("LoginPage", null);
                }
            }
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

