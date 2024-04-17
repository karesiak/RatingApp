using Microsoft.AspNetCore.Mvc;
using RatingApp.Data;
using RatingApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Controllers
{
    public class RatingsController : Controller
    {
        private readonly RatingContext _context;

        public RatingsController(RatingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ratings = _context.Ratings
                .OrderBy(r => r.Subject)
                .ThenBy(r => r.DateAdded)
                .ToList();
            return View(ratings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,Subject,StudentId,StudentName")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                var existingRating = _context.Ratings
                    .Any(r => r.StudentId == rating.StudentId && r.Subject == rating.Subject);

                if (!existingRating)
                {
                    _context.Add(rating);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Student already has a rating for this subject.");
                }
            }
            return View(rating);
        }
    }
}
