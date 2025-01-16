using FoodService.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodService
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

            modelBuilder.Entity<MealFood>()
                .HasKey(mf => mf.Id);

            modelBuilder.Entity<MealFood>()
                .HasOne(mf => mf.Meal)
                .WithMany(m => m.MealFoods)
                .HasForeignKey(mf => mf.MealId);

            modelBuilder.Entity<MealFood>()
                .HasOne(mf => mf.Food)
                .WithMany(f => f.MealFoods)
                .HasForeignKey(mf => mf.FoodId);

            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, Name = "Chicken Breast", Calories = 165, Proteins = 31, Carbs = 0, Fats = 3.6 },
                new Food { Id = 2, Name = "Rice", Calories = 130, Proteins = 2.7, Carbs = 28, Fats = 0.3 },
                new Food { Id = 3, Name = "Broccoli", Calories = 55, Proteins = 3.7, Carbs = 11.2, Fats = 0.6 },
                new Food { Id = 4, Name = "Eggs", Calories = 155, Proteins = 13, Carbs = 1.1, Fats = 10.6 },
                new Food { Id = 5, Name = "Sweet Potato", Calories = 86, Proteins = 1.6, Carbs = 20.1, Fats = 0.1 },
                new Food { Id = 6, Name = "Almonds", Calories = 579, Proteins = 21.2, Carbs = 21.6, Fats = 49.9 },
                new Food { Id = 7, Name = "Greek Yogurt", Calories = 59, Proteins = 10, Carbs = 3.6, Fats = 0.4 },
                new Food { Id = 8, Name = "Avocado", Calories = 160, Proteins = 2, Carbs = 8.5, Fats = 14.7 },
                new Food { Id = 9, Name = "Salmon", Calories = 208, Proteins = 20, Carbs = 0, Fats = 13 },
                new Food { Id = 10, Name = "Spinach", Calories = 23, Proteins = 2.9, Carbs = 3.6, Fats = 0.4 }
            );

            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, UserId = 1, Date = new DateTime(2025, 1, 10), Type = "Breakfast" },
                new Meal { Id = 2, UserId = 1, Date = new DateTime(2025, 1, 10), Type = "Lunch" },
                new Meal { Id = 3, UserId = 1, Date = new DateTime(2025, 1, 10), Type = "Dinner" },
                new Meal { Id = 4, UserId = 2, Date = new DateTime(2025, 1, 11), Type = "Breakfast" },
                new Meal { Id = 5, UserId = 2, Date = new DateTime(2025, 1, 11), Type = "Lunch" },
                new Meal { Id = 6, UserId = 2, Date = new DateTime(2025, 1, 11), Type = "Dinner" },
                new Meal { Id = 7, UserId = 3, Date = new DateTime(2025, 1, 12), Type = "Breakfast" },
                new Meal { Id = 8, UserId = 3, Date = new DateTime(2025, 1, 12), Type = "Lunch" },
                new Meal { Id = 9, UserId = 3, Date = new DateTime(2025, 1, 12), Type = "Dinner" },
                new Meal { Id = 10, UserId = 1, Date = new DateTime(2025, 1, 13), Type = "Breakfast" }
            );

            modelBuilder.Entity<MealFood>().HasData(
                new MealFood { Id = 1, MealId = 1, FoodId = 1 },
                new MealFood { Id = 2, MealId = 1, FoodId = 4 },
                new MealFood { Id = 3, MealId = 2, FoodId = 2 },
                new MealFood { Id = 4, MealId = 2, FoodId = 3 },
                new MealFood { Id = 5, MealId = 3, FoodId = 9 },
                new MealFood { Id = 6, MealId = 3, FoodId = 5 },
                new MealFood { Id = 7, MealId = 4, FoodId = 7 }, 
                new MealFood { Id = 8, MealId = 4, FoodId = 6 }, 
                new MealFood { Id = 9, MealId = 5, FoodId = 8 }, 
                new MealFood { Id = 10, MealId = 5, FoodId = 9 } 
            );

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealFood> MealFoods { get; set; }
    }
}
