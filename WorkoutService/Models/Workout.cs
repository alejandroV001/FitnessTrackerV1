using Microsoft.AspNetCore.Identity;

namespace WorkoutService.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
        public int DurationMinutes { get; set; }
    }
}
