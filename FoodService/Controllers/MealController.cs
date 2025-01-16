using FoodService.Models.Dtos;
using FoodService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MealController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeals()
        {
            var meals = await _context.Meals
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                .ToListAsync();

            var mealDtos = meals.Select(m => new MealDto
            {
                Id = m.Id,
                UserId = m.UserId,
                Date = m.Date,
                Type = m.Type,
                MealFoods = m.MealFoods.Select(mf => new MealFoodDto
                {
                    Id = mf.Id,
                    Food = new FoodDto
                    {
                        Id = mf.Food.Id,
                        Name = mf.Food.Name,
                        Calories = mf.Food.Calories,
                        Proteins = mf.Food.Proteins,
                        Carbs = mf.Food.Carbs,
                        Fats = mf.Food.Fats
                    }
                }).ToList()
            }).ToList();

            return Ok(mealDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealById(int id)
        {
            var meal = await _context.Meals
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null) return NotFound("Meal not found.");

            var mealDto = new MealDto
            {
                Id = meal.Id,
                UserId = meal.UserId,
                Date = meal.Date,
                Type = meal.Type,
                MealFoods = meal.MealFoods.Select(mf => new MealFoodDto
                {
                    Id = mf.Id,
                    Food = new FoodDto
                    {
                        Id = mf.Food.Id,
                        Name = mf.Food.Name,
                        Calories = mf.Food.Calories,
                        Proteins = mf.Food.Proteins,
                        Carbs = mf.Food.Carbs,
                        Fats = mf.Food.Fats
                    }
                }).ToList()
            };

            return Ok(mealDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal([FromBody] CreateMealDto createMealDto)
        {
            var meal = new Meal
            {
                UserId = createMealDto.UserId,
                Date = createMealDto.Date,
                Type = createMealDto.Type
            };

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            var mealFoods = createMealDto.FoodIds.Select(foodId => new MealFood
            {
                MealId = meal.Id,
                FoodId = foodId
            }).ToList();

            _context.MealFoods.AddRange(mealFoods);
            await _context.SaveChangesAsync();

            var mealDto = new MealDto
            {
                Id = meal.Id,
                UserId = meal.UserId,
                Date = meal.Date,
                Type = meal.Type,
                MealFoods = mealFoods.Select(mf => new MealFoodDto
                {
                    Id = mf.Id,
                    Food = new FoodDto
                    {
                        Id = mf.Food.Id,
                        Name = mf.Food.Name,
                        Calories = mf.Food.Calories,
                        Proteins = mf.Food.Proteins,
                        Carbs = mf.Food.Carbs,
                        Fats = mf.Food.Fats
                    }
                }).ToList()
            };

            return CreatedAtAction(nameof(GetMealById), new { id = meal.Id }, mealDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeal(int id, [FromBody] UpdateMealDto updateMealDto)
        {
            var meal = await _context.Meals
                .Include(m => m.MealFoods)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null) return NotFound("Meal not found.");

            meal.UserId = updateMealDto.UserId;
            meal.Date = updateMealDto.Date;
            meal.Type = updateMealDto.Type;

            // Update foods (MealFood relation)
            var mealFoods = updateMealDto.FoodIds.Select(foodId => new MealFood
            {
                MealId = meal.Id,
                FoodId = foodId
            }).ToList();

            _context.MealFoods.RemoveRange(meal.MealFoods);  // Remove existing MealFood relations
            _context.MealFoods.AddRange(mealFoods);          // Add new MealFood relations

            await _context.SaveChangesAsync();

            var mealDto = new MealDto
            {
                Id = meal.Id,
                UserId = meal.UserId,
                Date = meal.Date,
                Type = meal.Type,
                MealFoods = mealFoods.Select(mf => new MealFoodDto
                {
                    Id = mf.Id,
                    Food = new FoodDto
                    {
                        Id = mf.Food.Id,
                        Name = mf.Food.Name,
                        Calories = mf.Food.Calories,
                        Proteins = mf.Food.Proteins,
                        Carbs = mf.Food.Carbs,
                        Fats = mf.Food.Fats
                    }
                }).ToList()
            };

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null) return NotFound("Meal not found.");

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
