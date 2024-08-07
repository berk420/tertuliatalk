using TertuliatalkAPI.Entities;

namespace TertuliatalkAPI.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCourses();
    Task<Course> GetCourseById(Guid courseId);
    Task<Course> CreateCourse(Course course);
    Task DeleteCourse(Guid courseId);
    Task<Course> AddUserToCourse(Guid courseId);
    Task<Course> RemoveUserToCourse(Guid courseId);
}