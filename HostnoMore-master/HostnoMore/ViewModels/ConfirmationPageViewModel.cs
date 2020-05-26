using System;
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

namespace HostnoMore.ViewModels
{
    public class ConfirmationPageViewModel : BindableBase, INavigationAware
    {
        IPageDialogService displayMessage;
        INavigationService nav_service;
        IRepository _repo;

        public DelegateCommand AnotherOrder { get; set; }

        private string foodDelivery;
        public string FoodDelivery
        {
            get { return foodDelivery; }
            set { SetProperty(ref foodDelivery, value); }
        }

		private double total;
		public double Total
		{
			get { return total; }
			set { SetProperty(ref total, value); }
		}
        public DelegateCommand tipZero { get; set; }
        public DelegateCommand tipFifteen { get; set; }
        public DelegateCommand tipTwenty { get; set; }
        public DelegateCommand deleteTip { get; set; }

        public ConfirmationPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService, IRepository repository)
        {
            displayMessage = pageDialogService;
            nav_service = navigationService;
            _repo = repository;

            FoodDelivery = "Food out for delivery";
            Total = _repo.GetTotal();
            AnotherOrder = new DelegateCommand(GoToHomePage);
            tipZero = new DelegateCommand(TipZero);
            tipFifteen = new DelegateCommand(TipFifteen);
            tipTwenty = new DelegateCommand(TipTwenty);
            deleteTip = new DelegateCommand(DeleteTip);

        }

        private async void GoToHomePage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoToHomePage)}");
            await nav_service.NavigateAsync("MainPage", null);
            RestaurantSideItem foodToDeliver = new RestaurantSideItem
            {
                Item = this.FoodDelivery
            };

            await _repo.AddItem(foodToDeliver);
            var navParams = new NavigationParameters();
            navParams.Add("ItemAdded", navParams);
            await Task.Delay(1);
            //_repo.RemoveAllItems(listOfItems);
        }

        private async void TipZero()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(TipZero)}");
            Total = Total + 0;
        }

        private async void TipFifteen()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(TipFifteen)}");
            var tmp = Total * 0.15;
            Total = Total + tmp;
            Total = Math.Round(Total, 2);
        }

        private async void TipTwenty()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(TipTwenty)}");
            var tmp = Total * 0.20;
            Total = Total + tmp;
            Total = Math.Round(Total, 2);
        }

        private async void DeleteTip()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(TipZero)}");
            Total = _repo.GetTotal();
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
