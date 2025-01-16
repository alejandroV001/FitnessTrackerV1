using FoodService.Models.Dtos;
using FoodService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            var foods = await _context.Foods.ToListAsync();
            var foodDtos = foods.Select(f => new FoodDto
            {
                Id = f.Id,
                Name = f.Name,
                Calories = f.Calories,
                Proteins = f.Proteins,
                Carbs = f.Carbs,
                Fats = f.Fats
            }).ToList();

            return Ok(foodDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null) return NotFound("Food not found.");

            var foodDto = new FoodDto
            {
                Id = food.Id,
                Name = food.Name,
                Calories = food.Calories,
                Proteins = food.Proteins,
                Carbs = food.Carbs,
                Fats = food.Fats
            };

            return Ok(foodDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] FoodDto foodDto)
        {
            var food = new Food
            {
                Name = foodDto.Name,
                Calories = foodDto.Calories,
                Proteins = foodDto.Proteins,
                Carbs = foodDto.Carbs,
                Fats = foodDto.Fats
            };

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            foodDto.Id = food.Id;
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, foodDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(int id, [FromBody] FoodDto foodDto)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null) return NotFound("Food not found.");

            food.Name = foodDto.Name;
            food.Calories = foodDto.Calories;
            food.Proteins = foodDto.Proteins;
            food.Carbs = foodDto.Carbs;
            food.Fats = foodDto.Fats;

            _context.Foods.Update(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null) return NotFound("Food not found.");

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
