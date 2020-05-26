using Prism.Navigation;
using HostnoMore.Models;
using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms;
using HostnoMore.Services;
using System.Threading.Tasks;
using Prism.Services;

namespace HostnoMore.ViewModels
{
    public class BlogViewModel : ViewModelBase, INavigationAware
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
        public DelegateCommand TapToOrder1 { get; set; }
        public DelegateCommand TapToOrder2 { get; set; }
        public DelegateCommand TapToOrder3 { get; set; }
        public BlogViewModel(INavigationService navigationService, IRepository repository, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _repo = repository;

            nav_service = navigationService;
            page_service = pageDialogService;
            TapToOrder1 = new DelegateCommand(AddToCart1);
            TapToOrder2 = new DelegateCommand(AddToCart2);
            TapToOrder3 = new DelegateCommand(AddToCart3);
        }

        private Blog _blogDetail;
        public Blog BlogDetail
        {
            get { return _blogDetail; }
            set { SetProperty(ref _blogDetail, value); }
        }

        private async void AddToCart1()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart1)}");
            // PlaceOrder = BlogDetail.BlogDescription + " " + BlogDetail.Price;
            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem1 = new OrderItem
                {
                    Item = this.PlaceOrder
                };
                BlogDetail.Price = BlogDetail.PriceSmall;
                await _repo.AddItem1(BlogDetail);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", BlogDetail);
                await Task.Delay(1);
            }
        }

        private async void AddToCart2()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart2)}");
            PlaceOrder = BlogDetail.BlogDescription + " " + BlogDetail.Price;
            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem1 = new OrderItem
                {
                    Item = this.PlaceOrder
                };
                BlogDetail.Price = BlogDetail.PriceMedium;
                await _repo.AddItem1(BlogDetail);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", BlogDetail);
                await Task.Delay(1);
            }
        }

        private async void AddToCart3()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddToCart3)}");
            PlaceOrder = BlogDetail.BlogDescription + " " + BlogDetail.Price;
            bool userResponse = await page_service.DisplayAlertAsync("Add Item?", "Are you sure you want to add item to cart?", "Ok", "Cancel");
            if (userResponse == false)
                return;
            else
            {
                OrderItem newItem1 = new OrderItem
                {
                    Item = this.PlaceOrder
                };
                BlogDetail.Price = BlogDetail.PriceLarge;
                await _repo.AddItem1(BlogDetail);
                var navParams = new NavigationParameters();
                navParams.Add("ItemAdded", BlogDetail);
                await Task.Delay(1);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            BlogDetail = (Blog)parameters["Blog"];
            Title = BlogDetail.BlogTitle;
            base.OnNavigatedTo(parameters);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }
        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }
    }
}
