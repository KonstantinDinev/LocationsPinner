using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecord.Model;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //Plugin.Xam.Geolocator
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;

                await locator.StartListeningAsync(new TimeSpan(0, 0, 0), 100);

                var position = await locator.GetPositionAsync(); //longitude and latitude

                var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
                var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
                //x:Name
                locationsMap.MoveToRegion(span);


                //Get Posts Info from SQLite
                //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //{
                //    conn.CreateTable<Post>();
                //    var posts = conn.Table<Post>().ToList();

                //    DisplayInMap(posts);
                //}

                var posts = await Post.Read();
                DisplayInMap(posts);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;

            await locator.StopListeningAsync();
        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach(var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SearchResult,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };


                    locationsMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre) 
                { 
                    Console.WriteLine(nre); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception " + ex);
                }
            }
        }

        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            //x:Name
            locationsMap.MoveToRegion(span);
        }

    }
}
