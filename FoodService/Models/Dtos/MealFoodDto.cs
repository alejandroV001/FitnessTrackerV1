namespace FoodService.Models.Dtos
{
    public class MealFoodDto
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public MealDto Meal { get; set; }
        public int FoodId { get; set; }
        public FoodDto Food { get; set; }
    }
}
