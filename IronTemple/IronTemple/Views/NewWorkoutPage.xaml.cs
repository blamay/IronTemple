﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IronTemple.Models;

namespace IronTemple.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWorkoutPage : ContentPage
    {
        public Workout Workout { get; set; }

        public NewWorkoutPage()
        {
            InitializeComponent();

            Workout = new Workout
            {
                Title = "Workout name",
                Description = "This is a workout description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Workout);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}