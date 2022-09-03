using Microsoft.AspNetCore.Mvc;
using SplatoonBot.CqHttp;
using SplatoonBot.Event;

namespace SplatoonBot.Api.Controllers;

[ApiController]
public class CqHttpController : Controller
{
    private readonly ICqHttpService _cqHttpService;

    public CqHttpController(ICqHttpService cqHttpService)
    {
        _cqHttpService = cqHttpService;
    }

    [HttpGet("Message/CqSplatoonSchedule")]
    public Task GetCqSplatoonScheduleMessagesAsync(string text, bool isSend = false, int? groupId = null)
    {
        return _cqHttpService.GetCqSplatoonScheduleMessagesAsync(text, isSend, groupId);
    }

    [HttpPost("/")]
    public Task HandleEventAsync(GeneralEvent generalEvent)
    {
        return _cqHttpService.HandleEventAsync(generalEvent);
    }
}