using Microsoft.EntityFrameworkCore;
using task_manager.Models;

namespace studyProject.Data
{
    public class dataBaseContext : DbContext
    {
        public dataBaseContext(DbContextOptions<dataBaseContext> options) : base(options)
        {
        }

        public DbSet<UserModel> tUser { get; set; }
        public DbSet<ProjectModel> tProject { get; set; }
        public DbSet<CollaboratorsModel> tCollaborator { get; set; }
        public DbSet<TasksModel> tTask { get; set; }
        public DbSet<TimeTrackersModel> tTimeTracker { get; set; }
        public DbSet<TaskCollaboratorModel> tTaskCollaborator { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
              .HasIndex(x => x.vchUserName)
              .IsUnique();
            modelBuilder.Entity<TasksModel>(entity =>
            {
                entity.HasOne<ProjectModel>()
                  .WithMany()
                  .HasForeignKey(t => t.IDProject)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TimeTrackersModel>(entity =>
            {
                entity.HasOne<TasksModel>()
                  .WithMany()
                  .HasForeignKey(t => t.IDTask)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TimeTrackersModel>(entity =>
            {
                entity.HasOne<CollaboratorsModel>()
                  .WithMany()
                  .HasForeignKey(t => t.IDCollaborator)
                  .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<TaskCollaboratorModel>(entity =>
            {
                entity.HasOne<CollaboratorsModel>()
                  .WithMany()
                  .HasForeignKey(t => t.IDCollaborator)
                  .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<TaskCollaboratorModel>(entity =>
            {
                entity.HasOne<TasksModel>()
                  .WithMany()
                  .HasForeignKey(t => t.IDTask)
                  .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
   
