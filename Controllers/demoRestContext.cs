using Microsoft.EntityFrameworkCore;
public partial class demoRestContext : DbContext {
    public demoRestContext(){}
    
    public demoRestContext(DbContextOptions<demoRestContext> options) : base(options){}

    // BELOW DECLARE ALL TABLES AS MODEL
    public virtual DbSet<Pokemon> Pokemon {get; set;} = null!;
}