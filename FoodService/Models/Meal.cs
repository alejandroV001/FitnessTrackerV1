namespace FoodService.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public ICollection<MealFood> MealFoods { get; set; }
    }
}
