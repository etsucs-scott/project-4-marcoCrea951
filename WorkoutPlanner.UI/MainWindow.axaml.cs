using Avalonia.Controls;
using WorkoutPlanner.UI;
using WorkoutPlanner.Core.Models;

namespace WorkoutPlanner.UI
{
    public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadWorkouts();
    }

        private void LoadWorkouts()
    {
        var listBox = this.FindControl<ListBox>("WorkoutList");

        listBox.ItemsSource = null;
        listBox.ItemsSource = AppState.Manager.GetAllWorkouts();


    }

    private void AddWorkout_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var workout = new Workout("New Workout", muscleGroup.Chest);

        AppState.Manager.AddWorkout(workout);

        LoadWorkouts();
    }

}
}


