using System;

using Xamarin.Forms;

namespace HostnoMore.ViewModels
{
    public class RestaurantSidePageViewModel : ContentPage
    {
        public RestaurantSidePageViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

