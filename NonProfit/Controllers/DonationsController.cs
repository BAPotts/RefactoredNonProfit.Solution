using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NonProfit.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NonProfit.Controllers
{
  public class DonationsController : Controller
  {
    private readonly NonProfitContext _db;
    public DonationsController(NonProfitContext db)
    {
      _db = db;
    }
    ////////
    public ActionResult Index()
    {

      return View(_db.Donations.ToList());
    }
    ////////
    public ActionResult Details(int id)
    {
      var thisDonation = _db.Donations.Include(donation => donation.Donors).ThenInclude(join => join.Donor).FirstOrDefault(donation => donation.DonationId == id);
      return View(thisDonation);
    }
    ////////
    public ActionResult Create()
    {
      ViewBag.DonorId = new SelectList(_db.Donors, "DonorId", "Name");
      return View();
    }
    ////////
    [HttpPost]
    public ActionResult Create(Donation donation, int DonorId)
    {
      _db.Donations.Add(donation);
      if (DonorId != 0)
      {
        _db.DonorDonation.Add(new DonorDonation() { DonorId = DonorId, DonationId = donation.DonationId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    ////////
    public ActionResult Edit(int id)
    {
      var thisDonation = _db.Donations.FirstOrDefault(Donations => Donations.DonationId == id);
      ViewBag.DonorId = new SelectList(_db.Donors, "DonorId", "Name");
      return View(thisDonation);
    }
    ////////
    [HttpPost]
    public ActionResult Edit(Donation donation, int DonorId)
    {
      if (DonorId != 0)
      {
        _db.DonorDonation.Add(new DonorDonation() { DonorId = DonorId, DonationId = donation.DonationId });
      }
      _db.Entry(donation).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    ////////
    public ActionResult AddDonor(int id)
    {
      var thisDonation = _db.Donations.FirstOrDefault(donations => donations.DonationId == id);
      ViewBag.DonorId = new SelectList(_db.Donors, "DonorId", "Name");
      return View(thisDonation);
    }
    ////////
    [HttpPost]
    public ActionResult AddDonor(Donation donation, int DonorId)
    {
      if (DonorId != 0)
      {
        _db.DonorDonation.Add(new DonorDonation() { DonorId = DonorId, DonationId = donation.DonationId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    ////////
    public ActionResult Delete(int id)
    {
      var thisDonation = _db.Donations.FirstOrDefault(donations => donations.DonationId == id);
      return View(thisDonation);
    }
    ////////
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDonation = _db.Donations.FirstOrDefault(donations => donations.DonationId == id);
      _db.Donations.Remove(thisDonation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    ////////
    [HttpPost]
    public ActionResult DeleteCategory(int joinId)
    {
      var joinEntry = _db.DonorDonation.FirstOrDefault(entry => entry.DonorDonationId == joinId);
      _db.DonorDonation.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
