using SplatoonBot.Event;
using SplatoonBot.Splatoon2;
using SplatoonBot.Text;

namespace SplatoonBot.CqHttp;

public class CqHttpService : ICqHttpService
{
    private readonly ISplatoon2Manager _splatoon2Manager;
    private readonly ITextManager _textManager;
    private readonly ICqHttpManager _cqHttpManager;

    public CqHttpService(ISplatoon2Manager splatoon2Manager, ITextManager textManager, ICqHttpManager cqHttpManager)
    {
        _splatoon2Manager = splatoon2Manager;
        _textManager = textManager;
        _cqHttpManager = cqHttpManager;
    }


    public async Task<List<string>> GetCqSplatoonScheduleMessagesAsync(string text, bool isSend, long? groupId)
    {
        if (_textManager.IsSplatoonText(text))
        {
            var (startTime, endTime) = _textManager.GetSplatoonScheduleTime(text);
            var schedules = await _splatoon2Manager.GetScheduleListAsync(startTime, endTime);
            var messages = _textManager.GetCqSplatoonScheduleMessages(schedules);
            if (isSend)
            {
                await _cqHttpManager.SendGroupMessagesAsync(groupId.GetValueOrDefault(), messages);
            }
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