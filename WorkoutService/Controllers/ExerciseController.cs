using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WorkoutService.Models;
using WorkoutService.Models.Dtos;

namespace WorkoutService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("muscle-groups")]
        public async Task<IActionResult> GetMuscleGroups()
        {
            var muscleGroups = await _context.MuscleGroups
                .Include(m => m.Exercises)
                .ToListAsync();
            var muscleGroupsDto = muscleGroups.Select(m => new MuscleGroupDto
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();
            return Ok(muscleGroupsDto);
        }

        [HttpGet("exercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _context.Exercises.ToListAsync();
            var exercisesDto = exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                Name = e.Name,
                MuscleGroupId = e.MuscleGroupId
            }).ToList();
            return Ok(exercisesDto);
        }

        [HttpGet("exercises/{muscleGroupId}")]
        public async Task<IActionResult> GetExercisesByMuscleGroup(int muscleGroupId)
        {
            var exercises = await _context.Exercises
                .Where(e => e.MuscleGroupId == muscleGroupId)
                .ToListAsync();
            var exercisesDto = exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                Name = e.Name,
                MuscleGroupId = e.MuscleGroupId
            }).ToList();
            return Ok(exercisesDto);
        }

        [HttpGet("exercise/{id}")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null) return NotFound("Exercise not found.");
            var exerciseDto = new ExerciseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                MuscleGroupId = exercise.MuscleGroupId
            };
            return Ok(exerciseDto);
        }

        [HttpPost("exercise")]
        public async Task<IActionResult> AddExercise([FromBody] ExerciseDto exerciseDto)
        {
            var exercise = new Exercise
            {
                Name = exerciseDto.Name,
                MuscleGroupId = exerciseDto.MuscleGroupId
            };
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            exerciseDto.Id = exercise.Id;
            return CreatedAtAction(nameof(GetExerciseById), new { id = exercise.Id }, exerciseDto);
        }

        [HttpPost("muscle-group")]
        public async Task<IActionResult> AddMuscleGroup([FromBody] MuscleGroupDto muscleGroupDto)
        {
            var muscleGroup = new MuscleGroup
            {
                Name = muscleGroupDto.Name
            };
            _context.MuscleGroups.Add(muscleGroup);
            await _context.SaveChangesAsync();
            return Ok(muscleGroup);
        }

        [HttpPut("exercise/{id}")]
        public async Task<IActionResult> UpdateExercise(int id, [FromBody] ExerciseDto updatedExerciseDto)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null) return NotFound("Exercise not found.");

            exercise.Name = updatedExerciseDto.Name;
            exercise.MuscleGroupId = updatedExerciseDto.MuscleGroupId;

            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("exercise/{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null) return NotFound("Exercise not found.");

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("muscle-group/{id}")]
        public async Task<IActionResult> UpdateMuscleGroup(int id, [FromBody] MuscleGroupDto updatedMuscleGroupDto)
        {
            var muscleGroup = await _context.MuscleGroups.FindAsync(id);
            if (muscleGroup == null) return NotFound("Muscle group not found.");

            muscleGroup.Name = updatedMuscleGroupDto.Name;

            _context.MuscleGroups.Update(muscleGroup);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("muscle-group/{id}")]
        public async Task<IActionResult> DeleteMuscleGroup(int id)
        {
            var muscleGroup = await _context.MuscleGroups.FindAsync(id);
            if (muscleGroup == null) return NotFound("Muscle group not found.");

            _context.MuscleGroups.Remove(muscleGroup);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
