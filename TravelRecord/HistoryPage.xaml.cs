using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;
using TravelRecord.Model;
using TravelRecord.Helpers;

namespace TravelRecord
{
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            viewModel = new HistoryViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.UpdatePosts();

            await AzureAppServiceHelper.SyncAsync();
        }

        void OnDelete(object sender, EventArgs e)
        {
            var post = (Post)((MenuItem)sender).CommandParameter;
            viewModel.DeletePost(post);

            viewModel.UpdatePosts();
        }

        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            await viewModel.UpdatePosts();
            await AzureAppServiceHelper.SyncAsync();

            postListView.EndRefresh();
        }
    }
}
