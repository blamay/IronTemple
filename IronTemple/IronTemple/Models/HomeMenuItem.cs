﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IronTemple.Models
{
    public enum MenuItemType
    {
        Workouts,
        Exercises,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
