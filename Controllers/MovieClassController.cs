using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tema_2___Movies.Data;
using Tema_2___Movies.Models;

namespace Tema_2___Movies.Controllers
{
    public class MovieClassController : Controller
    {

        static private List<MovieClass> movies = new List<MovieClass>();

        private readonly Tema_2___MoviesContext _context;

        public MovieClassController(Tema_2___MoviesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(movies);
        }
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieClass = movies.Find(m => m.id == id);

            if (movieClass == null)
            {
                return NotFound();
            }

            return View(movieClass);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,name,genre,releasedate,agerating,movierating")] MovieClass movieClass)
        {
            if (ModelState.IsValid)
            {
                movieClass.id = Guid.NewGuid();
                movies.Add(movieClass);
                return RedirectToAction(nameof(Index));
            }
            return View(movieClass);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieClass = movies.Find(m => m.id == id);
            if (movieClass == null)
            {
                return NotFound();
            }
            return View(movieClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("id,name,genre,releasedate,agerating,movierating")] MovieClass movieClass)
        {
            if (id != movieClass.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    var movieEdit = movies.Find(m => m.id == id);
                    movieEdit.name = movieClass.name;
                    movieEdit.genre = movieClass.genre;
                    movieEdit.releasedate = movieClass.releasedate;
                    movieEdit.agerating = movieClass.agerating;
                    movieEdit.movierating = movieClass.movierating;


                return RedirectToAction(nameof(Index));
            }
            return View(movieClass);
        }


        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieClass = movies.Find(m => m.id == id);

            if (movieClass == null)
            {
                return NotFound();
            }

            return View(movieClass);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movieClass = movies.Find(m => m.id == id);
            movies.Remove(movieClass);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieClassExists(Guid id)
        {
            return _context.MovieClass.Any(e => e.id == id);
        }
    }
}
