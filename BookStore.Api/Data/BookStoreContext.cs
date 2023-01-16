using BookStore.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data
{
    public class BookStoreContext:IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):
            base(options)
        {

        }

        public DbSet<Books>  Books { get; set; }
        
    }
}
