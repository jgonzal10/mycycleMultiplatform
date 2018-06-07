
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MyCycle.Models;
using MyCycle.Views;
using Xamarin.Forms;

namespace MyCycle.ViewModels
{
    public class PeriodsViewModel : BaseViewModel
    {
        public ObservableCollection<Period> Periods { get; set; }
        public Command LoadPeriodsCommand { get; set; }

        public PeriodsViewModel()
        {
            Title = "Periods";
            Periods = new ObservableCollection<Period>();
                LoadPeriodsCommand = new Command(async () => await ExecuteLoadPeriodCommand());

            MessagingCenter.Subscribe<NewPeriodPage, Period>(this, "AddPeriod", async (obj, period) =>
               {
                   var _period = period as Period;
                   Periods.Add(_period);
                await DataStoreP.AddPeriodAsync(_period);
               });
           }


           async Task ExecuteLoadPeriodCommand()
           {
               if (IsBusy)
                   return;

               IsBusy = true;

               try
               {
                   Periods.Clear();
                var periods = await DataStoreP.GetPeriodsAsync(true);
                   foreach (var period in periods)
                   {
                       Periods.Add(period);
                   }
               }
               catch (Exception ex)
               {
                   Debug.WriteLine(ex);
               }
               finally
               {
                   IsBusy = false;
               }
           }

        }
    }

