
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Project.Model.Domain;
using Project.Model.Enums;

namespace Project.Data
{
    public class SchoolContext : DbContext
    {
        private readonly string connection_string;
        public SchoolContext()
        {
            connection_string = "Data Source=.\\SQLEXPRESS; Initial Catalog=CSharpB21; User ID=csharpb21; Password=123456; TrustServerCertificate=True;";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SchoolClass> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<TeacherAssignment> TeacherAssignments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection_string);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
              .HasIndex(u => u.UserName)
              .IsUnique();

            modelBuilder.Entity<SchoolClass>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasIndex(s => new { s.ClassId, s.Name })
                .IsUnique();

            modelBuilder.Entity<TeacherAssignment>().HasKey(t => new { t.TeacherId, t.ClassId, t.SubjectId });

            modelBuilder.Entity<TeacherAssignment>()
                .HasOne(t => t.Teacher)
                .WithMany(u => u.TeachingAssignments)
                .HasForeignKey(t => t.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.Entity<TeacherAssignment>()
               .HasOne(t => t.Class)
               .WithMany(u => u.TeachingAssignments)
               .HasForeignKey(t => t.ClassId)
               .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<TeacherAssignment>()
               .HasOne(t => t.Subject)
               .WithMany(u => u.TeachingAssignments)
               .HasForeignKey(t => t.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
               .HasIndex(g => new { g.StudentId, g.SubjectId, g.Term, g.ClassId })
               .IsUnique();

            modelBuilder.Entity<Grade>()
                .Property(g => g.Term)
                .HasConversion<int>();
            
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.SchoolClass)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.ClassId)              
                .OnDelete(DeleteBehavior.Restrict);          

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);          

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   Name = "Ariful",
                   UserName = "Admin",
                   PasswordHash = "admin123", 
                   Type = UserType.Admin
               }
           );


            base.OnModelCreating(modelBuilder);
        }
    }
}
