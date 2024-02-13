using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                WebSockets.TryAdd(webSocket.GetHashCode(), webSocket);  //將連接進來的使用者加到WebSockets集合(ConcurrentDictionary)
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
           
           
            var buffer = new byte[1024 * 4]; //建立一個4k大小的RAM空間，用來存放要傳送的資料

            //將接收到資料塞進buffer中，不做取消的處理
            var res = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            //string? userName = null;
            while (!res.CloseStatus.HasValue)
            {
                string json = Encoding.UTF8.GetString(buffer, 0, res.Count);
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                Message? receivedMessage = JsonSerializer.Deserialize<Message>(json, options);
               
                if (receivedMessage != null)
                {
                  //  userName = receivedMessage.UserName;
                    receivedMessage.Timestamp = DateTime.Now;
                    string updatedJson = JsonSerializer.Serialize(receivedMessage);
                    Broadcast(updatedJson); //接收到的資料傳給Broadcase自訂函式，在此函式中廣播給所有連線的使用者
                }


                res = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            //websocket關閉
            await webSocket.CloseAsync(res.CloseStatus.Value, res.CloseStatusDescription, CancellationToken.None);
            //從WebSockets集合(ConcurrentDictionary)移除離線使用者
            WebSockets.TryRemove(webSocket.GetHashCode(), out var removed);


          
        }


        //定義Broadcase函式
        public void Broadcast(string message)
        {            
            //平行運算
            Parallel.ForEach(WebSockets.Values, async (webSocket) =>
            {
                if (webSocket.State == WebSocketState.Open)
                {                   
                    await webSocket.SendAsync(Encoding.UTF8.GetBytes(message), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            });
        }
    }
}
public class Message
{
  
    public string? UserName { get; set; } 
    public string? MessageContent { get; set; }
    public DateTime Timestamp { get; set; }
}