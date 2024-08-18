namespace TertuliatalkAPI.Entities;

public class Course
{
    public Course(string title, string description, int? maxParticipants,
        DateTime startDate, TimeSpan duration, Guid instructorId)
    {
        Title = title;
        Description = description;
        Type = maxParticipants > 1 ? "Public" : "Private";
        MaxParticipants = maxParticipants == null ? 1 : maxParticipants;
        StartDate = startDate;
        Duration = duration;
        InstructorId = instructorId;
    }

    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int? Participants { get; set; }

    public int? MaxParticipants { get; set; }

    public string? DocumentUrl { get; set; }

    public TimeSpan Duration { get; set; }

    public Guid InstructorId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime StartDate { get; set; }

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}