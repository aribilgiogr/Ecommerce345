using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class ShopContext : IdentityDbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {
        }
    }
}
