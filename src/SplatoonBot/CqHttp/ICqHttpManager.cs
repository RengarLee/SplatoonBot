namespace SplatoonBot.CqHttp;

public interface ICqHttpManager
{
    public Task SendGroupMessageAsync(long groupId, string message);

    public Task SendGroupMessagesAsync(long groupId, List<string> messages);
}