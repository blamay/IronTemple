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
    public partial class AddExercisePage : ContentPage
    {
        AddExerciseViewModel viewModel;

        public AddExercisePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AddExerciseViewModel();
        }

        async void OnExerciseSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var exercise = args.SelectedItem as Exercise;
            if (exercise == null)
                return;


            //await Navigation.PushAsync(new ExerciseDetailPage(new ExerciseDetailViewModel(exercise)));

            // Manually deselect workout.
            //AddExercisesListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Exercises.Count == 0)
                viewModel.LoadExercisesCommand.Execute(null);
        }
    }
}