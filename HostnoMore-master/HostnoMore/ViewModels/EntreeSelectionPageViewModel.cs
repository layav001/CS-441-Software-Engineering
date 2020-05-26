using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using HostnoMore.Models;

namespace HostnoMore.ViewModels
{
    public class EntreeSelectionPageViewModel : ViewModelBase
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
                EntreeDescription = "Chicken Sandwitch",
                entreeTitle = "Chicken Sandwitch",
                price = "Price: 9.75$",
                imageName = "ChickenSandwitchEntree.png"
            },
            new Entree
            {
                EntreeDescription = "Spicy Chicken Sandwitch",
                entreeTitle = "Spicy Chicken Sandwitch",
                price = "Price: 9.75$",
                imageName = "SpicyChickenSandwitchEntree.jpg"
            },
            new Entree
            {
                EntreeDescription = "Chicken nuggets",
                entreeTitle = "Chicken nuggets",
                price = "Price: 9.75$",
                imageName = "ChickenNuggetsEntree.jpg"
            },
            new Entree
            {
                EntreeDescription = "Chicken Salad",
                entreeTitle = "Chicken salad",
                price = "Price: 9.75$",
                imageName = "ChickenSaladEntree.png"
            },
            new Entree
            {
                EntreeDescription = "Chicken Wrap",
                entreeTitle = "Chicken Wrap",
                price = "Price: 9.75$",
                imageName = "ChickenWrapEntree.png"
            },
            new Entree
            {
                EntreeDescription = "Vegan Stuff",
                entreeTitle = "Vegan Stuff",
                price = "Price: 9.75$",
                imageName = "chickenSandwitch.jpg"
            }


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
        public EntreeSelectionPageViewModel(INavigationService navigationService)
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
            NavigationService.NavigateAsync("Entree", parameter);
        }
    }
}

