using Microsoft.AspNetCore.Mvc;
using NonProfit.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NonProfit.Controllers
{
  public class DonorsController : Controller
  {
    private readonly NonProfitContext _db;
    public DonorsController(NonProfitContext db)
    {
      _db = db;
    }
    //
    public ActionResult Index()
    {
      List<Donor> model = _db.Donors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Donor donor)
    {
      _db.Donors.Add(donor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDonor = _db.Donors
      .Include(donor => donor.Donations)
      .ThenInclude(join => join.Donation)
      .FirstOrDefault(donor => donor.DonorId == id);
      return View(thisDonor);
    }

    public ActionResult Edit(int id)
    {
      var thisDonor = _db.Donors.FirstOrDefault(donor => donor.DonorId == id);
      return View(thisDonor);
    }

    [HttpPost]
    public ActionResult Edit(Donor donor)
    {
      _db.Entry(donor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDonor = _db.Donors.FirstOrDefault(donor => donor.DonorId == id);
      return View(thisDonor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDonor = _db.Donors.FirstOrDefault(donor => donor.DonorId == id);
      _db.Donors.Remove(thisDonor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}