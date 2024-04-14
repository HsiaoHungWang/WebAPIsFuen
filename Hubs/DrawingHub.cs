using Microsoft.AspNetCore.SignalR;

namespace WebAPIsFuen.Hubs
{
    public class DrawingHub:Hub
    {
        public async Task SendData(string data)
        {
            //receiveData 是JavaScript用來接收資料的funciton
            //Others 是將資料廣播給自己以外的連線使用者
            await Clients.Others.SendAsync("receiveData",data);
            //All 是將資料廣播給所有的連線使用者
            //await Clients.All.SendAsync("receiveData", data);
        }
    }
}
