using Microsoft.EntityFrameworkCore;

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<LmsDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("LmsDatabase")));
    services.AddControllers();
}
