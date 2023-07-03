using Microsoft.EntityFrameworkCore;
using SchoolBus.Model.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Data
{
	public class ApplicationDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer("Data Source=DESKTOP-N6OLO15;Initial Catalog=GenericRepoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
			//optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
					 .HasOne(s => s.Class)
					 .WithMany(c => c.Students)
					 .HasForeignKey(s => s.ClassId)
					 .OnDelete(DeleteBehavior.NoAction);


			

			modelBuilder.Entity<Student>()
						 .HasOne(s => s.Parent)
						 .WithMany(p => p.Students)
						 .HasForeignKey(s => s.ParentId);



			modelBuilder.Entity<Parent>()
						.HasMany(p => p.Students)
						.WithOne(s => s.Parent)
						.HasForeignKey(s => s.ParentId)
						.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Class>()
					.HasMany(c => c.Students)
					.WithOne(s => s.Class)
					.HasForeignKey(s => s.ClassId)
					.OnDelete(DeleteBehavior.Cascade);






		}
	}
}
