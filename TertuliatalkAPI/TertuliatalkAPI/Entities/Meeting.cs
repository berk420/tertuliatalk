using System;
using System.Collections.Generic;

namespace TertuliatalkAPI.Entities;

public partial class Meeting
{
    public Guid Id { get; set; }

    public string Meetingname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public TimeSpan Duration { get; set; }

    public int? Participants { get; set; }

    public int Maxparticipants { get; set; }

    public string? Pdfdocument { get; set; }

    public byte[]? Pdfdocumentdata { get; set; }

    public bool IsActive { get; set; }

    public Guid? TeacherId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? Teacher { get; set; }
}
