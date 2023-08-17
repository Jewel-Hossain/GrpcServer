//In the name of Allah
using GRPC.Models;
using Microsoft.EntityFrameworkCore;

public class CityContext : DbContext
{
    public CityContext(DbContextOptions<CityContext> options) : base(options){}
    public DbSet<City> Cities { get; set; }

}