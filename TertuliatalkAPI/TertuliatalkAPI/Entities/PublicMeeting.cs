using System;
using System.Collections.Generic;

namespace TertuliatalkAPI.Entities;

public partial class PublicMeeting
{
    public Guid Id { get; set; }

    public string MeetingName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public TimeSpan Duration { get; set; }

    public int? Participants { get; set; }

    public int MaxParticipants { get; set; }

    public string? PdfDocument { get; set; }

    public bool IsActive { get; set; }

    public Guid TeacherId { get; set; }

    public virtual User Teacher { get; set; } = null!;
}
