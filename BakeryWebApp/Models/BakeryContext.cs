using Microsoft.EntityFrameworkCore;

namespace BakeryWebApp.Models
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Bread"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Bun"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Muffin"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Cake"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Cookie"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Pie"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Flour"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "Meal"
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Pizza"
                },
                new Category
                {
                    CategoryId = 10,
                    CategoryName = "Seasonal"
                },
                new Category
                {
                    CategoryId = 11,
                    CategoryName = "Cafe"
                },
                new Category
                {
                    CategoryId = 12,
                    CategoryName = "Square"
                }
            );
            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    GroupId = 1,
                    GroupName = "Cheese",
                    CategoryId = 1
                },
                new Group
                {
                    GroupId = 2,
                    GroupName = "Cheese",
                    CategoryId = 2
                },
                new Group
                {
                    GroupId = 3,
                    GroupName = "White",
                    CategoryId = 1
                },
                new Group
                {
                    GroupId = 4,
                    GroupName = "Toasted Oat",
                    CategoryId = 1
                }
            );
        }

    }
}
