namespace WorkoutService.Models
{
    public class MuscleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
