namespace WorkoutPlanner.Core.Models
{
    public enum muscleGroup
        {
            Chest = 0,
            Back = 1,
            Triceps = 4, 
            Biceps = 8,
        }
    
    
    public class Workout {
        public string Name {get;  private set;}
        public List<Exercise> Exercises {get;  private set; }
        public muscleGroup Primary { get; private set;}
        public Workout(string name, muscleGroup primary)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Workout must have a name.");
            Name = name;
            Primary = primary;
            Exercises = new List<Exercise>();
        }
        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }
        
        public void RemoveExercise(Exercise exercise)
        {
            Exercises.Remove(exercise);
        }

        public override string ToString()
        {
            return Name;
        }
        
        
    }

    

    
}
