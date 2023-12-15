namespace EventManagerService.API.Models
{
    public class EventCategoryDto
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
    }
}
