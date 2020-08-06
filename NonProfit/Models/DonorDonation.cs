namespace NonProfit.Models
{
  public class DonorDonation
  {
    public int DonorDonationId { get; set; }
    public int DonationId {get;set;}
    public int DonorId { get; set;}
    public Donation Donation {get;set;}
    public Donor Donor {get; set;}
  }
}