using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPIsFuen.Models;

namespace WebAPIsFuen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FormPractice()
        {
            return View();
        }
        public IActionResult FormCustomValidation() {
            return View();
        }
        public IActionResult Audio()
        {
            return View();
        }
        public IActionResult Video()
        {
            return View();
        }

        public IActionResult Canvas() {
            return View();
        }
        public IActionResult CanvasBarChart()
        {
            return View();
        }
        public IActionResult Drawing()
        {
            return View();
        }
        public IActionResult SVG()
        {
            return View();
        }
        public IActionResult SVGBarChart()
        {
            return View();
        }
        public IActionResult DragAndDrop()
        {
            return View();
        }
        public IActionResult Shopping()
        {
            return View();
        }
        public IActionResult FileAPI()
        {
            return View();
        }
        public IActionResult FileReaderText()
        {
            return View();
        }
        public IActionResult FileReaderImage()
        {
            return View();
        }
        public IActionResult WebStorage()
        {
            return View();
        }

        public IActionResult StickyNotes()
        {
            return View();
        }

        public IActionResult SSEClient()
        {
            return View();
        }

        public IActionResult YoubikeClient()
        {
            return View();
        }

        public IActionResult WebSocket()
        {
            return View();
        }

        public IActionResult Chatroom()
        {
            return View();
        }
        public IActionResult Clipboard()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }

        public IActionResult Geolocation()
        {
            return View();
        }
        public IActionResult WebWorker()
        {
            return View();
        }
        public IActionResult SharedWorker1()
        {
            return View();
        }
        public IActionResult SharedWorker2()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
