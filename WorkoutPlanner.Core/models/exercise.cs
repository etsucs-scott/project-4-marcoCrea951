namespace WorkoutPlanner.Core.Models
{
    public class Exercise
    {
        public string Name { get; private set;}
        public int Sets { get;  private set;}
        public int Reps { get;  private set;}
        public double Weight {get;  private set; }

        public Exercise(string name, int sets, int reps, double weight)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Exercise must have a name.");

            if (sets < 0)
                throw new ArgumentException("Sets cannot be negative.");
            
            if (reps < 0) 
                throw new ArgumentException("Reps cannot be negative.");
            
            if (weight < 0)
                throw new ArgumentException("Weight cannot be negative.");
            
            Name = name;
            Sets = sets;
            Reps = reps;
            Weight = weight;
        } 
    }
}