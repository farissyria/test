using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    //2. add dbcontext
    public class Dbcontext:IdentityDbContext<IdentityUser>
    {
        public Dbcontext(DbContextOptions<Dbcontext>opt ):base(opt)
        {
            
        }
        public DbSet<Item>items { get; set; }
    }
}
