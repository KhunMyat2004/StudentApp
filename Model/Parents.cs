namespace StudentApp.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student>Students { get; set; }
        
        
        public DbSet<Teacher>Teachers { get; set; }
        
    }

    