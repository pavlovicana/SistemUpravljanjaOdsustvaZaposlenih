using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                { 
                    Id = "2a572baf-86fd-42ce-aea1-3785a3b59f18",
                    Name = "Zaposleni",
                    NormalizedName = "ZAPOSLENI", //CAPITALIZED version of Name    
                },
                new IdentityRole 
                {
                    Id = "8a78b824-af0f-4e35-96f5-9a68423ac02d",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR", //CAPITALIZED version of Name  
                },
                new IdentityRole 
                {
                    Id = "9c451184-c8d7-4384-9c6d-396c615546ad",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR", //CAPITALIZED version of Name  

                });
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "f56cfd75-8375-43da-9ae0-0fa940a097f6",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true,
                Ime = "Default",
                Prezime = "Admin",
                DatumRodjenja= new DateOnly(1950,12,1)
            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "083effaf-d3b2-42e7-8985-3e2ead23a99e",
                Email = "administrator@localhost.com",
                NormalizedEmail = "ADMINISTRATOR@LOCALHOST.COM",
                UserName = "administrator@localhost.com",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true,
                Ime = "Default",
                Prezime = "Administrator",
                DatumRodjenja = new DateOnly(1950, 12, 1)
            });



            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "9c451184-c8d7-4384-9c6d-396c615546ad",
                UserId = "f56cfd75-8375-43da-9ae0-0fa940a097f6"
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "9c451184-c8d7-4384-9c6d-396c615546ad",
                UserId = "083effaf-d3b2-42e7-8985-3e2ead23a99e"
            });
        }

        public DbSet<TipOdsustva> TipOdsustva{ get; set; } 
    }
}
