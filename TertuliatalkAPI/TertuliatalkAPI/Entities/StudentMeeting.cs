using System;
using System.Collections.Generic;

namespace TertuliatalkAPI.Entities;

public partial class StudentMeeting
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid MeetingId { get; set; }

    public string MeetingType { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User Student { get; set; } = null!;
}
