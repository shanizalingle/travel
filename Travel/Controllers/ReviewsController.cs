using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
  public class ReviewsController : Controller
  {
    [HttpGet("/reviews")]
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews();
      return View(allReviews);
    }
    [HttpPost]
    public IActionResult Index(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }
    [HttpPost]
    public IActionResult Edit(Review review)
    {
      // review.ReviewId = id;
      Review.Put(review);
      return RedirectToAction("Details", new { id = review.ReviewId});
    }
    public IActionResult Delete(int id)
    {
      Review.Delete(id);
      return RedirectToAction("Index");
    }
  }
}