using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using IronTemple.Models;
using IronTemple.Views;

namespace IronTemple.ViewModels
{
    public class AddExerciseViewModel : BaseViewModel
    {
        public ObservableCollection<Exercise> Exercises { get; set; }
        public Command LoadExercisesCommand { get; set; }

        public AddExerciseViewModel()
        {
            Title = "Exercises";
            Exercises = new ObservableCollection<Exercise>();
            LoadExercisesCommand = new Command(async () => await ExecuteLoadExercisesCommand());

            MessagingCenter.Subscribe<NewExercisePage, Exercise>(this, "AddItem", async (obj, exercise) =>
            {
                var newExercise = exercise as Exercise;
                Exercises.Add(newExercise);
                await ExerciseDataStore.AddItemAsync(newExercise);
            });
        }

        async Task ExecuteLoadExercisesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Exercises.Clear();
                var exercises = await ExerciseDataStore.GetItemsAsync(true);
                foreach (var exercise in exercises)
                {
                    Exercises.Add(exercise);
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