using System;
using System.Collections.Generic;

namespace IronTemple.Models
{
    public class Workout
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Exercise[] ExerciseList { get; set; }
    }
}