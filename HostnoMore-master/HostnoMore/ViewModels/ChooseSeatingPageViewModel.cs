﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using HostnoMore.Models;
using HostnoMore.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace HostnoMore.ViewModels
{
    public class ChooseSeatingPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService _pageDialogService;
        IRepository _repo;

        public DelegateCommand<OrderItem> GoToMenuPage { get; set; }

        private ObservableCollection<OrderItem> _item;
        public ObservableCollection<OrderItem> Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        private string selectedSeat;
        public string SelectedSeat
        {
            get { return selectedSeat; }
            set { SetProperty(ref selectedSeat, value); }
        }

        List<string> availableSeats;
        public List<string> AvailableSeats
        {
            get { return availableSeats; }
            set { SetProperty(ref availableSeats, value); }
        }

        public ChooseSeatingPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IRepository repository)
        {
            nav_service = navigationService;
            _pageDialogService = pageDialogService;
            _repo = repository;

            availableSeats = new List<string>()
            {
                "1","2","3","4","5","6","7"
            };

            GoToMenuPage = new DelegateCommand<OrderItem>(OntoNextPage);
        }

        private async void OntoNextPage(OrderItem listOfItems)
        {
            if (string.IsNullOrEmpty(selectedSeat))
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Must select a seat", "Dismiss");
                return;
            }
            else
            {
                await nav_service.NavigateAsync("MenuOneContainerPage", null);

                RestaurantSideItem seat = new RestaurantSideItem
                {
                    Item = this.SelectedSeat
                };

                await _repo.AddItem(seat);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", navParams);
                await Task.Delay(1);

                _repo.RemoveAllItems(listOfItems);
            }
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }
    }
}


