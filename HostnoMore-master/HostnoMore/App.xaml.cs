using System;
using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HostnoMore.Views;
using HostnoMore.ViewModels;
using HostnoMore.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HostnoMore
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer = null) : base(initializer){}

        protected override async void OnInitialized()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)})");
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(LoginPage)}");
        }

        protected override void RegisterTypes(Prism.Ioc.IContainerRegistry containerRegistry)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)})");
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisrationPage, RegisrationViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, HostnoMoreHomePageViewModel>();
            containerRegistry.RegisterForNavigation<CallsPage, CallsPageViewModel>();
            containerRegistry.RegisterForNavigation<CallsChickFilaPage, CallsChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<ChooseSeatingPage, ChooseSeatingPageViewModel>();
            containerRegistry.RegisterForNavigation<ChickFilaSeatPage, ChickFilaSeatPageViewModel>();
            containerRegistry.RegisterForNavigation<ComboPage,ComboPageViewModel>();
            containerRegistry.RegisterForNavigation<ComboPage1, ComboPageViewModel1>();
            containerRegistry.RegisterForNavigation<SidePage, SidePageViewModel>();
            containerRegistry.RegisterForNavigation<SidePage1, SidePageViewModel1>();
            containerRegistry.RegisterForNavigation<Blog>();
            containerRegistry.RegisterForNavigation<EntreeSelectionPage, EntreeSelectionPageViewModel>();
            containerRegistry.RegisterForNavigation<Entree, EntreeViewModel>();
            containerRegistry.RegisterForNavigation<EntreeSelectionPage1, EntreeSelectionPageViewModel1>();
            containerRegistry.RegisterForNavigation<Entree1, EntreeViewModel1>();
            containerRegistry.RegisterForNavigation<MenuOneContainerPage, MenuOneContainerPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuTwoContainerPage, MenuTwoContainerPageViewModel>();
            containerRegistry.RegisterForNavigation<CartChickFilaPage, CartChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<CartPage, CartPageViewModel>();
            containerRegistry.RegisterForNavigation<CashPage, CashPageViewModel>();
            containerRegistry.RegisterForNavigation<PaymentPage, PaymentPageViewModel>();
            containerRegistry.RegisterForNavigation<CreditInfoPage, CreditInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<PaymentChickFilaPage, PaymentChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<CreditInfoChickFilaPage, CreditInfoChickFilaPageViewModel>();
            containerRegistry.RegisterForNavigation<ConfirmationPage, ConfirmationPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantSidePage, RestaurantSidePageViewModel>();
            containerRegistry.RegisterForNavigation<ConfirmationChickFilaPage, ConfirmationChickFilaPageViewModel>();
            containerRegistry.RegisterSingleton<IRepository, Repository>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
