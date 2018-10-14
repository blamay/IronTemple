using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using IronTemple.Models;
using IronTemple.Views;

namespace IronTemple.ViewModels
{
    public class WorkoutsViewModel : BaseViewModel
    {
        public ObservableCollection<Workout> Workouts { get; set; }
        public Command LoadWorkoutsCommand { get; set; }

        public WorkoutsViewModel()
        {
            Title = "Workouts";
            Workouts = new ObservableCollection<Workout>();
            LoadWorkoutsCommand = new Command(async () => await ExecuteLoadWorkoutsCommand());

            MessagingCenter.Subscribe<NewWorkoutPage, Workout>(this, "AddItem", async (obj, workout) =>
            {
                var newWorkout = workout as Workout;
                Workouts.Add(newWorkout);
                await WorkoutDataStore.AddItemAsync(newWorkout);
            });
        }

        async Task ExecuteLoadWorkoutsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Workouts.Clear();
                var workouts = await WorkoutDataStore.GetItemsAsync(true);
                foreach (var workout in workouts)
                {
                    Workouts.Add(workout);
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