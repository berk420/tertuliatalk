using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TertuliatalkAPI.Entities;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IndividualMeeting> IndividualMeetings { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }
    

    public virtual DbSet<PublicMeeting> PublicMeetings { get; set; }

    public virtual DbSet<StudentMeeting> StudentMeetings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-cold-flower-a2i7qrjh.eu-central-1.aws.neon.tech;Port=5432;Database=tertuliatalks_db;Username=tertuliatalks_db_owner;Password=3OZBNdhT9zsK;SSL Mode=Require;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("meeting_type", new[] { "PUBLIC", "INDIVIDUAL" })
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<IndividualMeeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("IndividualMeeting_pkey");

            entity.ToTable("IndividualMeeting");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Teacher).WithMany(p => p.IndividualMeetings)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_IndividualMeeting_User_TeacherId");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Meetings_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Maxparticipants).HasColumnName("maxparticipants");
            entity.Property(e => e.Meetingname).HasColumnName("meetingname");
            entity.Property(e => e.Participants)
                .HasDefaultValue(0)
                .HasColumnName("participants");
            entity.Property(e => e.Pdfdocument)
                .HasMaxLength(255)
                .HasColumnName("pdfdocument");
            entity.Property(e => e.Pdfdocumentdata).HasColumnName("pdfdocumentdata");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("Meetings_teacher_id_fkey");
        });
        
        modelBuilder.Entity<PublicMeeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PublicMeeting_pkey");

            entity.ToTable("PublicMeeting");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Participants).HasDefaultValue(0);
            entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Teacher).WithMany(p => p.PublicMeetings)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PublicMeeting_User_TeacherId");
        });

        modelBuilder.Entity<StudentMeeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("StudentMeeting_pkey");

            entity.ToTable("StudentMeeting");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentMeetings)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentMeeting_User_StudentId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Age).HasDefaultValue(0);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
