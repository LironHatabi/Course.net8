namespace Course.net8.Infra.ApplicationDbContext;

public class CourseDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public CourseDbContext(DbContextOptions<CourseDbContext> contextOptions) : base(contextOptions)
    {
        
    }
}