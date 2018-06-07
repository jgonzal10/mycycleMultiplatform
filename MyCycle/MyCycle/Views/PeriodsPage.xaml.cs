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

        async void AddPeriod_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPeriodPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (periodModel.Periods.Count == 0)
                periodModel.LoadPeriodsCommand.Execute(null);
        }
    }
}
