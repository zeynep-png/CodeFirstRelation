using CodeFirstRelation.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstRelation.Context
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=ZEYNEP\SQLEXPRESS; database=PatikaCodeFirstDb2; Trusted_Connection=true; TrustServerCertificate=true");


            //optionsBuilder.UseSqlServer(@"server=ZEYNEP\SQLEXPRESS; database=PatikaFirstDb; uid=sa; pwd=sa; TrustedServerCertificate=true");

            base.OnConfiguring(optionsBuilder);



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
