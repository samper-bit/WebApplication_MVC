using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, Name = "Mouses", DisplayOrder = 1 },
				new Category { CategoryId = 2, Name = "Keyboards", DisplayOrder = 2 },
				new Category { CategoryId = 3, Name = "Headphones", DisplayOrder = 3 }
				) ;
			modelBuilder.Entity<Product>().HasData(
			   new Product
			   {
				   ProductId = 1,
				   ProductCode = 1,
				   Title = "Mouse1",
				   Producer = "Mouse1 Producer",
				   Description = "Mouse1 Description",
				   ListPrice = 100,
				   Price = 100,
				   Price5 = 95,
				   Price20 = 90,
				   CategoryId = 1,
				   ImageUrl = ""
			   },
			   new Product
			   {
				   ProductId = 2,
				   ProductCode = 2,
				   Title = "Keyboard1",
				   Producer = "Keyboard1 Producer",
				   Description = "Keyboard1 Description",
				   ListPrice = 200,
				   Price = 200,
				   Price5 = 190,
				   Price20 = 180,
				   CategoryId = 2,
				   ImageUrl = ""
			   },
			   new Product
			   {
				   ProductId = 3,
				   ProductCode = 3,
				   Title = "Headphone1",
				   Producer = "Headphone1 Producer",
				   Description = "Headphone1 Description",
				   ListPrice = 300,
				   Price = 300,
				   Price5 = 285,
				   Price20 = 270,
				   CategoryId = 3,
				   ImageUrl = ""
			   });
		}
	}
}