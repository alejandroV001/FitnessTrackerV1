namespace FoodService.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
        public ICollection<MealFood> MealFoods { get; set; }

    }
}
