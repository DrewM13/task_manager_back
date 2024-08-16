using Microsoft.EntityFrameworkCore;
using task_manager.Models;
using static System.Net.Mime.MediaTypeNames;

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
            /*modelBuilder.Entity<TasksModel>().HasOne(item=>item.IDProject).WithMany().HasForeignKey(t => t.IDProject);*/
            /*  modelBuilder.Entity<TimeTrackersModel>().HasOne(item=>item.IDTask).WithMany().HasForeignKey(t => t.IDTask);
              modelBuilder.Entity<TimeTrackersModel>().HasOne(item=>item.IDCollaborator).WithMany().HasForeignKey(t => t.IDCollaborator);*/

            /*  modelBuilder.Entity<UserModel>().HasOne(t => t.CollaboratorsModel).WithOne(p => p.UserModel).HasForeignKey(t => t).OnDelete(DeleteBehavior.Cascade);*/

        }
    }
}
   
