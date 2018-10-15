using System;
using IronTemple.Models;

namespace IronTemple.ViewModels
{
    public class WorkoutDetailViewModel : BaseViewModel
    {
        public Workout Workout { get; set; }
        public WorkoutDetailViewModel(Workout workout = null)
        {
            Title = workout?.Title;
            Workout = workout;
        }
    }
}
