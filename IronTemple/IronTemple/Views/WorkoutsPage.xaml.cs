using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IronTemple.Models;
using IronTemple.Views;
using IronTemple.ViewModels;

namespace IronTemple.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        WorkoutsViewModel viewModel;

        public WorkoutsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WorkoutsViewModel();
        }

        async void OnWorkoutSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var workout = args.SelectedItem as Workout;
            if (workout == null)
                return;

            await Navigation.PushAsync(new WorkoutDetailPage(new WorkoutDetailViewModel(workout)));

            // Manually deselect workout.
            WorkoutsListView.SelectedItem = null;
        }

        async void AddWorkout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewWorkoutPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Workouts.Count == 0)
                viewModel.LoadWorkoutsCommand.Execute(null);
        }
    }
}