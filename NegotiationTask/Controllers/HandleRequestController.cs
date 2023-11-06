using Microsoft.AspNetCore.Mvc;
using NegotiationTask.Data;
using NegotiationTask.FIlter;
using NegotiationTask.Models;

namespace NegotiationTask.Controllers
{
    public class HandleRequestController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HandleRequestController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
