using Avalonia.Controls;
using Avalonia.Interactivity;
using WorkoutPlanner.Core.Models;
using WorkoutPlanner.UI;
using System;
using System.Linq;
namespace WorkoutPlanner.UI.Views;

public partial class ScheduleView : UserControl
{
    public ScheduleView()
    {
        InitializeComponent();
        LoadWorkouts();
        LoadSchedule();
    }

    private void LoadWorkouts()
        {
            var dropdown = this.FindControl<ComboBox>("WorkoutDropdown");

            dropdown.ItemsSource = AppState.Manager.GetAllWorkouts();
        }
    
        private void Assign_Click(object? sender, RoutedEventArgs e)
    {
        var datePicker = this.FindControl<DatePicker>("DatePicker");
        var dropdown = this.FindControl<ComboBox>("WorkoutDropdown");

        if (datePicker.SelectedDate == null)
            return;

        if (dropdown.SelectedItem is not Workout workout)
            return;

        var date = datePicker.SelectedDate.Value.DateTime;

        AppState.Manager.AssignWorkoutToDate(date, workout);

        LoadSchedule();
    }

        private void LoadSchedule()
    {
        var list = this.FindControl<ListBox>("ScheduleList");

        var items = AppState.Manager.GetSchedule()
            .Select(x => $"{x.Key.ToShortDateString()} - {x.Value.Name}")
            .ToList();

        list.ItemsSource = items;
    }
}