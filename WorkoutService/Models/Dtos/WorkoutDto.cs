namespace WorkoutService.Models.Dtos
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; }
        public int DurationMinutes { get; set; }
    }
}
