using System;
using System.Collections.Generic;

namespace WorkoutPlanner.Core.Models
{
    public class AppData
    {
        public List<Workout> Workouts { get; set; } = new List<Workout>();

        public Dictionary<DateTime, Workout> Schedule { get; set; } = new Dictionary<DateTime, Workout>();
    }
}