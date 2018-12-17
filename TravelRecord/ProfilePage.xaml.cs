using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TravelRecord.Model;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
                //var postTable = conn.Table<Post>().ToList();
                // Switching to the Cloud instead of local DB 
                var postTable = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();



                categoriesListView.ItemsSource = Post.PostCategories(postTable);

                postCountLabel.Text = postTable.Count.ToString();
            //}
        }

    }
}
