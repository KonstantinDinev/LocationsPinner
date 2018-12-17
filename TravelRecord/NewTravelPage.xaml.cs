using System;
using SQLite;
using System.Collections.Generic;
using TravelRecord.Model;
using Xamarin.Forms;

using Plugin.Geolocator;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        NewTravelViewModel viewModel;
        public NewTravelPage()
        {
            InitializeComponent();

            viewModel = new NewTravelViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }
    }
}
