namespace TertuliatalkAPI.Models.DTOs
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Hobbies { get; set; }
        public string? LanguageLevel { get; set; }
        public string? ProfilePhotoUrl { get; set; }
    }
}
