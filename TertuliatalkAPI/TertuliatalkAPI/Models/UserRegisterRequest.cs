namespace TertuliatalkAPI.Models;

public class UserRegisterRequest
{
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string role { get; set; }
}