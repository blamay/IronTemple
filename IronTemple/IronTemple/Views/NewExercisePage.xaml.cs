using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IronTemple.Models;

namespace IronTemple.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExercisePage : ContentPage
    {
        public Exercise Exercise { get; set; }

        public NewExercisePage()
        {
            InitializeComponent();

            Exercise = new Exercise
            {
                Title = "Exercise name",
                Description = "This is an exercise description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Exercise);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}