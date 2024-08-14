using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Interfaces;

public interface ICourseService
{
    Task<List<Course>> GetAllCourses();
    Task<Course> GetCourseById(Guid courseId);
    Task<Course> CreateCourse(CreateCourseRequest request);
    Task DeleteCourse(Guid courseId);
    Task<Course> AddUserToCourse(Guid courseId);
    Task<Course> RemoveUserToCourse(Guid courseId);
}