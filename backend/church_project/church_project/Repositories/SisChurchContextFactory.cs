using Microsoft.EntityFrameworkCore;

namespace church_project.Repositories;

public class SisChurchContextFactory
{
    public SisChurchContext CreateDbContext(string[]? args = null)
    {
        var builder = new DbContextOptionsBuilder<SisChurchContext>();


        var connectionString = "server=localhost; user=root;password=root;database=church_dot_net;";


        builder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));


        return new SisChurchContext(builder.Options);
      
    }

    
}