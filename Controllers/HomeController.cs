using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPIsFuen.Models;

namespace WebAPIsFuen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Vedio()
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

        //接收小畫家傳過來的圖
        [HttpPost]
        //Querystring URL?id=1&item=abc
        //FormData > <form>
        public IActionResult DrawingUpload([FromBody]Base64ImageDTO _dto)
        {
            if(_dto.ImageBase64 != null)
            {
                string fileName = "";
                if (string.IsNullOrEmpty(_dto.FileName))
                {
                    fileName = $"{Guid.NewGuid()}.png";
                }
                else
                {
                    fileName = _dto.FileName ;
                }
                //將base64字串轉成Byte[]
                var bytes = Convert.FromBase64String(_dto.ImageBase64);

                //產生檔案儲存的實際路徑
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                //將Byte[]儲存成一個檔案
                System.IO.File.WriteAllBytes(uploadPath, bytes);



            }

            return Ok("檔案上傳成功");
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
