using Prism.Commands;
using Prism.Navigation;
using HostnoMore.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using HostnoMore.Services;
using System.Threading.Tasks;
using Prism.Services;

namespace HostnoMore.ViewModels
{
    public class SidePageViewModel : ViewModelBase
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
                BlogDescription = "Fries",
                BlogTitle = "Fries",
                PriceSmall = 2.50,
                PriceMedium = 2.50,
                PriceLarge = 2.50,
                imageName = "friesSides.png"
            },

            new Blog
            {
                BlogDescription = "Chicken Sliders",
                BlogTitle = "Chicken Sliders",
                PriceSmall = 2.50,
                PriceMedium = 2.50,
                PriceLarge = 2.50,
                imageName = "Sliders.png"
            },


            new Blog
            {
                BlogDescription = "Hash Browns",
                BlogTitle = "Hash Browns",
                PriceSmall = 3.25,
                PriceMedium = 3.25,
                PriceLarge = 3.25,
                imageName = "HashBrownsSides.png"
            },


            new Blog
            {
                BlogDescription = "Mac And Cheese",
                BlogTitle = "Mac And Cheese",
                PriceSmall = 5.45,
                PriceMedium = 5.45,
                PriceLarge = 5.45,
                imageName = "MacAndCheeseSide.jpg"
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
        public SidePageViewModel(INavigationService navigationService)
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
