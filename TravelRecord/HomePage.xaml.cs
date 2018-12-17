using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TravelRecord
{
    public partial class HomePage : TabbedPage
    {
        HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            viewModel = new HomeViewModel();
            BindingContext = viewModel;
        }
    }
}
