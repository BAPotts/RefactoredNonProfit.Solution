using System.Collections.Generic;

namespace NonProfit.Models
{
  public class Donor 
  {
    public Donor()
    {
      this.Donations = new HashSet<DonorDonation>();
    }

    public int DonorId { get; set;}
    public string Name { get; set;}
    public virtual ICollection<DonorDonation> Donations {get;set;}
  }
}
