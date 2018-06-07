using System;
using System.Collections.Generic;
using MyCycle.ViewModels;
using Xamarin.Forms;

namespace MyCycle.Views
{
    public partial class PeriodsPage : ContentPage
    {
        PeriodsViewModel periodModel;
        public PeriodsPage()
        {
            InitializeComponent();
            BindingContext = periodModel = new PeriodsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }
    }
}
