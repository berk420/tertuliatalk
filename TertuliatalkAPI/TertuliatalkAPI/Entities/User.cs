using System;
using System.Collections.Generic;

namespace TertuliatalkAPI.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public string Role { get; set; } = null!;

    public int Age { get; set; }

    public string? Hobbies { get; set; }
    
    public string? LanguageLevel { get; set; }

    public string? ProfilePhotoUrl { get; set; }


    public virtual ICollection<IndividualMeeting> IndividualMeetings { get; set; } = new List<IndividualMeeting>();

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    public virtual ICollection<PublicMeeting> PublicMeetings { get; set; } = new List<PublicMeeting>();

    public virtual ICollection<StudentMeeting> StudentMeetings { get; set; } = new List<StudentMeeting>();
}
