using System;

using IronTemple.Models;

namespace IronTemple.ViewModels
{
    public class ExerciseDetailViewModel : BaseViewModel
    {
        public Exercise Exercise { get; set; }
        public ExerciseDetailViewModel(Exercise exercise = null)
        {
            Title = exercise?.Title;
            Exercise = exercise;
        }
    }
}
