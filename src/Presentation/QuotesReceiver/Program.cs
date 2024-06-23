// See https://aka.ms/new-console-template for more information
using System.Configuration;
using Websocket.Client;


try
{
    ManualResetEvent _quitEvent = new ManualResetEvent(false);
    string? webSocketUrl = ConfigurationManager.AppSettings["WebSocketUrl"];
    if (webSocketUrl == null)
    {
        throw new Exception("WebSocketUrl is not defined in the app.config file");
    }

    string? token = ConfigurationManager.AppSettings["WebSocketToken"];
    if (token == null)
    {
        throw new Exception("WebSocketToken is not defined in the app.config file");
    }


    Uri uri = new Uri(webSocketUrl);
    using (var client = new WebsocketClient(uri))
    {
        client.ReconnectTimeout = TimeSpan.FromSeconds(30);
        client.ReconnectionHappened.Subscribe(info =>
        {
            Console.WriteLine("Reconnection happened, type: " + info.Type);
        });
        client.MessageReceived.Subscribe(msg =>
        {
            Console.WriteLine("Message received: " + msg);
            if (msg.ToString().ToLower() == "connected")
            {
                string data = "{\"userKey\":\"" + token + "\", \"symbol\":\"BTCUSD\"}";
                client.Send(data);
            }
        });
        _ = client.Start();
        //Task.Run(() => client.Send("{ message }"));
        _quitEvent.WaitOne();
    }
}
catch (Exception ex)
{
    Console.WriteLine("ERROR: " + ex.ToString());
}