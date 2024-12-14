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
        public DbSet <Image> Images { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure one-to-one relationship between StudentModel and StudentAddress
            //modelBuilder.Entity<StudentModel>()
            //    .HasOne(s => s.Address)        // Student has one Address
            //    .WithOne(/*a => a.Student*/)       // Address has one Student
            //    .HasForeignKey<StudentModel>(s => s.AddressId); // StudentModel has the foreign key
            //                                                     //.OnDelete(DeleteBehavior.SetNull);  // Optional: Set null on delete of StudentModel


            //modelBuilder.Entity<StudentModel>()
            //    .HasOne(s => s.Image)
            //    .WithOne(/*i => i.Student*/)
            //    .HasForeignKey<StudentModel>(s => s.ImageId);


            modelBuilder.Entity<StudentModel>()
                .HasOne(a => a.Address)
                .WithOne()
                .HasForeignKey<StudentModel>(a => a.AddressId);


            modelBuilder.Entity<StudentModel>()
                .HasOne(s => s.Image)
                .WithOne()
                .HasForeignKey<StudentModel>(a => a.ImageId);



           
        }
    }
}
