using Microsoft.EntityFrameworkCore;

namespace Taxi24.Infrastructure.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
