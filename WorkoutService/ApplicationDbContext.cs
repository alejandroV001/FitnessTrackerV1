using Microsoft.EntityFrameworkCore;
using WorkoutService.Models;

namespace WorkoutService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data pentru MuscleGroup
            modelBuilder.Entity<MuscleGroup>().HasData(
                new MuscleGroup { Id = 1, Name = "Chest" },
                new MuscleGroup { Id = 2, Name = "Back" },
                new MuscleGroup { Id = 3, Name = "Legs" },
                new MuscleGroup { Id = 4, Name = "Arms" },
                new MuscleGroup { Id = 5, Name = "Shoulders" },
                new MuscleGroup { Id = 6, Name = "Core" }
            );

            // Seed data pentru Exercise
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Bench Press", MuscleGroupId = 1 },
                new Exercise { Id = 2, Name = "Incline Dumbbell Press", MuscleGroupId = 1 },
                new Exercise { Id = 3, Name = "Pull Ups", MuscleGroupId = 2 },
                new Exercise { Id = 4, Name = "Deadlift", MuscleGroupId = 2 },
                new Exercise { Id = 5, Name = "Squat", MuscleGroupId = 3 },
                new Exercise { Id = 6, Name = "Bulgarian Splits", MuscleGroupId = 3 },
                new Exercise { Id = 7, Name = "Bicep Curl", MuscleGroupId = 4 },
                new Exercise { Id = 8, Name = "Tricep Extension", MuscleGroupId = 4 },
                new Exercise { Id = 9, Name = "Overhead Shoulder Press", MuscleGroupId = 5 },
                new Exercise { Id = 10, Name = "Lateral Raises", MuscleGroupId = 5 },
                new Exercise { Id = 11, Name = "Plank", MuscleGroupId = 6 },
                new Exercise { Id = 12, Name = "Russian Twists", MuscleGroupId = 6 }
            );

            // Seed data pentru Workout
            modelBuilder.Entity<Workout>().HasData(
                new Workout { Id = 1, Date = new DateTime(2025, 1, 10), UserId = 1, DurationMinutes = 60 },
                new Workout { Id = 2, Date = new DateTime(2025, 1, 11), UserId = 1, DurationMinutes = 45 },
                new Workout { Id = 3, Date = new DateTime(2025, 1, 12), UserId = 2, DurationMinutes = 30 },
                new Workout { Id = 4, Date = new DateTime(2025, 1, 13), UserId = 2, DurationMinutes = 90 }
            );

            // Seed data pentru WorkoutExercise
            modelBuilder.Entity<WorkoutExercise>().HasData(
                new WorkoutExercise { Id = 1, WorkoutId = 1, ExerciseId = 1, Sets = 3, Reps = 10, WeightKg = 50 },
                new WorkoutExercise { Id = 2, WorkoutId = 1, ExerciseId = 3, Sets = 4, Reps = 8, WeightKg = 0 },
                new WorkoutExercise { Id = 3, WorkoutId = 2, ExerciseId = 5, Sets = 5, Reps = 6, WeightKg = 80 },
                new WorkoutExercise { Id = 4, WorkoutId = 2, ExerciseId = 6, Sets = 4, Reps = 10, WeightKg = 25 },
                new WorkoutExercise { Id = 5, WorkoutId = 3, ExerciseId = 7, Sets = 3, Reps = 12, WeightKg = 15 },
                new WorkoutExercise { Id = 6, WorkoutId = 3, ExerciseId = 8, Sets = 3, Reps = 12, WeightKg = 20 },
                new WorkoutExercise { Id = 7, WorkoutId = 4, ExerciseId = 9, Sets = 4, Reps = 8, WeightKg = 40 },
                new WorkoutExercise { Id = 8, WorkoutId = 4, ExerciseId = 11, Sets = 3, Reps = 1, WeightKg = 0 }
            );
        }

        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
