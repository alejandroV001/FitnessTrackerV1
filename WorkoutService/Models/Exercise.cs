namespace WorkoutService.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MuscleGroupId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
