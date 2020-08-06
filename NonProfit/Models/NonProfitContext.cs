using Microsoft.EntityFrameworkCore;

namespace NonProfit.Models
{
  public class NonProfitContext : DbContext
  {
    public virtual DbSet<Donor> Donors { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<DonorDonation> DonorDonation {get; set;}

    public NonProfitContext(DbContextOptions options) : base(options) { }
  }
}