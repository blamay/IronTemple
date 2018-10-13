using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IronTemple.Models;
using IronTemple.ViewModels;

namespace IronTemple.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutDetailPage : ContentPage
    {
        WorkoutDetailViewModel viewModel;

        public WorkoutDetailPage(WorkoutDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public WorkoutDetailPage()
        {
            InitializeComponent();

            var item = new Workout
            {
                Text = "Workout 1",
                Description = "This is an workout description."
            };

            viewModel = new WorkoutDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}