using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ThunderCats.Web.Hubs
{

    
    public class CounterHub : Hub
    {
        static int counter = 0;

        public override Task OnConnected()
        {
            counter = counter + 1;

            Clients.All.UpdateCount(counter);
            return base.OnConnected();
        }


        public override Task OnReconnected()
        {
            counter = counter + 1;

            Clients.All.UpdateCount(counter);
            return base.OnReconnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            counter = counter - 1;
            Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }      
    }
}