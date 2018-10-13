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

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Workout;
            if (item == null)
                return;

            await Navigation.PushAsync(new WorkoutDetailPage(new WorkoutDetailViewModel(item)));

            // Manually deselect workout.
            WorkoutsListView.SelectedItem = null;
        }

        async void AddWorkout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}