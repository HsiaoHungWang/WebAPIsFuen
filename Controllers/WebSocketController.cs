using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace WebAPIsFuen.Controllers
{
    public class WebSocketController : Controller
    {
        //紀錄聊天室中的所有人
        static ConcurrentDictionary<int, WebSocket> WebSockets = new ConcurrentDictionary<int, WebSocket>();

        public IActionResult Index()
        {
            return View();
        }

        //定義GET函式
        [Route("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await ProcessWebSocket(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            }
        }
        //定義ProcessWebSocket函式
        public async Task ProcessWebSocket(WebSocket webSocket)
        {
           
            WebSockets.TryAdd(webSocket.GetHashCode(), webSocket);  //將連接進來的使用者加到WebSockets集合(ConcurrentDictionary)
            var buffer = new byte[1024 * 4]; //建立一個4k大小的RAM空間，用來存放要傳送的資料
            //將接收到資料塞進buffer中，不做取消的處理
            var res = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            string? userName = "匿名";
            while (!res.CloseStatus.HasValue)
            {
               // UserName = "匿名";
               //把接收到的資料讀出來
                var message = Encoding.UTF8.GetString(buffer, 0, res.Count); //res是接收到的內容
                if(!string.IsNullOrEmpty(message))
                {
                    if(message.StartsWith("/USER "))
                    {
                        userName = message.Substring(6);
                    }
                    //Broadcast($"{userName}說:{message}");
                    Broadcast($"{message}");
                }
                res = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                //JObject data = JObject.Parse(message);
                //string? Name = Convert.ToString(data["userName"]);
                //string? Message = $"{Convert.ToString(data["message"])} at {DateTime.Now}";
                //if (!string.IsNullOrEmpty(Name)) { UserName = Name; }
                //Broadcast(JsonConvert.SerializeObject(new { userName = UserName, message = Message }));


            }
            //websocket關閉
            await webSocket.CloseAsync(res.CloseStatus.Value, res.CloseStatusDescription, CancellationToken.None);
            //websocket斷線
            WebSockets.TryRemove(webSocket.GetHashCode(), out var removed);
            Broadcast(JsonConvert.SerializeObject(new {userName = userName, message="離開聊天室"}));
            //Broadcase($"{userName}離開聊天室!!");

        }


 //定義Broadcase函式
        public void Broadcast(string message)
        {
            //var buff = Encoding.UTF8.GetBytes($"{message} at {DateTime.Now}");
            
            var buff = Encoding.UTF8.GetBytes(message); 
            var data = new ArraySegment<byte>(buff, 0, buff.Length);
            //平行運算
            Parallel.ForEach(WebSockets.Values, async (webSocket) =>
            {
                if (webSocket.State == WebSocketState.Open)
                {
                    //true 是 endofmessage
                    await webSocket.SendAsync(data, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            });
        }
    }
}
