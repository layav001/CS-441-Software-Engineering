using Prism.Commands;
using Prism.Navigation;
using HostnoMore.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace HostnoMore.ViewModels
{
    public class ComboPageViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand NavigateToBlogCommand { get; private set; }

        private List<Blog> _blogs = new List<Blog>()
        {
            new Blog
            {
                BlogDescription = "Chicken Sandwitch with fries and a Drink ",
                BlogTitle = "Combo 1",
                PriceSmall = 10.3,
                PriceMedium = 11.05,
                PriceLarge = 11.8,
                imageName = "chickenSandwitch.jpg"
            },

            new Blog
            {
                BlogDescription = "Spicy Chicken Sandwitch with Fries and a Drink",
                BlogTitle = "Combo 2",
                PriceSmall = 10.8,
                PriceMedium = 11.55,
                PriceLarge = 12.3,
                imageName = "SpicyChicken.jpg"
            },


            new Blog
            {
                BlogDescription = "Chicken Nuggets  with Fries and a Drink",
                BlogTitle = "Combo 3",
                PriceSmall = 8.25,
                PriceMedium = 9.00,
                PriceLarge = 9.75,
                imageName = "ChickenNuggets2.jpg"
            },


            new Blog
            {
                BlogDescription = "Salad",
                BlogTitle = "Combo 4",
                PriceSmall = 13.5,
                PriceMedium = 14.25,
                PriceLarge = 15.00,
                imageName = "ChickenSaladEntree.jpg"
            },

        };

        private Blog _selectedBlog;
        public Blog SelectedBlog
        {
            get { return _selectedBlog; }
            set { SetProperty(ref _selectedBlog, value); }
        }

        public List<Blog> Blogs
        {
            get { return _blogs; }
            set { SetProperty(ref _blogs, value); }
        }
        public ComboPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Blogs";
            NavigateToBlogCommand = new DelegateCommand(NavigateToBlog, () => SelectedBlog != null).ObservesProperty(() => SelectedBlog);

        }

        public DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("");
        }
        private void NavigateToBlog()
        {
            var parameter = new NavigationParameters();
            parameter.Add("Blog", SelectedBlog);
            NavigationService.NavigateAsync("Blog", parameter);
        }
    }
}
