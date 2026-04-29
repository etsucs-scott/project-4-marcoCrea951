using System;
using System.Collections.Generic;
using WorkoutPlanner.Core.Models;


namespace WorkoutPlanner.Core.Services
{
    public class workoutManager
    {
        private Dictionary<DateTime, Workout> _schedule;
        private List<Workout> _workouts;
        private Stack<Workout> _undoStack;

        public workoutManager()
        {
            _schedule = new Dictionary<DateTime, Workout>();
            _workouts = new List<Workout>();
            _undoStack = new Stack<Workout>();
        }
            
        public void AddWorkout(Workout workout)
        {
            if (workout == null)
                throw new ArgumentException("Workout cannot be null.");

            _workouts.Add(workout);
            _undoStack.Push(workout);
        }
    
        public void RemoveWorkout(Workout workout)
        {
        if (workout == null)
            throw new ArgumentException("Workout cannot be null.");

        _workouts.Remove(workout);
        }

        public void AssignWorkoutToDate(DateTime date, Workout workout)
        {
        if (workout == null)
            throw new ArgumentException("Workout cannot be null.");

        _schedule[date] = workout;
        }

        public Workout? GetWorkoutByDate(DateTime date)
        {
        if (_schedule.ContainsKey(date))
            return _schedule[date];

        return null;
        }

        public Workout? UndoLastWorkout()
        { 
        if (_undoStack.Count == 0)
            return null;

        var last = _undoStack.Pop();
        _workouts.Remove(last);

        return last;
        }

        public List<Workout> GetAllWorkouts()
        {
        return _workouts;
        }

        public Dictionary<DateTime, Workout> GetSchedule()
        {
        return _schedule;
        }
                
        public void LoadData(AppData data)
        {
            _workouts = data.Workouts;
            _schedule = data.Schedule;
        }

        public AppData ExportData()
        {
            return new AppData
            {
                Workouts = _workouts,
                Schedule = _schedule
            };
        }
        
        
        
        
        
        
        }
    }

    

    

