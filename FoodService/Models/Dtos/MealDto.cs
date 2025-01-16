namespace FoodService.Models.Dtos
{
    public class MealDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }  // Opțional, pentru a obține numele utilizatorului
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public ICollection<MealFoodDto> MealFoods { get; set; }  // Lista cu alimentele asociate
    }
}
