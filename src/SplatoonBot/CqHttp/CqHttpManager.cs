using Microsoft.Extensions.Options;
using RestSharp;

namespace SplatoonBot.CqHttp;

public class CqHttpManager : ICqHttpManager
{
    private readonly RestClient _client;

    public CqHttpManager(IOptions<CqHttpOptions> options)
    {
        _client = new RestClient(options.Value.URL);
    }

    public Task SendGroupMessageAsync(long groupId, string message)
    {
        var request = new RestRequest("send_group_msg")
            .AddParameter("group_id", groupId)
            .AddParameter("message",
                message);
        return _client.PostAsync(request);
    }

    public async Task SendGroupMessagesAsync(long groupId, List<string> messages)
    {
        foreach (var message in messages)
        {
            await SendGroupMessageAsync(groupId, message);
        }
    }
}