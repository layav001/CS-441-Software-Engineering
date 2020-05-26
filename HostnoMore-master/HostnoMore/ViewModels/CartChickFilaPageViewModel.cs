using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using HostnoMore.Services;
using HostnoMore.Models;
using Prism.Services;

namespace HostnoMore.ViewModels
{
    public class CartChickFilaPageViewModel : BindableBase, INavigationAware
    {
        INavigationService nav_service;
        IPageDialogService page_service;
        IRepository _repo;

        public DelegateCommand CheckoutCommand { get; set; }
        public DelegateCommand PullToRefreshCommand { get; set; }
        public DelegateCommand<Blog> DeleteCommand { get; set; }

        private ObservableCollection<Blog> food_item;
        public ObservableCollection<Blog> FoodItem
        {
            get { return food_item; }
            set { SetProperty(ref food_item, value); }
        }

        private string total_items;
        public string TotalItems
        {
            get { return total_items; }
            set { SetProperty(ref total_items, value); }
        }

        private double total;
        public double Total
        {
            get { return total; }
            set { SetProperty(ref total, value); }
        }
        private ObservableCollection<Blog> _itemDetail;
        public ObservableCollection<Blog> ItemDetail
        {
            get { return _itemDetail; }
            set { SetProperty(ref _itemDetail, value); }
        }


        private bool _showIsBusySpinner;
        public bool ShowIsBusySpinner
        {
            get { return _showIsBusySpinner; }
            set { SetProperty(ref _showIsBusySpinner, value); }
        }

        
        public CartChickFilaPageViewModel(INavigationService navigationService, IRepository repository, IPageDialogService pageDialogService)
        {
            RefreshItemList();
            nav_service = navigationService;
            page_service = pageDialogService;
            _repo = repository;
            RefreshItemList();
            CheckoutCommand = new DelegateCommand(GoToPaymentsPage);
            PullToRefreshCommand = new DelegateCommand(OnPullToRefresh);
            DeleteCommand = new DelegateCommand<Blog>(OnDeleteTapped);
            Total = _repo.GetTotal();
            RefreshItemList();
        }
        private async void OnPullToRefresh()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnPullToRefresh)}");

            await RefreshItemList();
        }

        private async Task RefreshItemList()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RefreshItemList)}");
            if (ItemDetail == null)
            {
                ShowIsBusySpinner = true;
                ItemDetail = new ObservableCollection<Blog>();
                ShowIsBusySpinner = false;
            }
            else
            {
                ShowIsBusySpinner = true;
                var itemsList = await _repo.GetItem1();
                if (itemsList != null)
                {
                    ItemDetail = new ObservableCollection<Blog>(itemsList);
                }
                ShowIsBusySpinner = false;
            }
        }

        private void OnDeleteTapped(Blog itemToDelete)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnDeleteTapped)}:  {itemToDelete}");
            _repo.RemoveItem1(itemToDelete);
            ItemDetail.Remove(itemToDelete);
        }

        private async void GoToPaymentsPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToPaymentsPage)}");

            if (ItemDetail.Count == 0)
            {
                await page_service.DisplayAlertAsync("Error", "Your cart is empty", "Dismiss");
                return;
            }
            else
            {
                await nav_service.NavigateAsync("PaymentPage", null);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
            RefreshItemList();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
            RefreshItemList();
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            RefreshItemList();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");

            if (parameters != null && parameters.ContainsKey("ItemAdded"))
            {
                if (ItemDetail == null)
                {
                    ItemDetail = new ObservableCollection<Blog>();
                }
                var itemToAdd = (Blog)parameters["ItemAdded"];
                ItemDetail.Add(itemToAdd);

                TotalItems = itemToAdd.ToString();
            }
            await RefreshItemList();
        }
    }
}
