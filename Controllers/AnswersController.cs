using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebAPIsFuen.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AnswersController(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FormPractice()
        {
            return View();
        }
        public IActionResult PasswordValidation()
        {
            return View();
        }
        public IActionResult FormCustomValidation()
        {
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
        public IActionResult Canvas()
        {
            return View();
        }

        public IActionResult CanvasBarChart()
        {
            return View();
        }
        public IActionResult CanvasPieChart()
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
            message += $"id:{Guid.NewGuid()}\n";
            message += "retry:1000\n";
            message += $"data:{DateTime.Now.ToString("HH:mm:ss")}\n\n";
            return Content($"{message}", "text/event-stream", Encoding.UTF8);
        }

        public async Task<IActionResult> YoubikeServer()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();            
            var response = await httpClient.GetAsync("https://tcgbusfs.blob.core.windows.net/dotapp/youbike/v2/youbike_immediate.json");
            var json = await response.Content.ReadAsStringAsync();
            //var jsonObj = JArray.Parse(json).ToString();
            // return Content(jsonObj,"application/json",Encoding.UTF8);
            //組成 event-stream 的格式
            string message = "";
            message += $"id:{Guid.NewGuid()}\n";
            message += "retry:60000\n";
            message += $"data:{json}\n\n";
            return Content($"{message}", "text/event-stream", Encoding.UTF8);
          
        }

        public IActionResult YoubikeClient() { 
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


    }
}
