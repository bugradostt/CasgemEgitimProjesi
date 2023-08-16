using CasgemEgitim.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.Concrete
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bugra
          optionsBuilder.UseSqlServer(@"Data Source=BUDOTEKNO\SQLEXPRESS; initial catalog=CasgemEgitimProjesiDb; integrated security=true");


            //Nurgül
           //optionsBuilder.UseSqlServer("Data Source=LAPTOP-DMD5S6B7; initial catalog=CasgemEgitimProjesiDb; integrated security=true");


            //Selvi
          //optionsBuilder.UseSqlServer("Data Source=DESKTOP-U4DC5DI; initial catalog=CasgemEgitimProjesiDb; integrated security=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
               .HasOne(x => x.SenderStudent)
               .WithMany(y => y.SentMessages)
               .HasForeignKey(z => z.SenderID)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
             .HasOne(m => m.ReceiverStudent)
             .WithMany(s => s.ReceiverMessages)
             .HasForeignKey(m => m.ReceiverID);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.SenderTeacher)
                .WithMany(t => t.SentMessages)
                .HasForeignKey(m => m.SenderID);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ReceiverTeacher)
                .WithMany(t => t.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverID);
        }

        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Movement> Movements{ get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Video> Videos{ get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Comment> Comments{ get; set; }



    }
}
