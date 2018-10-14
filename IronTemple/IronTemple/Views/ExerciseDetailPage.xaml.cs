using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IronTemple.Models;
using IronTemple.ViewModels;

namespace IronTemple.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailPage : ContentPage
    {
        ExerciseDetailViewModel viewModel;

        public ExerciseDetailPage(ExerciseDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ExerciseDetailPage()
        {
            InitializeComponent();

            var item = new Exercise
            {
                Title = "Exercise 1",
                Description = "This is an exercise description."
            };

            viewModel = new ExerciseDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}