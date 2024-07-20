using ApkaAnalizatorDomain.Enties;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ApkaAnalizatorInfrastructure
{
    public class ApkaAnalizatorDbContext : IdentityDbContext<Account>
    {
        public ApkaAnalizatorDbContext(DbContextOptions<ApkaAnalizatorDbContext> options) : base(options)
        {

        }
        public DbSet<Analizator> Analizators { get; set; }
        public DbSet<HL7> HL7s { get; set; }
        public DbSet<ApkaKrzysztofa> ZAplikacjiKrzysztofa { get; set; } 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.EmailConfirmed).HasConversion<int>();
                entity.Property(e => e.PasswordHash).HasMaxLength(256);
                entity.Property(e => e.SecurityStamp).HasMaxLength(256);
                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
                entity.Property(e => e.PhoneNumberConfirmed).HasConversion<int>();
                entity.Property(e => e.TwoFactorEnabled).HasConversion<int>();
                entity.Property(e => e.LockoutEnd).HasConversion(
                    v => v.HasValue ? v.Value.DateTime : (DateTime?)null,
                    v => v.HasValue ? new DateTimeOffset(v.Value) : (DateTimeOffset?)null);
                entity.Property(e => e.LockoutEnabled).HasConversion<int>();
                entity.Property(e => e.AccessFailedCount);
                entity.Property(e => e.UserName).HasMaxLength(256);
                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
                entity.HasKey(e => e.Id).HasName("PK_AspNetUsers");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(2000).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(256);
                entity.Property(e => e.NormalizedName).HasMaxLength(256);
                entity.HasKey(e => e.Id).HasName("PK_AspNetRoles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(r => new { r.UserId, r.RoleId });
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.HasKey(uc => uc.Id);
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.HasKey(rc => rc.Id);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            });

        }
    }
}
