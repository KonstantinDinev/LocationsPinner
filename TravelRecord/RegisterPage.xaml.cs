using System;
using System.Collections.Generic;
using TravelRecord.Model;

using Xamarin.Forms;

namespace TravelRecord
{
    public partial class RegisterPage : ContentPage
    {
        RegisterViewModel viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            viewModel = new RegisterViewModel();
            BindingContext = viewModel;
        }
    }
}