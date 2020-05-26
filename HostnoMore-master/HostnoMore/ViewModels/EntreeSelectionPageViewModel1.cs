using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using HostnoMore.Models;

namespace HostnoMore.ViewModels
{
    public class EntreeSelectionPageViewModel1 : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand NavigateToBlogCommand { get; private set; }

        private List<Entree> _Entree = new List<Entree>()
        {
            new Entree
            {
                EntreeDescription = "DOUBLE–DOUBLE ®",
                entreeTitle = "DOUBLE–DOUBLE ®",
                price = "Price: $3.95",
                imageName = "doubledouble1.jpg"
            },
            new Entree
            {
                EntreeDescription = "Cheeseburger",
                entreeTitle = "Cheeseburger",
                price = "Price: $2.80",
                imageName = "cheeseburger1.jpg"
            },
            new Entree
            {
                EntreeDescription = "Hamburger",
                entreeTitle = "Hamburger",
                price = "Price: $2.50",
                imageName = "hamburger1.jpg"
            },
            new Entree
            {
                EntreeDescription = "French Fries",
                entreeTitle = "French Fries",
                price = "Price: $1.90",
                imageName = "fries1.jpg"
            },
 
        };

        private Entree _selectedEntree;
        public Entree SelectedEntree
        {
            get { return _selectedEntree; }
            set { SetProperty(ref _selectedEntree, value); }
        }

        public List<Entree> Entrees
        {
            get { return _Entree; }
            set { SetProperty(ref _Entree, value); }
        }
        public EntreeSelectionPageViewModel1(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Entrees";
            NavigateToBlogCommand = new DelegateCommand(NavigateToBlog, () => SelectedEntree != null).ObservesProperty(() => SelectedEntree);

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
            parameter.Add("Entree", SelectedEntree);
            NavigationService.NavigateAsync("Entree1", parameter);
        }
    }
}

