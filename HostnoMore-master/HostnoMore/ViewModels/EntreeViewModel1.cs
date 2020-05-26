using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using HostnoMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Xamarin.Forms;
using HostnoMore.Services;
using System.Threading.Tasks;
using Prism.Services;

namespace HostnoMore.ViewModels
{
    public class EntreeViewModel1 : ViewModelBase
    {

        INavigationService nav_service;
        IPageDialogService page_service;
        IRepository _repo;
        private string place_order;
        public string PlaceOrder
        {
            get { return place_order; }
            set { SetProperty(ref place_order, value); }
        }
        public DelegateCommand TapToOrder { get; set; }
        public EntreeViewModel1(INavigationService navigationService, IRepository repository, IPageDialogService pageDialogService)
              : base(navigationService)
        {
            _repo = repository;

            nav_service = navigationService;
            page_service = pageDialogService;
            TapToOrder = new DelegateCommand(AddToCart);
        }

        private Entree _EntreeDetail1;
        public Entree EntreeDetail1
        {
            get { return _EntreeDetail1; }
            set { SetProperty(ref _EntreeDetail1, value); }
        }
        private async void AddToCart()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart)}");
            PlaceOrder = EntreeDetail1.EntreeDescription + " " + EntreeDetail1.price;
            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem = new OrderItem
                {
                    Item = this.PlaceOrder
                };
                await _repo.AddItem(newItem);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", newItem);
                await Task.Delay(1);
            }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            EntreeDetail1 = (Entree)parameters["Entree"];
            Title = EntreeDetail1.EntreeDescription;
            base.OnNavigatedTo(parameters);
        }
    }
}
