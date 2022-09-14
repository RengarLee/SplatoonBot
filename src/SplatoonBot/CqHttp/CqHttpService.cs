using SplatoonBot.Event;
using SplatoonBot.Splatoon3;
using SplatoonBot.Text;

namespace SplatoonBot.CqHttp;

public class CqHttpService : ICqHttpService
{
    private readonly ISplatoon3Manager _splatoon3Manager;
    private readonly ITextManager _textManager;
    private readonly ICqHttpManager _cqHttpManager;

    public CqHttpService(ITextManager textManager, ICqHttpManager cqHttpManager, ISplatoon3Manager splatoon3Manager)
    {
        _textManager = textManager;
        _cqHttpManager = cqHttpManager;
        _splatoon3Manager = splatoon3Manager;
    }


    public async Task<List<string>> GetCqSplatoonScheduleMessagesAsync(string text, bool isSend, long? groupId)
    {
        if (_textManager.IsSplatoonText(text))
        {
            var (startTime, endTime) = _textManager.GetSplatoonScheduleTime(text);
            var schedules = await _splatoon3Manager.GetBankaraSchedules(startTime, endTime);
            var messages = _splatoon3Manager.GetBankaraSchedulesMessages(schedules);
            if (isSend) await _cqHttpManager.SendGroupMessagesAsync(groupId.GetValueOrDefault(), messages);
            return messages;
        }
        return new List<string>(0);
    }

    public async Task HandleEventAsync(GeneralEvent generalEvent)
    {
        //过期数据不处理
        if (DateTime.Now >= generalEvent.Time.AddMinutes(5))
            return;
        //仅处理Splatoon群地图查询
        if (generalEvent.IsGroupMessage())
            await GetCqSplatoonScheduleMessagesAsync(generalEvent.RawMessage, true, generalEvent.GroupId);
    }
}