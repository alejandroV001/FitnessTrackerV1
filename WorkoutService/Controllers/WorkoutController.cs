using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WorkoutService.Models;
using WorkoutService.Models.Dtos;

namespace WorkoutService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkouts()
        {
            return Ok(await _context.Workouts.Include(w => w.WorkoutExercises).ThenInclude(we => we.Exercise).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutById(int id)
        {
            var workout = await _context.Workouts
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null) return NotFound("Workout not found.");

            var workoutDto = new WorkoutDto
            {
                Id = workout.Id,
                Date = workout.Date,
                UserId = workout.UserId,
                DurationMinutes = workout.DurationMinutes,
                Exercises = workout.WorkoutExercises.Select(we => new WorkoutExerciseDto
                {
                    Id = we.Id,
                    WorkoutId = we.WorkoutId,
                    ExerciseId = we.Exercise.Id,
                    Sets = we.Sets,
                    Reps = we.Reps,
                    WeightKg = we.WeightKg
                }).ToList()
            };

            return Ok(workoutDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkout([FromBody] WorkoutDto workoutDto)
        {
            var workout = new Workout
            {
                Date = workoutDto.Date,
                UserId = workoutDto.UserId,
                DurationMinutes = workoutDto.DurationMinutes,
                WorkoutExercises = workoutDto.Exercises.Select(we => new WorkoutExercise
                {
                    ExerciseId = _context.Exercises.FirstOrDefault(e => e.Id == we.ExerciseId)?.Id ?? 0,
                    Sets = we.Sets,
                    Reps = we.Reps,
                    WeightKg = we.WeightKg
                }).ToList()
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkoutById), new { id = workout.Id }, workoutDto);
        }

        [HttpPut("workout/{id}")]
        public async Task<IActionResult> UpdateWorkout(int id, [FromBody] WorkoutDto updatedWorkoutDto)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return NotFound("Workout not found.");

            workout.UserId = updatedWorkoutDto.UserId;
            workout.Date = updatedWorkoutDto.Date;
            workout.DurationMinutes = updatedWorkoutDto.DurationMinutes;

            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("workout-exercise/{id}")]
        public async Task<IActionResult> UpdateWorkoutExercise(int id, [FromBody] WorkoutExerciseDto updatedWorkoutExerciseDto)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null) return NotFound("Workout exercise not found.");

            workoutExercise.WorkoutId = updatedWorkoutExerciseDto.WorkoutId;
            workoutExercise.Sets = updatedWorkoutExerciseDto.Sets;
            workoutExercise.Reps = updatedWorkoutExerciseDto.Reps;
            workoutExercise.WeightKg = updatedWorkoutExerciseDto.WeightKg;

            _context.WorkoutExercises.Update(workoutExercise);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("add-exercise")]
        public async Task<IActionResult> AddExerciseToWorkout([FromBody] WorkoutExerciseDto workoutExerciseDto)
        {
            var workoutExercise = new WorkoutExercise
            {
                WorkoutId = workoutExerciseDto.WorkoutId,
                ExerciseId = workoutExerciseDto.ExerciseId,
                Sets = workoutExerciseDto.Sets,
                Reps = workoutExerciseDto.Reps,
                WeightKg = workoutExerciseDto.WeightKg
            };
            _context.WorkoutExercises.Add(workoutExercise);
            await _context.SaveChangesAsync();
            return Ok(workoutExerciseDto);
        }

        [HttpDelete("workout/{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return NotFound("Workout not found.");

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("workout-exercise/{id}")]
        public async Task<IActionResult> DeleteWorkoutExercise(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null) return NotFound("Workout exercise not found.");

            _context.WorkoutExercises.Remove(workoutExercise);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("user/{userId}/date/{date}")]
        public async Task<IActionResult> GetWorkoutByDate(int userId, DateTime date)
        {
            var workout = await _context.Workouts
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.UserId == userId && w.Date.Date == date.Date);

            if (workout == null) return NotFound("No workout found for this date.");

            var workoutDto = new WorkoutDto
            {
                Id = workout.Id,
                Date = workout.Date,
                UserId = workout.UserId,
                DurationMinutes = workout.DurationMinutes,
                Exercises = workout.WorkoutExercises.Select(we => new WorkoutExerciseDto
                {
                    Id = we.Id,
                    WorkoutId = we.WorkoutId,
                    ExerciseId = we.Exercise.Id,
                    Sets = we.Sets,
                    Reps = we.Reps,
                    WeightKg = we.WeightKg
                }).ToList()
            };
            return Ok(workoutDto);
        }
    }
}
