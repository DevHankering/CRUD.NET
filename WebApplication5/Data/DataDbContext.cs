using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class DataDbContext : DbContext 
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
         
        public DbSet<StudentModel> Student { get; set; }   
        public DbSet<StudentAddress> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-one relationship between StudentModel and StudentAddress
            modelBuilder.Entity<StudentModel>()
                .HasOne(s => s.Address)        // Student has one Address
                .WithOne(a => a.Student)       // Address has one Student
                .HasForeignKey<StudentModel>(s => s.Address_Id); // StudentModel has the foreign key
                //.OnDelete(DeleteBehavior.SetNull);  // Optional: Set null on delete of StudentModel

            base.OnModelCreating(modelBuilder);
        }
    }
}
