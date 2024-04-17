using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using WebAPIsFuen.Models;

namespace WebAPIsFuen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHost = webHostEnvironment;
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
        public IActionResult Message()
        {
            string message = "";
            message += $"event:show\n";
            message += $"id:{Guid.NewGuid()}\n";
            message += $"retry:1000\n";
            message += $"data:{DateTime.Now.ToString("HH:mm:sss")}\n\n";

            return Content(message, "text/event-stream", Encoding.UTF8);
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



        public IActionResult Uploads(IEnumerable<IFormFile> files)
        {
            if (files.Count() != 0)
            {
                foreach (IFormFile file in files)
                {
                    //檔案上傳要知道資料夾的實際路徑
                    //C:\Users\iSpan\Documents\WebAPIs\Workspace\wwwroot\uploads
                    string uploadPath = Path.Combine(_webHost.WebRootPath, "uploads", file.FileName);
                    //檔案的儲存要用FileStream
                    using (FileStream stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }


                }
                return Content("上傳成功");
            }
            else
            {
                return Content("沒有檔案");
            }

            // return Content(uploadPath);
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
