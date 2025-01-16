namespace WorkoutService.Models.Dtos
{
    public class WorkoutExerciseDto
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float WeightKg { get; set; }
    }
}
