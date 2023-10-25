using eTickets.Data;
using eTickets.Data.services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allproducers = await _service.GetAllAsync();
            return View(allproducers);
        }
        //GET: producers/detail/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        //GET:  Producer/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        //GET:  Producer/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerdetail = await _service.GetByIdAsync(id);
            if (producerdetail == null) return View("NotFound");
            return View(producerdetail);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        //GET:  Producer/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerdetail = await _service.GetByIdAsync(id);
            if (producerdetail == null) return View("NotFound");
            return View(producerdetail);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producerdetail = await _service.GetByIdAsync(id);
            if (producerdetail == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
