using WorkoutPlanner.Core.Services;

namespace WorkoutPlanner.UI
{
    public static class AppState
    {
        public static workoutManager Manager { get; } = new workoutManager();
    }
}