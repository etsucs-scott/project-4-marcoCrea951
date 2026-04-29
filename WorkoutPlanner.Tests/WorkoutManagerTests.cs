using System;
using WorkoutPlanner.Core.Models;
using WorkoutPlanner.Core.Services;
using WorkoutPlanner.Data;
using Xunit;

namespace WorkoutPlanner.Tests
{
    public class WorkoutManagerTests
    {
        private workoutManager CreateManager()
        {
            
            return new workoutManager();
                
        }

        [Fact]
    public void AddWorkout_AddsWorkout()
    {
        var manager = CreateManager();
        var workout = new Workout("Test", muscleGroup.Chest);

        manager.AddWorkout(workout);

        Assert.Contains(workout, manager.GetAllWorkouts());
    }



    [Fact]
    public void RemoveWorkout_RemovesWorkout()
    {
        var manager = CreateManager();
        var workout = new Workout("Test", muscleGroup.Chest);

        manager.AddWorkout(workout);
        manager.RemoveWorkout(workout);

        Assert.DoesNotContain(workout, manager.GetAllWorkouts());
    }


    [Fact]
    public void Schedule_AssignsWorkout()
    {
        var manager = CreateManager();
        var workout = new Workout("Test", muscleGroup.Back);

        manager.AssignWorkoutToDate(DateTime.Today, workout);

        Assert.Equal(workout, manager.GetWorkoutByDate(DateTime.Today));
    }




    [Fact]
    public void Schedule_ReturnsNull_WhenEmpty()
    {
        var manager = CreateManager();

        var result = manager.GetWorkoutByDate(DateTime.Today);

        Assert.Null(result);
    }


    [Fact]
    public void Undo_RemovesLastWorkout()
    {
        var manager = CreateManager();
        var workout = new Workout("Test", muscleGroup.Chest);

        manager.AddWorkout(workout);
        var result = manager.UndoLastWorkout();

        Assert.Equal(workout, result);
    }


    [Fact]
    public void Undo_WhenEmpty_ReturnsNull()
    {
        var manager = CreateManager();

        var result = manager.UndoLastWorkout();

        Assert.Null(result);
    }




    [Fact]
    public void Manager_InitiallyEmpty()
    {
        var manager = CreateManager();

        Assert.Empty(manager.GetAllWorkouts());
    }


    [Fact]
    public void Manager_StoresMultipleWorkouts()
    {
        var manager = CreateManager();

        manager.AddWorkout(new Workout("A", muscleGroup.Chest));
        manager.AddWorkout(new Workout("B", muscleGroup.Back));

        Assert.Equal(2, manager.GetAllWorkouts().Count);
    }


    [Fact]
    public void Workout_AddExercise_Works()
    {
        var workout = new Workout("Test", muscleGroup.Chest);

        workout.AddExercise(new Exercise("Bench", 3, 10, 100));

        Assert.Single(workout.Exercises);
    }


    [Fact]
    public void Exercise_InvalidName_ThrowsError()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Exercise("", 3, 10, 100);
        });
    }






















































    }
}