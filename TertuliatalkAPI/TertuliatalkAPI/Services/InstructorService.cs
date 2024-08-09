using LinqToDB;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;

namespace TertuliatalkAPI.Services;

public class InstructorService : IInstructorService
{
    private readonly TertuliatalksDbContext _context;

    public InstructorService(TertuliatalksDbContext context)
    {
        _context = context;
    }

    public async Task<Instructor> AddInstructor(Instructor instructor)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Instructor>> GetAllInstructors()
    {
        return await _context.Instructors.ToListAsync();
    }

    public async Task<Instructor> GetInstructorById(Guid instructorId)
    {
        var instructor = await _context.Instructors.FirstOrDefaultAsync(c => c.Id == instructorId);
        if (instructor == null)
            throw new NotFoundException($"Instructor with ID {instructorId} not found");

        return instructor;
    }

    public async Task<Instructor> GetInstructorByEmail(string email)
    {
        var instructor = await _context.Instructors.FirstOrDefaultAsync(c => c.Email == email);
        if (instructor == null)
            throw new NotFoundException($"Instructor with Email {email} not found");

        return instructor;
    }
}