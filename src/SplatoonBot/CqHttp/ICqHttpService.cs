using SplatoonBot.Event;

namespace SplatoonBot.CqHttp;

public interface ICqHttpService
{
    Task<List<string>> GetCqSplatoonScheduleMessagesAsync(string text, bool isSend, long? groupId);
    Task HandleEventAsync(GeneralEvent generalEvent);
}