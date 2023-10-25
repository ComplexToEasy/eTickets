using eTickets.Data;
using eTickets.Data.services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allMovies.Where(n => n.Name.Contains(searchString) ||
                n.Description.Contains(searchString)).ToList();
                return View("Index", filterResult);
            }

            return View(allMovies);
        }
        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }
        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var moviedropdown = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(moviedropdown.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviedropdown.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviedropdown.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviedropdown = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(moviedropdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviedropdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviedropdown.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            if (movieDetail == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetail.Id,
                Name = movieDetail.Name,
                Description = movieDetail.Description,
                Price = movieDetail.Price,
                StartDate = movieDetail.StartDate,
                EndDate = movieDetail.EndDate,
                ImageURL = movieDetail.ImageURL,
                MovieCategory = movieDetail.MovieCategory,
                CinemaId = movieDetail.CinemaId,
                ProducerId = movieDetail.ProducerId,
                ActorIds = movieDetail.Actor_Movie.Select(n => n.ActorId).ToList(),
            };

            var moviedropdown = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(moviedropdown.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviedropdown.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviedropdown.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var moviedropdown = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(moviedropdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviedropdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviedropdown.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
