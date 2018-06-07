using System;
using System.Collections.Generic;
using MyCycle.Models;
using Xamarin.Forms;

namespace MyCycle.Views
{
    public partial class NewPeriodPage : ContentPage
    {
        public Period Period { get; set; }
        public NewPeriodPage()
        {
            InitializeComponent();
            Period = new Period
            {
                InitialDate = "01/01/2017",
                Finaldate = "01/05/2017"
            };
            BindingContext = this;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPeriod", Period);
            await Navigation.PopModalAsync();
        }


        private void DatePicker_Initial(object sender, DateChangedEventArgs e)
        {
            InitialDate.Date = e.NewDate;
        }

        private void DatePicker_Final(object sender, DateChangedEventArgs e)
        {
            Finaldate.Date = e.NewDate;
        }
    }
}
