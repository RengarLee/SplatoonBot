using Microsoft.AspNetCore.Mvc;
using SplatoonBot.Splatoon2;

namespace SplatoonBot.Api.Controllers;

[ApiController]
public class Splatoon2Controller : Controller
{
    private readonly ISplatoon2Manager _splatoon2Manager;

    public Splatoon2Controller(ISplatoon2Manager splatoon2Manager)
    {
        _splatoon2Manager = splatoon2Manager;
    }

    [HttpGet("Schedules")]
    public Task<Splatoon2Schedules> GetSchedulesAsync()
    {
        return _splatoon2Manager.GetSchedulesAsync();
    }

    [HttpGet("Schedule/List")]
    public Task<List<Schedule>> GetSchedulesAsync(DateTime startTime, DateTime endTime)
    {
        return _splatoon2Manager.GetScheduleListAsync(startTime, endTime);
    }
}