namespace FoodService.Models.Dtos
{
    public class UpdateMealDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public List<int> FoodIds { get; set; }  // Lista de ID-uri ale alimentelor
    }
}
