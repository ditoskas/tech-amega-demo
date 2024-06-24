using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace PushService.Hubs
{
    public class QuotesHub : Hub
    {
        public static uint Connections { get; private set; } = 0;
        public static List<string> PairGroups { get; private set; } = new List<string>();
        public static ConcurrentDictionary<string, string> ConnectionToGroup { get; private set; } = new ConcurrentDictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            Connections++;
            await Clients.All.SendAsync("Connections", Connections);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Connections--;
            await Clients.All.SendAsync("Connections", Connections);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SubscribeGroup(string groupName)
        {
            string key = Context.ConnectionId + ":" + groupName;
            if (!ConnectionToGroup.ContainsKey(key))
            {
                ConnectionToGroup.TryAdd(key, groupName);
                await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            }
        }

        public async Task UnsubscribeGroup(string groupName)
        {
            string key = Context.ConnectionId + ":" + groupName;
            if (ConnectionToGroup.ContainsKey(key))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
                ConnectionToGroup.TryRemove(key, out _);
            }
        }
    }
}
